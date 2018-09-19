//app.js
var NhaHangApp = angular.module('NhaHangApp', ['ui.router']);

NhaHangApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    // For any unmatched url, send to /business
    $urlRouterProvider.otherwise("/")

    $stateProvider
        .state('home', {//State demonstrating Nested views
            url: "/home",
            templateUrl: '/app/components/home/homeView.html',
            controller: 'homeController'
        });
}]);