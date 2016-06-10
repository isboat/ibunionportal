(function () {
    'use strict';

    angular.module('app.demos').controller('demo', demo);

    demo.$inject = ['$location', 'demo', 'viewOnly', 'dataService']; 

    function demo($location, demo, viewOnly, dataService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'demo';

        vm.viewonly = viewOnly;
        vm.saveDemo = saveDemo;

        if (demo) {
            vm.demo = demo;
        }

        activate();

        function activate() { }

        function saveDemo() {
            dataService.saveDemo(vm.demo)
                .then(function (response) {
                        if (response.data.Success) {
                            alert("save success");
                        } else {
                            alert("save error");
                        }
                    },
                    function(response) {
                        alert("error");
                    });
        }
    }
})();
