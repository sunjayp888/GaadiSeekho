(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('DriverFeedbackService', DriverFeedbackService);

    DriverFeedbackService.$inject = ['$http'];

    function DriverFeedbackService($http) {
        var service = {
            retrieveDriverFeedbacks: retrieveDriverFeedbacks,
            searchDriverFeedback: searchDriverFeedback
        };

        return service;

        function retrieveDriverFeedbacks(Paging, OrderBy) {
            var url = "/DriverFeedback/List",
                data = {
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };
            return $http.post(url, data);
        }

        function searchDriverFeedback(SearchKeyword, Paging, OrderBy) {
            var url = "/DriverFeedback/Search",
                data = {
                    searchKeyword: SearchKeyword,
                    paging: Paging,
                    orderBy: new Array(OrderBy)
                };

            return $http.post(url, data);
        }
    }
})();