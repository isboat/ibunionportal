(function () {
    'use strict';

    angular.module('app.association').controller('subscription', subscription);

    subscription.$inject = ['$location', 'dataService', 'association']; 

    function subscription($location, dataService, association) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'subscription';
        vm.association = association;

        activate();

        function activate() {

            dataService.getData("subscription|" + $stateParams.id).then(function (response) {
                vm.showLoading = false;
                var result = response.data;

                if (result && result.Subscription) {
                    vm.subscription = result.Subscription;

                    vm.message = vm.subscription.length > 0 ? "" : "No subscription information available."
                }
            }, function () { vm.showLoading = false; vm.message = "Error getting subscription details" });
        }
    }
})();
