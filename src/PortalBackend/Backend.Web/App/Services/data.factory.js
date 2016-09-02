(function () {
    'use strict';

    angular.module('app.services').factory('dataService', dataService);

    dataService.$inject = ['$http', '$q', 'config'];

    function dataService($http, $q, config) {
        var service = {
            getData: getData,
            saveDemo: saveDemo,
            saveAssociation: saveAssociation,
            addPayment: addPayment,
            subscribeAssoc: subscribeAssoc
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

        function saveDemo(demo) {
            return postData(demo, { dataUrl: config.appSettings.saveDemoUrl });
        }

        function saveAssociation(association) {
            return postData()(association, { dataUrl: config.appSettings.saveAssociationUrl });
        }

        function addPayment(month, year, amount, assocId) {
            return postData({
                Month: month,
                Year: year,
                Amount: amount,
                AssocId: assocId
            }, { dataUrl: config.appSettings.addPaymentUrl });
        }

        function subscribeAssoc(start, end, assocId) {
            return postData({
                Start: start,
                End: end,
                AssocId: assocId
            }, { dataUrl: config.appSettings.subscribeAssocUrl });
        }

        function postData(dataToPost, options) {

            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: options.dataUrl,
                data: dataToPost,
                cache: false
            }).then(
                function (response) {
                    deferred.resolve(response);
                },
                function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }
    }
})();