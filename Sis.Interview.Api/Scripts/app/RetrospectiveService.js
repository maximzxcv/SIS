var MyModule = angular.module('MyApp', [])


MyModule.controller('RetrospectiveController',
[
    '$scope', 'RetrospectiveService', function($scope, retrospectiveService) {
        $scope.retrospectives = {};
        $scope.participants = [];
        $scope.error = "";
        $scope.retrospectiveName = "";
        $scope.filterDate = "";
        getAll();

        function getAll() {
            retrospectiveService.getAll()
                .success(function(retrospectives) {
                    $scope.retrospectives = retrospectives; 
                });
        }

        $scope.filter = function filter(filterDate) {
            retrospectiveService.getAllByDate(filterDate)
                .success(function (retrospectives) {
                    $scope.retrospectives = retrospectives;
                });
        }

        $scope.create = function create(retrospective) {
            retrospective.Participants = $scope.participants;
            retrospectiveService.add(retrospective)
                .success(function() {
                    getAll();
                    $scope.participants = [];
                    $(".modal").modal("hide");
                })
                .error(function(error) {
                    $scope.error = error.Message;
                });
        }

        $scope.addParticipant = function addParticipant(participant) {
            $scope.participants.push(participant);
        }


        $scope.createFeedback = function createFeedback(retrospectiveName, feedback) {
            retrospectiveService.addFeedback(retrospectiveName, feedback)
                .success(function() { 
                    getAll();
                    $(".modal").modal("hide");
                })
                .error(function(error) {
                    $scope.error = error.Message;
                });
        }

        $scope.addFeedback = function create(retrospectiveName) {
            $scope.retrospectiveName = retrospectiveName;
        }
    }
]);


MyModule.factory('RetrospectiveService', ['$http', function ($http) {

    var RetrospectiveService = {};
    RetrospectiveService.getAll = function () {
        return $http.get('/api/retrospectives');
    }

    RetrospectiveService.getAllByDate = function (date) {
        console.log(date);  
        return $http.get('/api/retrospectives?date=' + date);
    }

    RetrospectiveService.add = function (retrospective) {
        return $http.post('/api/retrospectives', retrospective);
    }

    RetrospectiveService.addFeedback = function (retrospectivesName, feedback) {
        return $http.put('/api/retrospectives/' + retrospectivesName, feedback);
    }

    return RetrospectiveService; 
}]);