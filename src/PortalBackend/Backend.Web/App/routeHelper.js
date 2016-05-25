(function() {
    'use strict';

    angular.module("app").config(['$stateProvider', '$urlRouterProvider', 'summaryService', configureRoutes]);

    function configureRoutes($stateProvider, $urlRouterProvider, summaryService) {
        $urlRouterProvider.otherwise('/summary');

        $stateProvider
            .state('summary', {
                url: '/summary',
                templateUrl: 'App/Summary/summary.html',
                controller: 'summary',
                controllerAs: 'vm',
                resolve: {
                    summaryData: function() {
                        //return summaryService.getData().then(function (response) {
                        //    console.log(response);
                        //    return response.data;
                        //});
                    }
                }
            })

            //.state('')
    }
})();