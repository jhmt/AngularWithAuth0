angular.module('shipments', [
    'auth0',
    'ngRoute',
    'shipments.home',
    'shipments.login',
    'angular-storage',
    'angular-jwt'
])
.config(function ($routeProvider, authProvider, $httpProvider, jwtInterceptorProvider) {
    $routeProvider
        .when('/', {
            controller: 'HomeCtrl',
            templateUrl: 'app/components/home/home.html',
            requiresLogin: true
        })
        .when('/login', {
            controller: 'LoginCtrl',
            templateUrl: 'app/components/login/login.html'
        });

    authProvider.init({
        domain: AUTH0_DOMAIN,
        clientID: AUTH0_CLIENT_ID,
        loginUrl: '/login'
    });

    jwtInterceptorProvider.tokenGetter = function (store) {
        return store.get('token');
    }
})
.run(function ($rootScope, auth, store, jwtHelper, $location) {
    $rootScope.$on('$locationChangeStart', function () {
        if (!auth.isAuthenticated) {
            var token = store.get('token');
            if (token) {
                if (!jwtHelper.isTokenExpired(token)) {
                    auth.authenticate(store.get('profile'), token);
                } else {
                    $location.path('/login');
                }
            }
        }
    });
    auth.hookEvents();
})