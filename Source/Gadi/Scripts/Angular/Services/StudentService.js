(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('StudentService', StudentService);

    StudentService.$inject = ['$http'];

    function StudentService($http) {
        var service = {
            retrieveStudents: retrieveStudents,
            searchStudent: searchStudent
        };

        return service;

        function retrieveStudents(Paging, OrderBy) {
            var url = "/Student/List",
                data = {
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };
            return $http.post(url, data);
        }

        function searchStudent(SearchKeyword, Paging, OrderBy) {
            var url = "/Student/Search",
                data = {
                    searchKeyword: SearchKeyword,
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };

            return $http.post(url, data);
        }
    }
})();