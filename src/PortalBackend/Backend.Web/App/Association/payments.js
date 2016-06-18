(function () {
    'use strict';

    angular.module('app.association').controller('payments', payments);

    payments.$inject = ['$location', '$stateParams', 'dataService'];

    function payments($location, $stateParams, dataService) {
        /* jshint validthis:true */

        var vm = this;
        vm.title = 'payments' + $stateParams.id;
        vm.showLoading = true;
        activate();

        function activate() {
            dataService.getData("payments|" + $stateParams.id).then(function (response) {
                vm.showLoading = false;
                var result = response.data;
                
                if (result && result.Payments) {
                    vm.payments = result.Payments;
                }
            }, function () { vm.showLoading = false; });
        }
    }
})();
