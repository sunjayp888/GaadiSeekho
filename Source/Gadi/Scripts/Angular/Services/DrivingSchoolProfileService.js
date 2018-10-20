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

        function UploadPhoto(personnelId, blob) {
            var formData = new FormData();
            formData.append('croppedImage', blob);

            var url = "/DrivingSchool/" + personnelId + "/UploadPhoto";

            return $http.post(url, formData, {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            });
        };

        function DeletePhoto(personnelId) {
            var url = "/DrivingSchool/DeletePhoto/" + personnelId;
            return $http.post(url);
        };

        function retrieveProfileImage(personnelId) {
            var url = "/DrivingSchool/RetrieveProfileImage/" + personnelId;
            return $http.post(url);
        }
    }
})();