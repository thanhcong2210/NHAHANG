
// create the module and name it scotchApp
var monans = angular.module('monans', ['ngRoute']);

// configure our routes
monans.config(function ($routeProvider) {
    $routeProvider

        // route for the about page
        .when('/monans', {
            templateUrl: '/app/components/monans/monanListView.html',
            controller: 'monanListController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'pages/contact.html',
            controller: 'contactController'
        });
});


monans.controller('monanListController', function ($scope) {
    $scope.message = 'danh sach mon an';
});
