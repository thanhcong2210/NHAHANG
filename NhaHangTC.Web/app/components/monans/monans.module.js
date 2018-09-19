//monans.modules.js
var NhaHangApp = angular.module('NhaHangApp', ['ui.router']);

NhaHangApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    // For any unmatched url, send to /business
    $urlRouterProvider.otherwise("/")

    $stateProvider
        .state('monans', {//nested state [products is the nested state of business state]
            url: "/monans",
            templateUrl: '/app/components/monans/monanListView.html',
            controller: 'monanListController'
        })
        .state('home', {//State demonstrating Nested views
            url: "/home",
            templateUrl: '/app/components/home/homeView.html',
            controller: 'homeController'
        });
}]);