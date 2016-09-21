(function () {
    'use strict';

    angular.module('app.associations').controller('edit', edit);

    edit.$inject = ['$scope', '$location', 'isNew', 'dataService', '$stateParams'];

    function edit($scope, $location, isNew, dataService, $stateParams) {
        /* jshint validthis:true */

        var vm = this;
        vm.isNew = isNew;
        vm.assc = {};
        vm.selectedassocid;
        vm.saveAssociation = saveAssociation;
        vm.demoreqs = [];
        vm.message = '';
        activate();

        function activate() {
            if (!isNew) {
                dataService.getData("assoc|" + $stateParams.id).then(function(response) {
                    var assoc = response.data;

                    if (assoc) {
                        vm.assc.name = assoc.Name;
                        vm.assc.id = assoc.Id;
                        vm.assc.address = assoc.Address;
                        vm.assc.telephone = assoc.Telephone;
                        vm.assc.country = assoc.Country;
                        vm.assc.email = assoc.Email;
                        vm.assc.joinDate = assoc.JoinDate;
                    }
                });
            } else {
                dataService.getData("demosCompleted").then(function(response) {
                    var demos = response.data;
                    if (demos) {
                        vm.demoreqs = [];
                        for (var i = 0; i < demos.length; i++) {
                            var demo = demos[i];
                            var req = {
                                id: demo.Id,
                                name: demo.AsscName,
                                address: demo.AsscAddr,
                                country: demo.AsscCountry,
                                email: demo.Email
                            }

                            vm.demoreqs.push(req);
                        }
                    }
                });
            }
        }

        function saveAssociation() {
            console.log(vm.assc);

            if (!$scope.editAsscForm.$invalid) {

                dataService.saveAssociation(vm.assc)
                    .then(function(response) {
                            if (response && response.data && response.data.Success) {
                                vm.message = response.data.Message;
                            }
                        },
                        function(response) {
                            alert(response);
                        });
            }
        }
    }
})();
