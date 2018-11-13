(function () {
    'use strict';

    angular
        .module('Gadi')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$window', 'Paging', 'OrderService', 'DrivingSchoolService', 'DrivingSchoolProfileService', 'OrderBy', 'Order', '$uibModal'];

    function HomeController($window, Paging, OrderService, DrivingSchoolService, DrivingSchoolProfileService, OrderBy, Order, $uibModal) {
        /* jshint validthis:true */
        var vm = this;
        var country, state, city, pinCode, map, latitude, longitude, count, pin;
        vm.latitude;
        vm.longitude;
        vm.addPincode = addPincode;
        vm.modalInstance = null;
        vm.currentAddress;
        vm.Address = [];
        vm.pinCode;
        vm.isOtpCreated = false;
        vm.mobileNumber;
        vm.createLoginOtp = createLoginOtp;
        vm.isSeller = false;
        vm.otpMessage;
        vm.showMessage = false;
        vm.initialise = initialise;
        vm.validationError = false;
        vm.OTP;
        vm.email;
        vm.errorMessages = [];
        vm.onSellerChecked = onSellerChecked;
        vm.createForgetPasswordOtp = createForgetPasswordOtp;
        vm.customMarkers = [];
        vm.getMarkers = getMarkers;
        vm.initialise = initialise;
        vm.retrieveDrivingSchools = retrieveDrivingSchools;
        vm.drivingSchools = [];
        vm.paging = new Paging;
        vm.orderBy = new OrderBy;
        vm.viewDrivingSchool = viewDrivingSchool;
        vm.searchDrivingSchools = searchDrivingSchools;
        vm.searchKeyword = "";
        vm.searchMessage = "";
        vm.drivingSchoolData = drivingSchoolData;
        vm.retrieveProfileImage = retrieveProfileImage;
        vm.onMondayCheckedFilter = onMondayCheckedFilter;
        vm.onTuesdayCheckedFilter = onTuesdayCheckedFilter;
        vm.onWednesdayCheckedFilter = onWednesdayCheckedFilter;
        vm.onThursdayCheckedFilter = onThursdayCheckedFilter;
        vm.onFridayCheckedFilter = onFridayCheckedFilter;
        vm.onSaturdayCheckedFilter = onSaturdayCheckedFilter;
        vm.onSundayCheckedFilter = onSundayCheckedFilter;
        vm.onTwoWheelerCheckedFilter = onTwoWheelerCheckedFilter;
        vm.onFourWheelerCheckedFilter = onFourWheelerCheckedFilter;
        vm.onWithLicenseCheckedFilter = onWithLicenseCheckedFilter;
        vm.onWithoutLicenseCheckedFilter = onWithoutLicenseCheckedFilter;
        vm.onNormalCheckedFilter = onNormalCheckedFilter;
        vm.onSuvCheckedFilter = onSuvCheckedFilter;
        vm.onMuvCheckedFilter = onMuvCheckedFilter;
        vm.onXuvCheckedFilter = onXuvCheckedFilter;
        vm.onMaruti800CheckedFilter = onMaruti800CheckedFilter;
        vm.onSantroCheckedFilter = onSantroCheckedFilter;
        vm.onIndicaCheckedFilter = onIndicaCheckedFilter;
        vm.onQualisCheckedFilter = onQualisCheckedFilter;
        vm.onDrivingFeesCheckedFilter = onDrivingFeesCheckedFilter;
        function addPincode() {
            geoLocation();
        }

        function initialise(hasError, mobileNumber, email, isSeller) {
            vm.errorMessages = [];
            vm.mobileNumber = mobileNumber;
            vm.email = email;
            vm.isSeller = isSeller;
            //geoLocation();
            vm.isOtpCreated = hasError;
        }

        function openPincodeModal(location) {
            vm.modalInstance = $uibModal.open({
                size: 'sm',
                templateUrl: '/Scripts/Angular/Templates/PincodeModal.html',
                controller: ['parent', '$uibModalInstance', 'location',
                function (parent, $uibModalInstance, location) {
                    var $modal = this;
                    $modal.parent = parent;
                    $modal.modalClose = modalClose;
                    $modal.modalSubmit = modalSubmit;
                    $modal.errorMessage = null;
                    $modal.currentAddress = location == true ?
                                           vm.Address.City + ',' + vm.Address.State + ',' + vm.Address.Country + ' ' + vm.Address.PinCode : vm.Address.Error;

                    function modalClose() { $uibModalInstance.dismiss(); }
                    function modalSubmit() {
                        $("#Pincode").val(vm.Address.PinCode);
                        $uibModalInstance.dismiss();
                    }
                }],
                controllerAs: 'model',
                resolve: {
                    parent: function () { return vm; },
                    location: location
                }
            });
        }

        function geoLocation() {
            if ("geolocation" in navigator) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    vm.latitude = position.coords.latitude;
                    vm.longitude = position.coords.longitude;
                    GoogleService.getLocation(vm.latitude, vm.longitude).then(function (response) {
                        var data = response.data;
                        if (data.results.length > 0) {
                            var locationDetails = data.results[0].formatted_address;
                            var value = locationDetails.split(",");
                            count = value.length;
                            country = value[count - 1];
                            state = value[count - 2];
                            city = value[count - 3];
                            pin = state.split(" ");
                            vm.pinCode = pin[pin.length - 1];
                            state = state.replace(pinCode, ' ');
                            vm.currentAddress = locationDetails;
                            vm.Address = { City: city, State: state, Country: country, PinCode: vm.pinCode }
                        }
                        else {
                            vm.Address = { Error: "No location available for provided details." }
                        }
                    });
                });
            } else {
                console.log("Browser doesn't support geolocation!");
            }
        }

        function createCORSRequest(method, url) {
            var xhr = new XMLHttpRequest();
            if ("withCredentials" in xhr) {
                // XHR for Chrome/Firefox/Opera/Safari.
                xhr.open(method, url, true);
            } else if (typeof XDomainRequest != "undefined") {
                // XDomainRequest for IE.
                xhr = new XDomainRequest();
                xhr.open(method, url);
            } else {
                // CORS not supported.
                xhr = null;
            }
            return xhr;
        }

        function getLocationDetails() {
            var url = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + vm.latitude + "," + vm.longitude + "&sensor=true";
            var xhr = createCORSRequest('POST', url);
            if (!xhr) {
                vm.Address = { Error: "CORS not supported" }
                //openPincodeModal(false);
            }
            xhr.onload = function () {
                var data = JSON.parse(xhr.responseText);
                if (data.results.length > 0) {
                    var locationDetails = data.results[0].formatted_address;
                    var value = locationDetails.split(",");
                    count = value.length;
                    country = value[count - 1];
                    state = value[count - 2];
                    city = value[count - 3];
                    pin = state.split(" ");
                    vm.pinCode = pin[pin.length - 1];
                    state = state.replace(pinCode, ' ');
                    vm.currentAddress = locationDetails;
                    vm.Address = { City: city, State: state, Country: country, PinCode: vm.pinCode }
                    //openPincodeModal(true);
                }
                else {
                    vm.Address = { Error: "No location available for provided details." }
                    //openPincodeModal(false);
                }
            };
            xhr.onerror = function () {
                vm.Address = { Error: "Woops, there was an error making the request." }
                //openPincodeModal(false);
            };
            xhr.send();
        }

        function createLoginOtp() {
            vm.showMessage = false;
            vm.errorMessages = [];
            if (!vm.mobileNumber) vm.errorMessages.push('Enter mobile number.');
            if (!vm.email && vm.isSeller == true) vm.errorMessages.push('Enter email.');
            if (vm.errorMessages.length > 0) return;

            return OTPService.createLoginOtp(vm.mobileNumber).then(function (response) {
                vm.showMessage = true;
                vm.isOtpCreated = response.data.Succeeded;
                vm.errorMessages.push(response.data.Message);
            });
        }

        function onSellerChecked() {

        }

        function onMondayCheckedFilter() {
            if (document.getElementById('cbMonday').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsMondayFilter: true,
                    Monday: vm.monday
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsMondayFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onTuesdayCheckedFilter() {
            if (document.getElementById('cbTuesday').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsTuedayFilter: true,
                    Tuesday: vm.tuesday
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsTuedayFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onWednesdayCheckedFilter() {
            if (document.getElementById('cbWednesday').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsWednesdayFilter: true,
                    Wednesday: vm.wednesday
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsWednesdayFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onThursdayCheckedFilter() {
            if (document.getElementById('cbThursday').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsThursdayFilter: true,
                    Thursday: vm.thursday
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsThursdayFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onFridayCheckedFilter() {
            if (document.getElementById('cbFriday').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsFridayFilter: true,
                    Friday: vm.friday
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsFridayFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onSaturdayCheckedFilter() {
            if (document.getElementById('cbSaturday').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsSaturdayFilter: true,
                    Saturday: vm.saturday
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsSaturdayFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onSundayCheckedFilter() {
            if (document.getElementById('cbSunday').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsSundayFilter: true,
                    Sunday: vm.sunday
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsSundayFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onTwoWheelerCheckedFilter() {
            if (document.getElementById('cbTwoWheeler').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsTwoWheelerFilter: true,
                    TwoWheeler: vm.twoWheeler
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsTwoWheelerFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onFourWheelerCheckedFilter() {
            if (document.getElementById('cbFourWheeler').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsFourWheelerFilter: true,
                    FourWheeler: vm.fourWheeler
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsFourWheelerFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onWithLicenseCheckedFilter() {
            if (document.getElementById('cbRequired').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsWithLicenseFilter: true,
                    WithLicense: vm.withLicense
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsWithLicenseFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onWithoutLicenseCheckedFilter() {
            if (document.getElementById('cbNotRequired').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsWithoutLicenseFilter: true,
                    WithoutLicense: vm.withoutLicense
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsWithoutLicenseFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onNormalCheckedFilter() {
            if (document.getElementById('cbNormal').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsNormalFilter: true,
                    Normal: vm.normal
                }
            } else {
                vm.filter = {
                    IsFilter: true,
                    IsNormalFilter: true,
                    Normal: vm.normal
                }
            }
            retrieveDrivingSchools();
        }

        function onSuvCheckedFilter() {
            if (document.getElementById('cbSuv').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsSuvFilter: true,
                    Suv: vm.suv
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsSuvFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onMuvCheckedFilter() {
            if (document.getElementById('cbMuv').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsMuvFilter: true,
                    Muv: vm.muv
                }
            } else {
                    vm.filter = {
                        IsFilter: false,
                        IsMuvFilter: false
                    }
            }
            retrieveDrivingSchools();
        }

        function onXuvCheckedFilter() {
            if (document.getElementById('cbXuv').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsXuvFilter: true,
                    Xuv: vm.xuv
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsXuvFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onMaruti800CheckedFilter() {
            if (document.getElementById('cbMaruti800').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsMaruti800Filter: true,
                    Maruti800: vm.maruti800
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsMaruti800Filter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onSantroCheckedFilter() {
            if (document.getElementById('cbSantro').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsSantroFilter: true,
                    Santro: vm.santro
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsSantroFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onIndicaCheckedFilter() {
            if (document.getElementById('cbIndica').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsIndicaFilter: true,
                    Indica: vm.indica
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsIndicaFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onQualisCheckedFilter() {
            if (document.getElementById('cbQualis').checked) {
                vm.filter = {
                    IsFilter: true,
                    IsQualisFilter: true,
                    Qualis: vm.qualis
                }
            } else {
                vm.filter = {
                    IsFilter: false,
                    IsQualisFilter: false
                }
            }
            retrieveDrivingSchools();
        }

        function onDrivingFeesCheckedFilter() {
            //if (document.getElementById('cbSunday').checked) {
            //    vm.filter = {
            //        IsFilter: true,
            //        IsDrivingFeesFilter: true,
            //        FromFees: vm.fromFees,
            //        ToFees: vm.toFees
            //    }
            //} else {
                
            //}
            //if(vm.fromFees && vm.toFees)
            //retrieveMobiles();
        }

        function createForgetPasswordOtp(mobileNumber) {
            vm.showMessage = false;
            vm.errorMessages = [];
            if (!mobileNumber) vm.errorMessages.push('Enter mobile number.');
            if (vm.errorMessages.length > 0) return;

            return OTPService.createForgetPasswordOtp(mobileNumber).then(function (response) {
                vm.showMessage = true;
                vm.isOtpCreated = response.data.Succeeded;
                vm.errorMessages.push(response.data.Message);
            });
        }

        function getMarkers() {
            vm.customMarkers = [
                      { address: "1600 pennsylvania ave, washington DC", "class": "my1" },
                      { address: "600 pennsylvania ave, washington DC", "class": "my2" },
            ];


        }

        function drivingSchoolData(a) {
            if (a !== 1) {
                searchDrivingSchools(a);
            } else {
                retrieveDrivingSchools();
            }
        }

        function retrieveDrivingSchools() {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            vm.orderBy.property = "Name";
            return DrivingSchoolService.retrieveDrivingSchools(vm.filter,vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.drivingSchools = response.data.ResponseBody.Items;
                    vm.paging.totalPages = response.data.ResponseBody.TotalPages;
                    vm.paging.totalResults = response.data.ResponseBody.TotalResults;
                    vm.searchMessage = vm.drivingSchools.length === 0 ? "No Driving School Found" : "";
                    return vm.drivingSchools;
                });
        }

        function viewDrivingSchool(drivingSchoolId) {
            $window.location.href = "/DrivingSchool/" + drivingSchoolId + "/Detail";
        }

        function searchDrivingSchools(searchKeyword) {
            vm.searchKeyword = searchKeyword;
            $window.location.href = "/Home/DrivingSchool/" + vm.searchKeyword;
            //vm.orderBy.direction = "Ascending";
            //vm.orderBy.class = "asc";
            //vm.orderBy.property = "Name";
            //vm.searchKeyword = searchKeyword;
            //return DrivingSchoolService.searchDrivingSchools(vm.searchKeyword, vm.paging, vm.orderBy)
            //    .then(function (response) {
            //        vm.drivingSchools = response.data.Items;
            //        vm.paging.totalPages = response.data.TotalPages;
            //        vm.paging.totalResults = response.data.TotalResults;
            //        vm.searchMessage = vm.drivingSchools.length === 0 ? "No Records Found" : "";
            //        return vm.drivingSchools;
            //    });
        }

        function retrieveProfileImage() {
            return DrivingSchoolProfileService.retrieveProfileImage(personnelId)
                .then(function (response) {
                    //If response is null then default image
                    if (response.data === "")
                        document.getElementById('ProfilePicture').setAttribute('src', "");
                    else
                        document.getElementById('ProfilePicture').setAttribute('src', response.data.RelativePath);
                });
        }
    }

})();
