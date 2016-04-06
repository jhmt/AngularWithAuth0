﻿angular.module('shipments.home', [
'auth0'])
    .controller('HomeCtrl', function ($scope, auth, $http, $location, store) {
        $scope.shipments = [];
        $scope.auth = auth;

        $scope.viewShipment = function() {
            $http({
                url: SERVICE_BASE + '/api/shipments',
                method: 'GET'
            }).then(function (response) {
                $scope.shipments = response.data;
            }, function (response) {
                alert(response.data);
            });
        }

        $scope.logout = function () {
            auth.signout();
            store.remove('profile');
            store.remove('token');
            $location.path('/login');
        }
    });