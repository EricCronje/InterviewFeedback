	var app = angular.module('feedbackapp', []);
    app.controller('feedbackCtrl', function ($scope, $location, $window, $http) {
        $scope.InterViewFeedbackOpertunity = [];
        $scope.showFeedbackResult = false;

	    $scope.feedBackSelectClick = function(value, singleSelect, currentQuestion) {
            //singleSelect = true - it is a radio button; singleSelect = false then it is a checkbox
            if (singleSelect === false)
	            value.selected = value.selected == true ? false : true;	  
	        if(singleSelect === true)
            {
                //To cater for the select and unselect of the checkbox.
		        angular.forEach(currentQuestion.questionOptions, function(questionOption) {
			        questionOption.selected = false;
		        });
		        value.selected = true;
	        }
        }
	
	    $scope.submitResult = function() {
	        var allFeedBackSelected = true;
		    $scope.InterViewFeedbackOpertunity = [];
		    angular.forEach($scope.interviewFeedback, function(feedback) {
			    if(allFeedBackSelected===true)
			    {
				    angular.forEach(feedback.questionOptions, function(question) {
					    if(question.selected === true)
					    {
						    $scope.InterViewFeedbackOpertunity.push(question.qid);
						    feedback.selected = true;					
					    }
				    });
				    if(feedback.selected === false)
				    {
					    allFeedBackSelected=false;
				    }
			    }
		    });
		
		    if(allFeedBackSelected===false)
		    {
			    alert("Please select at least one option from each question.");
		    } else 
		    {
                var url = 'Feedbacks/PerformFeedBackResultUpdate', data = JSON.stringify($scope.InterViewFeedbackOpertunity), config = 'contenttype';
                $http.post(url, data).then(function (response) {
                    console.log(response);
                    $scope.buildFeedbackResult(response.data);
                    $scope.showFeedbackResult = true;
                }, function (response) {
                   alert("Error: " + response);
                });
		    }

        }

        $scope.buildFeedbackResult = function (feedbackResponse) {

            angular.forEach(feedbackResponse, function (feedbackWithPercentage) {
                angular.forEach($scope.interviewFeedback, function (feedback) {
                    angular.forEach(feedback.questionOptions, function (question) {
                        if (feedbackWithPercentage.QuestionID === question.qid)
                        {
                            question.percentage = "(" + feedbackWithPercentage.QuestionPercentage + "%)";
                        }
                    });
                });
            });

        }
        
	    $scope.interviewFeedback = [
	    {id: "1",
	     question: "1.)	How did you find out about this job opportunity? (single choice)",
         questionOptions: [{ id: "1-a", display: "a. StackOverflow", qid: "1-a", percentage: "(0%)" }, { id: "1-b", display: "b. Indeed", qid: "1-b", percentage: "(0%)" }, { id: "1-c", display: "c. Other", qid: "1-c", percentage: "(0%)"}],
	     questionSingleType: true,
	     selected: false
	    },
	    {id: "2",
	     question: "2.)	How do you find the company's location? (multiple choice)",
         questionOptions: [{ id: "2-a", display: " a. Easy to access by public transport", qid: "2-a", percentage: "(0%)" }, { id: "2-b", display: " b.	Easy to access by car", qid: "2-b", percentage: "(0%)" }, { id: "2-c", display: " c. In a pleasant area", qid: "2-c", percentage: "(0%)" }, { id: "2-d", display: " d. None of the above", qid: "2-d", percentage: "(0%)"}],
	     questionSingleType: false,
	     selected: false
	    },
	    {id: "3",
	     question: "3.)	What was your impression of the office where you had the interview? (single choice)",
         questionOptions: [{ id: "3-a", display: "a. Tidy", qid: "3-a", percentage: "(0%)" }, { id: "3-b", display: "b. Sloppy", qid: "3-b", percentage: "(0%)" }, { id: "3-c", display: "c. Did not notice", qid: "3-c", percentage: "(0%)"}],
	     questionSingleType: true,
	     selected: false
	    },
	    {id: "4",
	     question: "4.)	How technically challenging was the interview? (single choice)",
         questionOptions: [{ id: "4-a", display: "a. Very difficult", qid: "4-a", percentage: "(0%)" }, { id: "4-b", display: "b. Difficult", qid: "4-b", percentage: "(0%)" }, { id: "4-c", display: "c. Moderate", qid: "4-c", percentage: "(0%)" }, { id: "4-d", display: "d. Easy", qid: "4-d", percentage: "(0%)"}],
	     questionSingleType: true,
	     selected: false
	    },
	    {id: "5",
	     question: "5.)	How can you describe the manager that interviewed you? (multiple choice) ",
         questionOptions: [{ id: "5-a", display: " a. Enthusiastic", qid: "5-a", percentage: "(0%)" }, { id: "5-b", display: " b. Polite", qid: "5-b", percentage: "(0%)" }, { id: "5-c", display: " c. Organized", qid: "5-c", percentage: "(0%)" }, { id: "5-d", display: " d. Could not tell", qid: "5-d", percentage: "(0%)"}],
	     questionSingleType: false,
	     selected: false
	    }
	    ];

    });