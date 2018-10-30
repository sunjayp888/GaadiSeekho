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

        function UploadPhoto(driverId, blob) {
            var formData = new FormData();
            formData.append('croppedImage', blob);

            var url = "/Driver/" + driverId + "/UploadPhoto";

            return $http.post(url, formData, {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        };

        function DeletePhoto(driverId) {
            var url = "/Driver/DeletePhoto/" + driverId;
            return $http.post(url);
        };

        function retrieveProfileImage(driverId) {
            var url = "/Driver/RetrieveProfileImage/" + driverId;
            return $http.post(url);
        }
    }
})();