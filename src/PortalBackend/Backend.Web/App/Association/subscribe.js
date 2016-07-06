(function () {
    'use strict';

    angular.module('app.association').controller('subscribe', subscribe);

    subscribe.$inject = ['$location', 'dataService', 'association'];

    function subscribe($location, dataService, association) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'subscribe';
        vm.subscribeAssoc = subscribeAssoc;

        activate();

        function activate() {

        }

        function subscribeAssoc() {
            if (vm.start && vm.end) {
                dataService.subscribeAssoc(vm.start, vm.end, association.Id)
                    .then(function (response) {

                        if (response.data.Success) {
                            alert("subscribeAssoc success");
                        } else {
                            alert("subscribeAssoc error");
                        }

                    }, function () {
                        alert("subscribeAssoc network error");
                    });
            }
        }
    }
})();
