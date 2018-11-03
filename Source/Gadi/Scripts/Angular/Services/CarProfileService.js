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

        function UploadPhoto(drivingSchoolCarId, blob) {
            var formData = new FormData();
            formData.append('croppedImage', blob);

            var url = "/DrivingSchoolCar/" + drivingSchoolCarId + "/UploadPhoto";

            return $http.post(url, formData, {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        };

        function DeletePhoto(drivingSchoolCarId) {
            var url = "/DrivingSchoolCar/DeletePhoto/" + drivingSchoolCarId;
            return $http.post(url);
        };

        function retrieveProfileImage(drivingSchoolCarId) {
            var url = "/DrivingSchoolCar/RetrieveProfileImage/" + drivingSchoolCarId;
            return $http.post(url);
        }
    }
})();