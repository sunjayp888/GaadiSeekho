(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('DrivingSchoolService', DrivingSchoolService);

    DrivingSchoolService.$inject = ['$http'];

    function DrivingSchoolService($http) {
        var service = {
            retrieveDrivingSchools: retrieveDrivingSchools,
            searchDrivingSchools: searchDrivingSchools,
            retrieveUnassignedDrivingSchoolCars: retrieveUnassignedDrivingSchoolCars,
            retrieveDrivingSchoolCars: retrieveDrivingSchoolCars,
            unassignDrivingSchoolCar: unassignDrivingSchoolCar,
            assignDrivingSchoolCar: assignDrivingSchoolCar
        };

        return service;

        function retrieveDrivingSchools(Paging, OrderBy) {
            var url = "/DrivingSchool/List",
                data = {
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };
            return $http.post(url, data);
        }

        function searchDrivingSchools(SearchKeyword, Paging, OrderBy) {
            var url = "/DrivingSchool/Search",
                data = {
                    searchKeyword: SearchKeyword,
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };

            return $http.post(url, data);
        }

        // DrivingSchoolCar

        function retrieveUnassignedDrivingSchoolCars(drivingSchoolId) {
            var url = "/DrivingSchool/UnassignedDrivingSchoolCars",
                data = {
                    drivingSchoolId: drivingSchoolId
                };

            return $http.post(url, data);
        }

        function retrieveDrivingSchoolCars(drivingSchoolId) {
            var url = "/DrivingSchool/DrivingSchoolCars",
                data = {
                    drivingSchoolId: drivingSchoolId
                };

            return $http.post(url, data);
        }

        function assignDrivingSchoolCar(drivingSchoolId, carId, withLicenseFee, withOutLicenseFee, discountOnFee) {
            var url = "/DrivingSchool/AssignDrivingSchoolCar",
                data = {
                    drivingSchoolId: drivingSchoolId,
                    carId: carId,
                    withLicenseFee: withLicenseFee,
                    withOutLicenseFee: withOutLicenseFee,
                    discountOnFee: discountOnFee
                };

            return $http.post(url, data);
        }

        function unassignDrivingSchoolCar(drivingSchoolId, carId) {
            var url = "/DrivingSchool/UnassignDrivingSchoolCar",
                data = {
                    drivingSchoolId: drivingSchoolId,
                    carId: carId
                };
            return $http.post(url, data);
        }
    }
})();