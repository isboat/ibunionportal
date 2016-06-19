(function () {
    'use strict';

    angular.module('app.association').controller('view', view);

    view.$inject = ['$location', 'association'];

    function view($location, association) {
        /* jshint validthis:true */
        
        var vm = this;
        vm.title = 'view';
        vm.association = association;
        
        activate();

        function activate() {
        }
    }
})();
