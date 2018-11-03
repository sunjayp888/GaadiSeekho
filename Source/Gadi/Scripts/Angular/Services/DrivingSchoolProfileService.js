(function () {
    'use strict';

    angular
        .module('Gadi')
        .factory('DrivingSchoolProfileService', DrivingSchoolProfileService);

    DrivingSchoolProfileService.$inject = ['$http'];

    function DrivingSchoolProfileService($http) {
        var service = {
            UploadPhoto: UploadPhoto,
            DeletePhoto: DeletePhoto,
            retrieveProfileImage: retrieveProfileImage
        };

        return service;

        function UploadPhoto(drivingSchoolId, blob) {
            var formData = new FormData();
            formData.append('croppedImage', blob);

            var url = "/DrivingSchool/" + drivingSchoolId + "/UploadPhoto";

            return $http.post(url, formData, {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        };

        function DeletePhoto(drivingSchoolId) {
            var url = "/DrivingSchool/DeletePhoto/" + drivingSchoolId;
            return $http.post(url);
        };

        function retrieveProfileImage(drivingSchoolId) {
            var url = "/DrivingSchool/RetrieveProfileImage/" + drivingSchoolId;
            return $http.post(url);
        }
    }
})();