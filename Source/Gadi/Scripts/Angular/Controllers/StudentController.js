(function () {
    'use strict';

    angular
        .module('Gadi')
        .controller('StudentController', StudentController);

    StudentController.$inject = ['$window', 'StudentService', 'Paging', 'OrderService', 'OrderBy', 'Order'];

    function StudentController($window, StudentService, Paging, OrderService, OrderBy, Order) {
        /* jshint validthis:true */
        var vm = this;
        vm.students = [];
        vm.paging = new Paging;
        vm.pageChanged = pageChanged;
        vm.orderBy = new OrderBy;
        vm.order = order;
        vm.orderClass = orderClass;
        vm.viewPersonnelProfile = viewPersonnelProfile;
        vm.searchStudents = searchStudents;
        vm.searchKeyword = "";
        vm.searchMessage = "";
        vm.retrieveStudents = retrieveStudents;
        vm.initialise = initialise;

        function initialise() {
            order("Name");
        }

        function retrieveStudents() {
            return StudentService.retrieveStudents(vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.students = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.students.length === 0 ? "No Records Found" : "";
                    return vm.students;
                });
        }

        function searchStudents(searchKeyword) {
            vm.searchKeyword = searchKeyword;
            return StudentService.searchStudent(vm.searchKeyword, vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.students = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.students.length === 0 ? "No Records Found" : "";
                    return vm.students;
                });
        }

        function pageChanged() {
            if (vm.searchKeyword) {
                return searchStudents(vm.searchKeyword)();
            }
            return retrieveStudents();
        }

        function order(property) {
            vm.orderBy = OrderService.order(vm.orderBy, property);
            if (vm.searchKeyword) {
                return searchStudents(vm.searchKeyword)();
            }
            return retrieveStudents();
        }

        function orderClass(property) {
            return OrderService.orderClass(vm.orderBy, property);
        }

        function viewPersonnelProfile(studentId) {
            $window.location.href = "/Student/View/" + studentId;
        }

    }
})();
