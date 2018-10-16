(function () {
    'use strict';

    angular
        .module('Gadi')
        .controller('CarController', CarController);

    CarController.$inject = ['$window', 'CarService', 'Paging', 'OrderService', 'OrderBy', 'Order'];

    function CarController($window, CarService, Paging, OrderService, OrderBy, Order) {
        /* jshint validthis:true */
        var vm = this;
        vm.cars = [];
        vm.paging = new Paging;
        vm.pageChanged = pageChanged;
        vm.orderBy = new OrderBy;
        vm.order = order;
        vm.orderClass = orderClass;
        vm.searchCars = searchCars;
        vm.searchKeyword = "";
        vm.searchMessage = "";
        vm.retrieveCars = retrieveCars;
        vm.initialise = initialise;
        vm.editCar = editCar;

        function initialise() {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            order("Name");
        }

        function retrieveCars() {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            return CarService.retrieveCars(vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.cars = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.cars.length === 0 ? "No Records Found" : "";
                    return vm.cars;
                });
        }

        function searchCars(searchKeyword) {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            vm.searchKeyword = searchKeyword;
            return CarService.searchCar(vm.searchKeyword, vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.cars = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.cars.length === 0 ? "No Records Found" : "";
                    return vm.cars;
                });
        }

        function pageChanged() {
            if (vm.searchKeyword) {
                return searchCars(vm.searchKeyword)();
            }
            return retrieveCars();
        }

        function order(property) {
            vm.orderBy = OrderService.order(vm.orderBy, property);
            if (vm.searchKeyword) {
                return searchCars(vm.searchKeyword)();
            }
            return retrieveCars();
        }

        function orderClass(property) {
            return OrderService.orderClass(vm.orderBy, property);
        }

        function editCar(carId) {
            $window.location.href = "/Car/" + carId + "/Edit";
        }
    }
})();
