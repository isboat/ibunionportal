(function () {
    'use strict';

    angular.module('app.associations').controller('viewall', viewall);

    viewall.$inject = ['$location', 'associations'];

    function viewall($location, associations) {
        /* jshint validthis:true */

        var vm = this;
        vm.title = 'viewall';

        vm.associations = associations;
        vm.noAsso = !associations.length;

        activate();

        function activate() { }
    }
})();
