(function () {
    'use strict';

    angular.module('app.association').controller('payments', payments);

    payments.$inject = ['$location', '$stateParams', 'dataService', 'association'];

    function payments($location, $stateParams, dataService, association) {
        /* jshint validthis:true */

        var vm = this;
        vm.title = 'payments' + $stateParams.id;
        vm.showLoading = true;
        vm.isMonthly = association.PaymentType === 'Monthly';
        vm.association = association;
        activate();

        function activate() {

            dataService.getData("payments|" + $stateParams.id).then(function (response) {
                vm.showLoading = false;
                var result = response.data;
                
                if (result && result.Payments) {
                    vm.payments = result.Payments;

                    vm.message = vm.payments.length > 0 ? "" : "No payment information available.";
                }
            }, function () { vm.showLoading = false; vm.message = "Error getting payment details" });
        }
    }
})();
