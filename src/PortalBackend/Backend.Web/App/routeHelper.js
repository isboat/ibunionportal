(function() {
    'use strict';

    angular.module("app").config(['$stateProvider', '$urlRouterProvider', configureRoutes]);

    function configureRoutes($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/summary');

        $stateProvider
            .state('summary', {
                url: '/summary',
                templateUrl: 'App/Summary/summary.html',
                controller: 'summary',
                controllerAs: 'vm'
            })

            //.state('')
    }
})();