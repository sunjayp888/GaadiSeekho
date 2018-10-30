(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('DriverService', DriverService);

    DriverService.$inject = ['$http'];

    function DriverService($http) {
        var service = {
            retrieveDrivers: retrieveDrivers,
            searchDriver: searchDriver,
            retrieveUnassignedDriverCars: retrieveUnassignedDriverCars,
            retrieveDriverCars: retrieveDriverCars,
            unassignDriverCar: unassignDriverCar,
            assignDriverCar: assignDriverCar
        };

        return service;

        function retrieveDrivers(Paging, OrderBy) {
            var url = "/Driver/List",
                data = {
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };
            return $http.post(url, data);
        }

        function searchDriver(SearchKeyword, Paging, OrderBy) {
            var url = "/Driver/Search",
                data = {
                    searchKeyword: SearchKeyword,
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };

            return $http.post(url, data);
        }

        // DriverCar

        function retrieveUnassignedDriverCars(driverId) {
            var url = "/Driver/UnassignedDriverCars",
                data = {
                    driverId: driverId
                };

            return $http.post(url, data);
        }

        function retrieveDriverCars(driverId) {
            var url = "/Driver/DriverCars",
                data = {
                    driverId: driverId
                };

            return $http.post(url, data);
        }

        function assignDriverCar(driverId, carId) {
            var url = "/Driver/AssignDriverCar",
                data = {
                    driverId: driverId,
                    carId: carId
                };

            return $http.post(url, data);
        }

        function unassignDriverCar(driverId, carId) {
            var url = "/Driver/UnassignDriverCar",
                data = {
                    driverId: driverId,
                    carId: carId
                };
            return $http.post(url, data);
        }
    }
})();