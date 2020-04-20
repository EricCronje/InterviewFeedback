
    EXECUTE('
        /****** Object:  StoredProcedure [dbo].[IncrementQuestionFeedbackTotal]    Script Date: 4/18/2020 3:23:18 PM ******/
        SET ANSI_NULLS ON
        
    ')
    EXECUTE('
        SET QUOTED_IDENTIFIER ON
        
    ')
    EXECUTE('
        CREATE PROCEDURE [dbo].[IncrementQuestionFeedbackTotal]  
        	@QuestionAnswer varchar(10),
        	@QuestionNumber int
        	AS
        	BEGIN
        		SET NOCOUNT ON;
        		UPDATE Questions SET QuestionFeedbackTotal =  QuestionFeedbackTotal + 1 WHERE Feedback_FeedbackId = (SELECT TOP 1 FeedbackId FROM Feedbacks) AND QuestionAnswer = @QuestionAnswer AND QuestionNumber = @QuestionNumber;
        		SELECT COUNT(*) FROM Questions WHERE Feedback_FeedbackId = (SELECT TOP 1 FeedbackId FROM Feedbacks) AND QuestionAnswer = @QuestionAnswer AND QuestionNumber = @QuestionNumber;
            END
        
    ')

    EXECUTE('
        /****** Object:  StoredProcedure [dbo].[IncrementFeedbackTotalApplicants]    Script Date: 4/18/2020 3:15:40 PM ******/
        SET ANSI_NULLS ON
        
    ')
    EXECUTE('
        SET QUOTED_IDENTIFIER ON
        
    ')
    EXECUTE('
        CREATE PROCEDURE [dbo].[IncrementFeedbackTotalApplicants]  
        	@FeedbackId int 
        	AS
        	BEGIN
        		SET NOCOUNT ON;
        		UPDATE Feedbacks SET TotalApplicants = TotalApplicants + 1 WHERE FeedbackId = (SELECT TOP 1 FeedbackId FROM Feedbacks);
        		SELECT COUNT(*) FROM Feedbacks WHERE FeedbackId = (SELECT TOP 1 FeedbackId FROM Feedbacks);
            END
        
    ')