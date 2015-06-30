angular.module('CrisisManagement')
    .controller('IncidentCtrl', function ($scope, $http) {
    $scope.loadIncident = function($scope) {

    };

    $scope.saveIncident = function () {
        console.log($scope.incident.name);
        console.log($scope.incident.location);
        $scope.loading = true;

        $http.post('http://localhost:12345/Crisis/Create', JSON.stringify($scope.incident))
        .success(function (data) {
            alert('Incident is saved sucessfully.');
        });
    }
});