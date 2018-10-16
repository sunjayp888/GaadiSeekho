(function () {
    'use strict';

    angular
        .module('Gadi')
        .controller('DriverFeedbackController', DriverFeedbackController);

    DriverFeedbackController.$inject = ['$window', 'DriverFeedbackService', 'Paging', 'OrderService', 'OrderBy', 'Order'];

    function DriverFeedbackController($window, DriverFeedbackService, Paging, OrderService, OrderBy, Order) {
        /* jshint validthis:true */
        var vm = this;
        vm.driverFeedbacks = [];
        vm.paging = new Paging;
        vm.pageChanged = pageChanged;
        vm.orderBy = new OrderBy;
        vm.order = order;
        vm.orderClass = orderClass;
        vm.searchDriverFeedbacks = searchDriverFeedbacks;
        vm.searchKeyword = "";
        vm.searchMessage = "";
        vm.retrieveDriverFeedbacks = retrieveDriverFeedbacks;
        vm.editDriverFeedback = editDriverFeedback;
        vm.initialise = initialise;

        function initialise() {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            order("DriverFeedbackId");
        }

        function retrieveDriverFeedbacks() {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            return DriverFeedbackService.retrieveDriverFeedbacks(vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.driverFeedbacks = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.driverFeedbacks.length === 0 ? "No Records Found" : "";
                    return vm.driverFeedbacks;
                });
        }

        function searchDriverFeedbacks(searchKeyword) {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            vm.searchKeyword = searchKeyword;
            return DriverFeedbackService.searchDriverFeedback(vm.searchKeyword, vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.driverFeedbacks = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.driverFeedbacks.length === 0 ? "No Records Found" : "";
                    return vm.driverFeedbacks;
                });
        }

        function pageChanged() {
            if (vm.searchKeyword) {
                return searchDriverFeedbacks(vm.searchKeyword)();
            }
            return retrieveDriverFeedbacks();
        }

        function order(property) {
            vm.orderBy = OrderService.order(vm.orderBy, property);
            if (vm.searchKeyword) {
                return searchDriverFeedbacks(vm.searchKeyword)();
            }
            return retrieveDriverFeedbacks();
        }

        function orderClass(property) {
            return OrderService.orderClass(vm.orderBy, property);
        }

        function editDriverFeedback(driverFeedbackId) {
            $window.location.href = "/DriverFeedback/" + driverFeedbackId + "/Edit";
        }
    }
})();
