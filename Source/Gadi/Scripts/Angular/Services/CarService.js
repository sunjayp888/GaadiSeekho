(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('CarService', CarService);

    CarService.$inject = ['$http'];

    function CarService($http) {
        var service = {
            retrieveCars: retrieveCars,
            searchCar: searchCar
        };

        return service;

        function retrieveCars(Paging, OrderBy) {
            var url = "/DrivingSchoolCar/List",
                data = {
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };
            return $http.post(url, data);
        }

        function searchCar(SearchKeyword, Paging, OrderBy) {
            var url = "/DrivingSchoolCar/Search",
                data = {
                    searchKeyword: SearchKeyword,
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };

            return $http.post(url, data);
        }
    }
})();