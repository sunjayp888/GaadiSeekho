(function () {
    'use strict';

    angular
        .module('Gadi')
        .controller('DrivingSchoolCarController', DrivingSchoolCarController);

    DrivingSchoolCarController.$inject = ['$window', '$filter', 'DrivingSchoolService', 'Paging', 'OrderService', 'OrderBy', 'Order'];

    function DrivingSchoolCarController($window, $filter, DrivingSchoolService, Paging, OrderService, OrderBy, Order) {
        /* jshint validthis:true */

        var vm = this;
        vm.initialise = initialise;
        vm.absencePolicyAbsenceTypes = [];
        vm.drivingSchoolCars = [];
        vm.ddCar = 0;
        vm.drivingSchoolCarCount = 0;
        vm.paging = new Paging;
        vm.pageChanged = pageChanged;
        vm.orderBy = new OrderBy;
        vm.order = order;
        vm.orderClass = orderClass;
        vm.assigning = false;
        vm.changeCar = changeCar;
        vm.retrieveUnassignedDrivingSchoolCars = retrieveUnassignedDrivingSchoolCars;
        vm.retrieveDrivingSchoolCars = retrieveDrivingSchoolCars;
        vm.unassignDrivingSchoolCar = unassignDrivingSchoolCar;
        vm.isDrivingSchoolCarAssignToDrivingSchool = isDrivingSchoolCarAssignToDrivingSchool;
        vm.unassignDrivingSchoolCarClass = unassignDrivingSchoolCarClass;
        vm.assignDrivingSchoolCar = assignDrivingSchoolCar;
        vm.editAbsencePolicyEntitlement = editAbsencePolicyEntitlement;
        vm.openAbsencePolicyEntitlementForm = openAbsencePolicyEntitlementForm;

        function initialise(drivingSchoolId) {
            vm.drivingSchoolId = drivingSchoolId;
            order("Name").then(function () {
                retrieveDrivingSchoolCars();
            });
        }

        function retrieveDrivingSchoolCars() {
            return DrivingSchoolService.retrieveDrivingSchoolCars(vm.drivingSchoolId)
                .then(function (response) {
                    vm.drivingSchoolCarError = false;
                    vm.drivingSchoolCars = response.data.Items;
                    if (vm.drivingSchoolCars.length > 0) {
                        vm.drivingSchoolCarCount = vm.drivingSchoolCars.length;

                    } else {
                        vm.drivingSchoolCarError = true;
                        vm.drivingSchoolCarCount = 0;


                    }
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                });
        }

        function retrieveUnassignedDrivingSchoolCars() {
            return DrivingSchoolService.retrieveUnassignedDrivingSchoolCars(vm.drivingSchoolId)
                .then(function (response) {
                    vm.ddCars = response.data;
                    vm.ddCar = response.data[0];
                    vm.assigning = vm.ddCars.length == 0;
                    return vm.ddCars;
                });
        }

        function editAbsencePolicyEntitlement(absencePolicyEntitlementId) {
            return DrivingSchoolService.editAbsencePolicyEntitlement(vm.drivingSchoolId, absencePolicyEntitlementId)
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

        function unassignDrivingSchoolCarClass(drivingSchoolCar) {
            return drivingSchoolCar.CanUnassign ? '' : 'link-disabled';
        }

        function unassignDrivingSchoolCar(drivingSchoolCar) {
            if (drivingSchoolCar.CanUnassign) {
                return DrivingSchoolService.unassignDrivingSchoolCar(vm.drivingSchoolId, drivingSchoolCar.CarId)
                    .then(function () {
                        initialise(vm.drivingSchoolId);
                    });
            }
        }

        function isDrivingSchoolCarAssignToDrivingSchool(carId) {
            vm.carId = carId;
            $filter('filter')(vm.drivingSchoolCars, { CarId: vm.carId })[0]["CanUnassign"] = true;
        }

        function assignDrivingSchoolCar() {
            vm.assigning = true;
            return DrivingSchoolService.assignDrivingSchoolCar(vm.drivingSchoolId, vm.ddCar.CarId, vm.withLicenseFee, vm.withOutLicenseFee, vm.discountOnFee)
                .then(function () {
                    retrieveDrivingSchoolCars();
                    retrieveUnassignedDrivingSchoolCars();
                });
        }

        function changeCar(ddCar) {
            vm.ddCar = ddCar;
        }

        function pageChanged() {
            return retrieveUnassignedDrivingSchoolCars();
        }

        function order(property) {
            vm.orderBy = OrderService.order(vm.orderBy, property);
            return retrieveUnassignedDrivingSchoolCars();
        }

        function orderClass(property) {
            return OrderService.orderClass(vm.orderBy, property);
        }

    }
})();
