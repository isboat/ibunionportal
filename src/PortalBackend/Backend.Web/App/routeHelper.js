(function() {
    'use strict';

    angular.module("app").config(['$stateProvider', '$urlRouterProvider', 'summaryServiceProvider', configureRoutes]);

    function configureRoutes($stateProvider, $urlRouterProvider, summaryServiceProvider) {
        $urlRouterProvider.otherwise('/summary');

        $stateProvider
            .state('summary', {
                url: '/summary',
                templateUrl: 'App/Summary/summary.html',
                controller: 'summary',
                controllerAs: 'vm',
                resolve: {
                    summaryData: function () {

                        return summaryServiceProvider.$get().getData().then(function (response) {
                            console.log(response);
                            return response.data;
                        });
                    }
                }
            })

            //.state('')
    }
})();