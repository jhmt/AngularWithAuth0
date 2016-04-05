angular.module('shipments.login', ['auth0'])
    .controller('LoginCtrl', function ($scope, auth, $location) {
        $scope.login = function () {
            auth.signin({}, function (profile, token) {
                $location.path('/');
            }, function (error) {
                console.log("There was an error", error);
            });
        }
    });