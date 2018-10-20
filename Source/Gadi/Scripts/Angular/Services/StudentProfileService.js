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

        function UploadPhoto(personnelId, blob) {
            var formData = new FormData();
            formData.append('croppedImage', blob);

            var url = "/Student/" + personnelId + "/UploadPhoto";

            return $http.post(url, formData, {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        };

        function DeletePhoto(personnelId) {
            var url = "/Student/DeletePhoto/" + personnelId;
            return $http.post(url);
        };

        function retrieveProfileImage(personnelId) {
            var url = "/Student/RetrieveProfileImage/" + personnelId;
            return $http.post(url);
        }
    }
})();