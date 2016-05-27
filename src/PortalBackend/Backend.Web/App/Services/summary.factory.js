(function () {
    'use strict';

    angular.module('app.services').factory('summaryService', summary);

    summary.$inject = ['$http', '$q', 'config'];

    function summary($http, $q, config) {
        var service = {
            getData: getData
        };

        return service;

        function getData() {

            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: config.appSettings.summaryDataUrl,
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