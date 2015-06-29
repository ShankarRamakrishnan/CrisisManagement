angular.module('CrisisManagement')
    .controller('IncidentCtrl', function($scope) {
    $scope.loadIncident = function($scope) {

    };

    $scope.saveIncident = function ($scope, $http) {
        console.log($scope.incident.name);
    }
});