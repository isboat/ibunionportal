(function () {
    'use strict';

    angular.module('app.services').factory('dataService', dataService);

    dataService.$inject = ['$http', '$q', 'config'];

    function dataService($http, $q, config) {
        var service = {
            getData: getData
        };

        return service;

        function getData(dataKey) {

            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: config.appSettings.dataUrl,
                params: { dataKey: dataKey },
                cache: false
            }).then(
                function(response) {
                    deferred.resolve(response);
                },
                function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }
    }
})();