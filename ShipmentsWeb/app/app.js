angular.module('shipments', [
    'ngRoute',
    'shipments.home',
    'shipments.login'
])
.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'HomeCtrl',
            templateUrl: 'app/components/home/home.html'
        })
        .when('/login', {
            controller: 'LoginCtrl',
            templateUrl: 'app/components/login/login.html'
        })
})