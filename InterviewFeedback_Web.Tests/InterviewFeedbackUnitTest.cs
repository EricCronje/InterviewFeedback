using System;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewFeedback_Web.Tests
{
    [TestClass]
    public class InterViewFeedback
    {
        [TestMethod]
        public void IncrementQuestionCount_Answer_a_Number_1_Return1()
        {
            //Arrange
            using (var db = new FeedBackContext())
            {
                var answer = "a";
                var questionNumber = 1;
                //reset total to 0 
                db.Database.ExecuteSqlCommand("Update Questions set QuestionFeedbackTotal = 0 where QuestionAnswer = 'a' and QuestionNumber = 1");
                //Act
                HelperUtilities.HelperUtilities.IncrementQuestionCount(db, answer, questionNumber);
                //Check
                var result = db.Questions.SqlQuery("select * from [dbo].[Questions] where QuestionAnswer = 'a' and QuestionNumber = 1;").ToList<Question>();
                //Assert
                Assert.AreEqual(result[0].QuestionFeedbackTotal, 1);

            }
        }

        [TestMethod]
        public void IncrementApplicantCount_ValidValues_Return1()
        {
            //Arrange
            using (var db = new FeedBackContext())
            {
                //Reset to 0
                db.Database.ExecuteSqlCommand("Update Feedbacks set TotalApplicants = 0");
                //Act
                HelperUtilities.HelperUtilities.IncrementFeedBack(db);
                db.SaveChanges();
                //Check
                var result = db.Feedbacks.SqlQuery("SELECT * FROM Feedbacks").ToArray<Feedback>();
                //Assert
                Assert.AreEqual(result[0].TotalApplicants, 1);

            }
        }
        
    }
}
