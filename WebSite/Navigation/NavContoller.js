angular.module("CrisisManagement")
    .controller('NavCtrl', [
        '$scope', '$location', function($scope, $location) {
        $scope.navClass = function(page) {
            var currentRoute = $location.path().substring(1) || 'home';
            return page === currentRoute ? 'active' : '';
        };

        $scope.loadHome = function() {
            $location.url('/home');
        };

        $scope.loadContactUs = function() {
            $location.url('/contact');
        };

        $scope.loadCreateIncident = function() {
            $location.url('/createIncident');
        };

        $scope.loadManageIncident = function () {
            $location.url('/manageIncident');
        };
    }
    ]);