(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('StudentService', StudentService);

    StudentService.$inject = ['$http'];

    function StudentService($http) {
        var service = {
            retrieveStudents: retrieveStudents,
            searchStudent: searchStudent,
            createFormOneA: createFormOneA,
            updateFormOneA: updateFormOneA,
            retrieveFormOneA: retrieveFormOneA,
            createFormOneAPdf: createFormOneAPdf,
            createFormFour: createFormFour,
            updateFormFour: updateFormFour,
            retrieveFormFour: retrieveFormFour,
            createFormFourPdf: createFormFourPdf,
            createFormFive: createFormFive,
            updateFormFive: updateFormFive,
            retrieveFormFive: retrieveFormFive,
            createFormFivePdf: createFormFivePdf,
            createFormEight: createFormEight,
            updateFormEight:updateFormEight,
            retrieveFormEight: retrieveFormEight,
            createFormEightPdf: createFormEightPdf,
            createFormFourteen: createFormFourteen,
            updateFormFourteen:updateFormFourteen,
            retrieveFormFourteen: retrieveFormFourteen,
            createFormFourteenPdf: createFormFourteenPdf
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

        function createFormOneA(formOneA, drivingSchoolId, studentId) {
            var url = "/Student/CreateFormOneA",
                data = {
                    formOneA: formOneA,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function retrieveFormOneA(studentId) {
            var url = "/Student/RetrieveFormOneA",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function createFormOneAPdf(studentId) {
            var url = "/Student/FormOneADownload",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function createFormFour(formFour, drivingSchoolId, studentId) {
            var url = "/Student/CreateFormFour",
                data = {
                    formFour: formFour,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function retrieveFormFour(studentId) {
            var url = "/Student/RetrieveFormFour",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }
        
        function createFormFourPdf(studentId) {
            var url = "/Student/FormFourDownload",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function createFormFive(formFive, drivingSchoolId, studentId) {
            var url = "/Student/CreateFormFive",
                data = {
                    formFive: formFive,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function retrieveFormFive(studentId) {
            var url = "/Student/RetrieveFormFive",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function createFormFivePdf(studentId) {
            var url = "/Student/FormFiveDownload",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function createFormEight(formEight, drivingSchoolId, studentId) {
            var url = "/Student/CreateFormEight",
                data = {
                    formEight: formEight,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function retrieveFormEight(studentId) {
            var url = "/Student/RetrieveFormEight",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function createFormEightPdf(studentId) {
            var url = "/Student/FormEightDownload",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function createFormFourteen(formFourteen, drivingSchoolId, studentId) {
            var url = "/Student/CreateFormFourteen",
                data = {
                    formFourteen: formFourteen,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function retrieveFormFourteen(studentId) {
            var url = "/Student/RetrieveFormFourteen",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function createFormFourteenPdf(studentId) {
            var url = "/Student/FormFourteenDownload",
                data = {
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function updateFormOneA(formOneA, drivingSchoolId, studentId) {
            var url = "/Student/UpdateFormOneA",
                data = {
                    formOneA: formOneA,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function updateFormFour(formFour, drivingSchoolId, studentId) {
            var url = "/Student/UpdateFormFour",
                data = {
                    formFour: formFour,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function updateFormFive(formFive, drivingSchoolId, studentId) {
            var url = "/Student/UpdateFormFive",
                data = {
                    formFive: formFive,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function updateFormEight(formEight, drivingSchoolId, studentId) {
            var url = "/Student/UpdateFormEight",
                data = {
                    formEight: formEight,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }

        function updateFormFourteen(formFourteen, drivingSchoolId, studentId) {
            var url = "/Student/UpdateFormFourteen",
                data = {
                    formFourteen: formFourteen,
                    drivingSchoolId: drivingSchoolId,
                    studentId: studentId
                };
            return $http.post(url, data);
        }
    }
})();