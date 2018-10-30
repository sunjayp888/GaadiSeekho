(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('StudentProfileService', StudentProfileService);

    StudentProfileService.$inject = ['$http'];

    function StudentProfileService($http) {
        var service = {
            UploadPhoto: UploadPhoto,
            DeletePhoto: DeletePhoto,
            retrieveProfileImage: retrieveProfileImage
        };

        return service;

        function UploadPhoto(studentId, blob) {
            var formData = new FormData();
            formData.append('croppedImage', blob);

            var url = "/Student/" + studentId + "/UploadPhoto";

            return $http.post(url, formData, {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        };

        function DeletePhoto(studentId) {
            var url = "/Student/DeletePhoto/" + studentId;
            return $http.post(url);
        };

        function retrieveProfileImage(studentId) {
            var url = "/Student/RetrieveProfileImage/" + studentId;
            return $http.post(url);
        }
    }
})();