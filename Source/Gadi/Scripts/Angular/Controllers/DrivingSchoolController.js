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
        vm.searchDrivingSchools = searchDrivingSchools;
        vm.searchKeyword = "";
        vm.searchMessage = "";
        vm.retrieveDrivingSchools = retrieveDrivingSchools;
        vm.editDrivingSchool = editDrivingSchool;
        vm.initialise = initialise;

        function initialise() {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            order("Name");
        }

        function retrieveDrivingSchools() {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
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
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            vm.searchKeyword = searchKeyword;
            return DrivingSchoolService.searchDrivingSchools(vm.searchKeyword, vm.paging, vm.orderBy)
              .then(function (response) {
                  vm.drivingSchools = response.data.Items;
                  vm.paging.totalPages = response.data.TotalPages;
                  vm.paging.totalResults = response.data.TotalResults;
                  vm.searchMessage = vm.drivingSchools.length === 0 ? "No Records Found" : "";
                  return vm.drivingSchools;
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

        function editDrivingSchool(drivingSchoolId) {
            $window.location.href = "/DrivingSchool/" + drivingSchoolId + "/Edit";
        }
    }
})();
