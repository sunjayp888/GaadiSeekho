(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('DriverService', DriverService);

    DriverService.$inject = ['$http'];

    function DriverService($http) {
        var service = {
            retrieveDrivers: retrieveDrivers,
            searchDriver: searchDriver
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
    }
})();