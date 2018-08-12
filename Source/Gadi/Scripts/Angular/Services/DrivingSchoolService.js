(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('DrivingSchoolService', DrivingSchoolService);

    DrivingSchoolService.$inject = ['$http'];

    function DrivingSchoolService($http) {
        var service = {
            retrieveDrivingSchools: retrieveDrivingSchools,
            searchPersonnel: searchPersonnel
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

        function searchPersonnel(SearchKeyword, Paging, OrderBy) {
            var url = "/Personnel/Search",
                data = {
                    searchKeyword: SearchKeyword,
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };

            return $http.post(url, data);
        }
    }
})();