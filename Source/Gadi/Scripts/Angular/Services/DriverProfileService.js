(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('DriverProfileService', DriverProfileService);

    DriverProfileService.$inject = ['$http'];

    function DriverProfileService($http) {
        var service = {
            UploadPhoto: UploadPhoto,
            DeletePhoto: DeletePhoto,
            retrieveProfileImage: retrieveProfileImage
        };

        return service;

        function UploadPhoto(personnelId, blob) {
            var formData = new FormData();
            formData.append('croppedImage', blob);

            var url = "/Driver/" + personnelId + "/UploadPhoto";

            return $http.post(url, formData, {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        };

        function DeletePhoto(personnelId) {
            var url = "/Driver/DeletePhoto/" + personnelId;
            return $http.post(url);
        };

        function retrieveProfileImage(personnelId) {
            var url = "/Driver/RetrieveProfileImage/" + personnelId;
            return $http.post(url);
        }
    }
})();