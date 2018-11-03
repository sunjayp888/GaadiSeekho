(function () {
    'use strict';

    angular
        .module('Gadi')
        .controller('DriverCarController', DriverCarController);

    DriverCarController.$inject = ['$window', '$filter', 'DriverService', 'Paging', 'OrderService', 'OrderBy', 'Order'];

    function DriverCarController($window, $filter, DriverService, Paging, OrderService, OrderBy, Order) {
        /* jshint validthis:true */

        var vm = this;
        vm.initialise = initialise;
        vm.absencePolicyAbsenceTypes = [];
        vm.driverCars = [];
        vm.ddCar = 0;
        vm.driverCarCount = 0;
        vm.paging = new Paging;
        vm.pageChanged = pageChanged;
        vm.orderBy = new OrderBy;
        vm.order = order;
        vm.orderClass = orderClass;
        vm.assigning = false;
        vm.changeCar = changeCar;
        vm.retrieveUnassignedDriverCars = retrieveUnassignedDriverCars;
        vm.retrieveDriverCars = retrieveDriverCars;
        vm.unassignDriverCar = unassignDriverCar;
        vm.isDriverCarAssignToDriver = isDriverCarAssignToDriver;
        vm.unassignDriverCarClass = unassignDriverCarClass;
        vm.assignDriverCar = assignDriverCar;
        vm.editAbsencePolicyEntitlement = editAbsencePolicyEntitlement;
        vm.openAbsencePolicyEntitlementForm = openAbsencePolicyEntitlementForm;

        function initialise(driverId) {
            vm.driverId = driverId;
            order("Name").then(function () {
                retrieveDriverCars();
            });
        }

        function retrieveDriverCars() {
            return DriverService.retrieveDriverCars(vm.driverId)
                .then(function (response) {
                    vm.driverCarError = false;
                    vm.driverCars = response.data.Items;
                    if (vm.driverCars.length > 0) {
                        vm.driverCarCount = vm.driverCars.length;

                    } else {
                        vm.driverCarError = true;
                        vm.driverCarCount = 0;


                    }
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                });
        }

        function retrieveUnassignedDriverCars() {
            return DriverService.retrieveUnassignedDriverCars(vm.driverId)
                .then(function (response) {
                    vm.ddCars = response.data;
                    vm.ddCar = response.data[0];
                    vm.assigning = vm.ddCars.length == 0;
                    return vm.ddCars;
                });
        }

        function editAbsencePolicyEntitlement(absencePolicyEntitlementId) {
            return DriverService.editAbsencePolicyEntitlement(vm.driverId, absencePolicyEntitlementId)
                .then(function (response) {
                    jQuery("#absencePolicyEntitlementModalBody").html(response.data);
                    $('#absencePolicyEntitlementErrorSummary').hide();
                    $("#absencePolicyEntitlementModal").modal('show');
                });
        }

        function openAbsencePolicyEntitlementForm(absencePolicyEntitlementId, absenceType) {
            vm.absenceType = absenceType;
            editAbsencePolicyEntitlement(absencePolicyEntitlementId);
        }

        function unassignDriverCarClass(driverCar) {
            return driverCar.CanUnassign ? '' : 'link-disabled';
        }

        function unassignDriverCar(driverCar) {
            if (driverCar.CanUnassign) {
                return DriverService.unassignDriverCar(vm.driverId, driverCar.DrivingSchoolCarId)
                    .then(function () {
                        initialise(vm.driverId);
                    });
            }
        }

        function isDriverCarAssignToDriver(carId) {
            vm.drivingSchoolCarId = carId;
            $filter('filter')(vm.driverCars, { DrivingSchoolCarId: vm.drivingSchoolCarId })[0]["CanUnassign"] = true;
        }

        function assignDriverCar() {
            vm.assigning = true;
            return DriverService.assignDriverCar(vm.driverId, vm.ddCar.DrivingSchoolCarId)
                .then(function () {
                    retrieveDriverCars();
                    retrieveUnassignedDriverCars();
                });
        }

        function changeCar(ddCar) {
            vm.ddCar = ddCar;
        }

        function pageChanged() {
            return retrieveUnassignedDriverCars();
        }

        function order(property) {
            vm.orderBy = OrderService.order(vm.orderBy, property);
            return retrieveUnassignedDriverCars();
        }

        function orderClass(property) {
            return OrderService.orderClass(vm.orderBy, property);
        }

    }
})();
