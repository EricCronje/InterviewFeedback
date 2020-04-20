using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewFeedback_Web
{
    public class FeedBackContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionConfiguration> QuestionConfigurations { get; set; }
    }

    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int TotalApplicants { get; set; }
        public List<Question> FeedbackQuestionsTotals { get; set; }
        public List<QuestionConfiguration> QuestionConfigurations { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionAnswer { get; set; }
        public int QuestionFeedbackTotal { get; set; }
        public string QuestionDisplay { get; set; }
    }

    public class QuestionConfiguration
    {
        public int QuestionConfigurationId { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionAlpahRange { get; set; }
        public string QuestionTypeDescription { get; set; }
    }

}
