(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('CarProfileService', CarProfileService);

    CarProfileService.$inject = ['$http'];

    function CarProfileService($http) {
        var service = {
            UploadPhoto: UploadPhoto,
            DeletePhoto: DeletePhoto,
            retrieveProfileImage: retrieveProfileImage
        };

        return service;

        function UploadPhoto(carId, blob) {
            var formData = new FormData();
            formData.append('croppedImage', blob);

            var url = "/Car/" + carId + "/UploadPhoto";

            return $http.post(url, formData, {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        };

        function DeletePhoto(carId) {
            var url = "/Car/DeletePhoto/" + carId;
            return $http.post(url);
        };

        function retrieveProfileImage(carId) {
            var url = "/Car/RetrieveProfileImage/" + carId;
            return $http.post(url);
        }
    }
})();