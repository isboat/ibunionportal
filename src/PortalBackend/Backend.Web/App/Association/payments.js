(function () {
    'use strict';

    angular.module('app.association').controller('payments', payments);

    payments.$inject = ['$location']; 

    function payments($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'payments';
        vm.showLoading = true;
        activate();

        function activate() {

        }
    }
})();
