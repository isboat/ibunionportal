(function () {
    'use strict';

    angular.module('app.demos').controller('demos', demos);

    demos.$inject = ['$location', 'demos']; 

    function demos($location, demos) {
        /* jshint validthis:true */

        var vm = this;

        if (demos.Completed) {
            vm.completeddemos = demos.Completed;
        }

        if (demos.Requested) {
            vm.requesteddemos = demos.Requested;
        }

        if (demos.Scheduled) {
            vm.scheduleddemos = demos.Scheduled;
        }

        activate();

        function activate() { }
    }
})();
