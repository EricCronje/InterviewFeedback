using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InterviewFeedback_Web.HelperUtilities;

namespace InterviewFeedback_Web.HelperUtilities
{
    public class HelperUtilities
    {
        public static void IncrementQuestionCount(FeedBackContext db, string questionAnswer, int questionNumber)
        {
            var questionAnswerParameter = new SqlParameter("@QuestionAnswer", questionAnswer);
            var questionNumberParameter = new SqlParameter("@QuestionNumber", questionNumber);

            var result = db.Database
                .SqlQuery<ResultFeedback>("IncrementQuestionFeedbackTotal @QuestionAnswer, @QuestionNumber", questionAnswerParameter, questionNumberParameter)
                .ToList();

        }

        internal static List<FeedbackSummary> GetFeedbackSummary(FeedBackContext db)
        {
            List<FeedbackSummary> feedbackSummary = new List<FeedbackSummary>();

            var allquestions = db.Questions.SqlQuery("SELECT * FROM [dbo].[Questions];").ToList<Question>();
            for (var i=0; i< allquestions.Count; i++)
            {
                var qid = allquestions[i].QuestionNumber + "-" + allquestions[i].QuestionAnswer;
                var questionNumber = allquestions[i].QuestionNumber;
                var questionAnswer = allquestions[i].QuestionAnswer;
                var feedbacks = db.Feedbacks.SqlQuery("SELECT * FROM Feedbacks").ToArray<Feedback>();
                double percentage =  Math.Round(Convert.ToDouble(allquestions[i].QuestionFeedbackTotal) / Convert.ToDouble(feedbacks[0].TotalApplicants) * 100);
                feedbackSummary.Add(new FeedbackSummary() { QuestionID = qid, QuestionPercentage = percentage });
            }
            
            return feedbackSummary;
        }

        internal static void PerformFeedBackResultUpdate(FeedBackContext db, string[] feedbackResults)
        {

            for (var i=0; i<feedbackResults.Length; i++)
            {
                var answerResults = feedbackResults[i].Split('-');
                var questionNumber = Convert.ToInt32(answerResults[0]);
                var questionAnswer = answerResults[1];
                IncrementQuestionCount(db, questionAnswer, questionNumber);
            }
            IncrementFeedBack(db);

        }

        public static void IncrementFeedBack(FeedBackContext db)
        {
            var feedbackParameter = new SqlParameter("@FeedBackId", 1);

            var result = db.Database
                .SqlQuery<ResultFeedback>("IncrementFeedbackTotalApplicants @FeedBackId", feedbackParameter)
                .ToList();
        }

        public class ResultFeedback
        {
            public int Result { get; set; }
        }

    }
}