angular.module('CrisisManagement')
    .controller('HomeCtrl', function ($scope, $compile) {
    $scope.initializeMap = function() {
        var mapProp = {
            center: new google.maps.LatLng(51.508742, -0.120850),
            zoom: 5,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        $scope.map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    };

    $scope.setMarkerInMap = function(lat, lon) {
        var myCenter = new google.maps.LatLng(lat, lon);
        
        var marker = new google.maps.Marker({
            position: myCenter
            //animation: google.maps.Animation.BOUNCE
        });

        marker.setMap($scope.map);
    };
        
    $scope.initializeMap();
    google.maps.event.addDomListener(window, 'load');
    
    $scope.setMarkerInMap(51.508742, -0.120850);
    $scope.setMarkerInMap(52.508742, -0.120850);
    $scope.setMarkerInMap(20.508742, 80.120850);
});