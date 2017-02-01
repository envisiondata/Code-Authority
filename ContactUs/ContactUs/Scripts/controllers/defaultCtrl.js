//var MyApp = angular.module('ngApp', ['ngResource', 'ngRoute']);

(function () {
    angular.module('ngApp', ['ngRoute'])
    .controller('defaultCtrl', ['$scope', '$window', '$location', function ($scope, $window, $location) {

        $scope.firstName = "James";
        $scope.lastName = "";
        $scope.phone = "";
        $scope.email = "";
        $scope.bestTimeToCall = "";


        $scope.submitToWebservice = function () {

            alert(isValid);
            if (!isValid) {
                alert('Not Valid');
            }
            else {
                alert("Valid");
            }
        }
    }]);  // End defaultCtrl
})();