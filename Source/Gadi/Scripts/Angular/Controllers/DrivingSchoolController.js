(function () {
    'use strict';

    angular
        .module('Gadi')
        .controller('DrivingSchoolController', DrivingSchoolController);

    DrivingSchoolController.$inject = ['$window', 'DrivingSchoolService', 'Paging', 'OrderService', 'OrderBy', 'Order'];

    function DrivingSchoolController($window, DrivingSchoolService,  Paging, OrderService, OrderBy, Order) {
        /* jshint validthis:true */
        var vm = this;
        vm.drivingSchools = [];
        vm.paging = new Paging;
        vm.pageChanged = pageChanged;
        vm.orderBy = new OrderBy;
        vm.order = order;
        vm.orderClass = orderClass;
        vm.viewPersonnelProfile = viewPersonnelProfile;
        vm.searchDrivingSchools = searchDrivingSchools;
        vm.searchKeyword = "";
        vm.searchMessage = "";
        vm.retrieveDrivingSchools = retrieveDrivingSchools;
        vm.initialise = initialise;

        function initialise() {
            order("Name");
        }

        function retrieveDrivingSchools() {
            return DrivingSchoolService.retrieveDrivingSchools(vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.drivingSchools = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.drivingSchools.length === 0 ? "No Records Found" : "";
                    return vm.drivingSchools;
                });
        }

        function searchDrivingSchools(searchKeyword) {
            vm.searchKeyword = searchKeyword;
            return DrivingSchoolService.searchPersonnel(vm.searchKeyword, vm.paging, vm.orderBy)
              .then(function (response) {
                  vm.personnel = response.data.Items;
                  vm.paging.totalPages = response.data.TotalPages;
                  vm.paging.totalResults = response.data.TotalResults;
                  vm.searchMessage = vm.personnel.length === 0 ? "No Records Found" : "";
                  return vm.personnel;
              });
        }

        function pageChanged() {
            if (vm.searchKeyword) {
                return searchDrivingSchools(vm.searchKeyword)();
            }
            return retrieveDrivingSchools();
        }

        function order(property) {
            vm.orderBy = OrderService.order(vm.orderBy, property);
            if (vm.searchKeyword) {
                return searchDrivingSchools(vm.searchKeyword)();
            }
            return retrieveDrivingSchools();
        }

        function orderClass(property) {
            return OrderService.orderClass(vm.orderBy, property);
        }

        function viewPersonnelProfile(personnelId) {
            $window.location.href = "/Personnel/Profile/" + personnelId;
        }

    }
})();
