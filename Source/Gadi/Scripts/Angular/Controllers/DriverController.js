(function () {
    'use strict';

    angular
        .module('Gadi')
        .controller('DriverController', DriverController);

    DriverController.$inject = ['$window', 'DriverService', 'Paging', 'OrderService', 'OrderBy', 'Order'];

    function DriverController($window, DriverService, Paging, OrderService, OrderBy, Order) {
        /* jshint validthis:true */
        var vm = this;
        vm.drivers = [];
        vm.paging = new Paging;
        vm.pageChanged = pageChanged;
        vm.orderBy = new OrderBy;
        vm.order = order;
        vm.orderClass = orderClass;
        vm.viewPersonnelProfile = viewPersonnelProfile;
        vm.searchDrivers = searchDrivers;
        vm.searchKeyword = "";
        vm.searchMessage = "";
        vm.retrieveDrivers = retrieveDrivers;
        vm.initialise = initialise;

        function initialise() {
            order("Name");
        }

        function retrieveDrivers() {
            return DriverService.retrieveDrivers(vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.drivers = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.drivers.length === 0 ? "No Records Found" : "";
                    return vm.drivers;
                });
        }

        function searchDrivers(searchKeyword) {
            vm.searchKeyword = searchKeyword;
            return DriverService.searchDriver(vm.searchKeyword, vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.drivers = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.drivers.length === 0 ? "No Records Found" : "";
                    return vm.drivers;
                });
        }

        function pageChanged() {
            if (vm.searchKeyword) {
                return searchDrivers(vm.searchKeyword)();
            }
            return retrieveDrivers();
        }

        function order(property) {
            vm.orderBy = OrderService.order(vm.orderBy, property);
            if (vm.searchKeyword) {
                return searchDrivers(vm.searchKeyword)();
            }
            return retrieveDrivers();
        }

        function orderClass(property) {
            return OrderService.orderClass(vm.orderBy, property);
        }

        function viewPersonnelProfile(driverId) {
            $window.location.href = "/Driver/View/" + driverId;
        }

    }
})();
