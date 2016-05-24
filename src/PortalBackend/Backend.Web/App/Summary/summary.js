(function () {
    'use strict';

    angular.module('app.summary').controller('summary', summary);

    summary.$inject = ['$location']; 

    function summary($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'summary';

        activate();

        function activate() {
            console.log(("summary controller"));
        }
    }
})();
