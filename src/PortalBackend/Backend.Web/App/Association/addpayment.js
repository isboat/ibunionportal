(function () {
    'use strict';

    angular.module('app.association').controller('addpayment', addpayment);

    addpayment.$inject = ['$location', '$stateParams', 'dataService', 'association'];

    function addpayment($location, $stateParams, dataService, association) {
        /* jshint validthis:true */
        var vm = this;
        vm.association = association;
        vm.add = add;

        activate();

        function activate() {

            vm.months = [
                "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul"
            ];

            var d = new Date();
            vm.years = [
                d.getFullYear() - 1, d.getFullYear(), d.getFullYear()+ 1
            ];
        }

        function add() {
            if (vm.month && vm.year) {
                dataService.addPayment(vm.month, vm.year, vm.amount, association.Id)
                    .then(function (response) {

                        if (response.data.Success) {
                            alert("save success");
                        } else {
                            alert("save error");
                        }

                    }, function() {
                        alert("error");
                    });
            }
        }
    }
})();
