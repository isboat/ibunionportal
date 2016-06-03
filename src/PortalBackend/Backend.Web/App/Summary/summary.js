(function () {
    'use strict';

    angular.module('app.summary').controller('summary', summary);

    summary.$inject = ['$location', 'summaryData'];

    function summary($location, summaryData) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'summary';

        if (summaryData.DemoRequests.length) {

            vm.demoreqs = summaryData.DemoRequests;
        }

        vm.associationCount = summaryData.AssociationCount;

        activate();

        function activate() {
            console.log(vm);
        }
    }
})();
