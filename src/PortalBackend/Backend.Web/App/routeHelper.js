(function() {
    'use strict';

    angular.module("app").config(['$stateProvider', '$urlRouterProvider', 'dataServiceProvider', configureRoutes]);

    function configureRoutes($stateProvider, $urlRouterProvider, dataServiceProvider) {
        $urlRouterProvider.otherwise('/summary');

        $stateProvider
            .state('summary', {
                url: '/summary',
                templateUrl: 'App/Summary/summary.html',
                controller: 'summary',
                controllerAs: 'vm',
                resolve: {
                    summaryData: function () {

                        return dataServiceProvider.$get().getData("summary").then(function (response) {
                            return response.data;
                        });
                    }
                }
            })
            .state('associations', {
                url: '/associations',
                templateUrl: 'App/Associations/viewall.html',
                controller: 'viewall',
                controllerAs: 'vm',
                resolve: {
                    associations: function() {
                        return dataServiceProvider.$get().getData("allassc").then(function (response) {
                            return response.data;
                        });
                    }
                }
            })
            .state('associations.add', {
                url: '/add',
                templateUrl: 'App/Associations/edit.html',
                controller: 'edit',
                controllerAs: 'vm',
                resolve: {
                    isNew: function() {
                        return true;
                    }
                }
            })
            .state('associations.edit', {
                url: '/edit/{id}',
                templateUrl: 'App/Associations/edit.html',
                controller: 'edit',
                controllerAs: 'vm',
                resolve: {
                    isNew: function() {
                        return false;
                    }
                }
            })
            .state('association', {
                url: '/association/{id}',
                templateUrl: 'App/Association/view.html',
                controller: 'view',
                controllerAs: 'vm',
                resolve: {
                    association: function ($stateParams) {
                        return dataServiceProvider.$get().getData("assoc|" + $stateParams.id).then(function(response) {
                            return response.data;
                        });
                    }
                }
            })
            .state('association.payments', {
                url: '/payments',
                templateUrl: 'App/Association/payments.html',
                controller: 'payments',
                controllerAs: 'vm',
                resolve: {
                    association: function ($stateParams) {
                        return dataServiceProvider.$get().getData("assoc|" + $stateParams.id).then(function (response) {
                            return response.data;
                        });
                    }
                }
            })
            .state('demos', {
                url: '/demos',
                templateUrl: 'App/Demos/demos.html',
                controller: 'demos',
                controllerAs: 'vm',
                resolve: {
                    demos: function() {
                        return dataServiceProvider.$get().getData("demos" ).then(function (response) {
                            return response.data;
                        });
                    }
                }
            })
            .state('demos.view', {
                url: '/view/{id}',
                templateUrl: 'App/Demos/demo.html',
                controller: 'demo',
                controllerAs: 'vm',
                resolve: {
                    demo: function ($stateParams) {
                        return dataServiceProvider.$get().getData("demo|" + $stateParams.id).then(function (response) {
                            return response.data;
                        });
                    },
                    viewOnly: function() {
                        return true;
                    }
                }
            })
            .state('demos.edit', {
                url: '/edit/{id}',
                templateUrl: 'App/Demos/demo.html',
                controller: 'demo',
                controllerAs: 'vm',
                resolve: {
                    demo: function ($stateParams) {
                        return dataServiceProvider.$get().getData("demo|" + $stateParams.id).then(function (response) {
                            return response.data;
                        });
                    },
                    viewOnly: function() {
                        return false;
                    }
                }
            })
    }
})();