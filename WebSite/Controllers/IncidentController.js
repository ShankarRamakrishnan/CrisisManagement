angular.module('CrisisManagement')
    .controller('IncidentCtrl', function ($scope, $http) {
        $scope.loadIncident = function (id) {
            $http.get('http://localhost:12345/Crisis/' + id)
                .success(function (response)
                {
                $scope.incident = response.records;
            });
        };

    $scope.saveIncident = function () {
        $scope.incident.AffectedPeople = $scope.incident.AffectedPeople.split(',');
        var d = new Date();
        $scope.incident.WhenHappened = d.toISOString();
        $scope.loading = true;

        $http.post('http://localhost:12345/Crisis/Create', JSON.stringify($scope.incident))
        .success(function (data) {
            alert('Incident is saved sucessfully.');
            $scope.loadManageIncident();
        });
        $scope.incident.AffectedPeople = '';
    }
});