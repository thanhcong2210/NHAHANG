//app.js
var scotchApp = angular.module('scotchApp', ['ui.router']);

scotchApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    // For any unmatched url, send to /business
    $urlRouterProvider.otherwise("/")

    $stateProvider
        .state('home', {//State demonstrating Nested views
            url: "/home",
            templateUrl: '/app/components/home/homeView.html',
            controller: 'homeController'
        })
        .state('monans', {//nested state [products is the nested state of business state]
            url: "/monans",
            templateUrl: '/app/components/monans/monanListView.html',
            controller: 'monanListController'
        })
        .state('home.monans', {//nested state [products is the nested state of business state]
            url: "/monans",
            templateUrl: '/app/components/monans/monanListView.html',
            controller: 'monanListController'
        })

        .state('portfolio', {//State demonstrating Multiple,named views
            url: "/portfolio",
            views: {
                "": { templateUrl: "portfolio.html" },
                "view1@portfolio": { template: "Write whatever you want, it's your virtual company." },
                "view2@portfolio": {
                    templateUrl: "clients.html",
                    controller: function ($scope) {
                        $scope.clients = ["HP", "IBM", "MicroSoft"];
                    }
                }
            }
        });
}]);