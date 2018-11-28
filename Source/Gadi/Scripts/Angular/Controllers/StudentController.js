(function () {
    'use strict';

    angular
        .module('Gadi')
        .controller('StudentController', StudentController);

    StudentController.$inject = ['$window', 'StudentService', 'Paging', 'OrderService', 'OrderBy', 'Order'];

    function StudentController($window, StudentService, Paging, OrderService, OrderBy, Order) {
        /* jshint validthis:true */
        var vm = this;
        vm.students = [];
        vm.studentFormFour = [];
        vm.studentFormFive = [];
        vm.studentFormEight = [];
        vm.studentFormFourteen = [];
        vm.studentFormOneA = [];
        vm.studentQuestionResponse = [];
        vm.paging = new Paging;
        vm.pageChanged = pageChanged;
        vm.orderBy = new OrderBy;
        vm.order = order;
        vm.orderClass = orderClass;
        vm.viewPersonnelProfile = viewPersonnelProfile;
        vm.searchStudents = searchStudents;
        vm.searchKeyword = "";
        vm.searchMessage = "";
        vm.retrieveStudents = retrieveStudents;
        vm.initialise = initialise;
        vm.editStudent = editStudent;
        vm.onLMVNTChecked = onLMVNTChecked;
        vm.onMCWGChecked = onMCWGChecked;
        vm.onMCWOGChecked = onMCWOGChecked;
        vm.onLMVTRChecked = onLMVTRChecked;
        vm.onARTRChecked = onARTRChecked;
        vm.onARNTChecked = onARNTChecked;
        vm.durationOfStayAtPresentAddress;
        vm.migratedToIndia;
        vm.LMVNT = false;
        vm.MCWG = false;
        vm.MCWOG = false;
        vm.LMVTR = false;
        vm.ARTR = false;
        vm.ARNT = false;
        vm.createFormFour = createFormFour;
        vm.updateFormFour = updateFormFour;
        vm.retrieveFormFour = retrieveFormFour;
        vm.createFormFourPdf = createFormFourPdf;
        vm.enrollmentDateFormFive;
        vm.enrollmentNumber;
        vm.startDateFormFive;
        vm.endDateFormFive;
        vm.createFormFive = createFormFive;
        vm.updateFormFive = updateFormFive;
        vm.retrieveFormFive = retrieveFormFive;
        vm.createFormFivePdf = createFormFivePdf;
        vm.testedAndPassedOn;
        vm.mDLNo;
        vm.mDLFor;
        vm.validUpto;
        vm.age;
        vm.recommendedMDLNo;
        vm.toEndrossmentFor;
        vm.paidFee;
        vm.createFormEight = createFormEight;
        vm.updateFormEight = updateFormEight;
        vm.retrieveFormEight = retrieveFormEight;
        vm.createFormEightPdf = createFormEightPdf;
        vm.enrollmentNumberFormFourteen;
        vm.classOfVehical;
        vm.enrollmentDateFormFourteen;
        vm.lLRNumber;
        vm.enquiryDate;
        vm.passingDate;
        vm.drivingLicenseNumber;
        vm.issueDate;
        vm.rNumber;
        vm.inwardNumber;
        vm.createFormFourteen = createFormFourteen;
        vm.updateFormFourteen = updateFormFourteen;
        vm.retrieveFormFourteen = retrieveFormFourteen;
        vm.createFormFourteenPdf = createFormFourteenPdf;
        vm.identificationMarks1;
        vm.identificationMarks2;
        vm.createFormOneA = createFormOneA;
        vm.updateFormOneA = updateFormOneA;
        vm.retrieveFormOneA = retrieveFormOneA;
        vm.createFormOneAPdf = createFormOneAPdf;


        function initialise() {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            order("StudentId");
        }

        function retrieveStudents() {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            return StudentService.retrieveStudents(vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.students = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.students.length === 0 ? "No Records Found" : "";
                    return vm.students;
                });
        }

        function searchStudents(searchKeyword) {
            vm.orderBy.direction = "Ascending";
            vm.orderBy.class = "asc";
            vm.searchKeyword = searchKeyword;
            return StudentService.searchStudent(vm.searchKeyword, vm.paging, vm.orderBy)
                .then(function (response) {
                    vm.students = response.data.Items;
                    vm.paging.totalPages = response.data.TotalPages;
                    vm.paging.totalResults = response.data.TotalResults;
                    vm.searchMessage = vm.students.length === 0 ? "No Records Found" : "";
                    return vm.students;
                });
        }

        function pageChanged() {
            if (vm.searchKeyword) {
                return searchStudents(vm.searchKeyword)();
            }
            return retrieveStudents();
        }

        function order(property) {
            vm.orderBy = OrderService.order(vm.orderBy, property);
            if (vm.searchKeyword) {
                return searchStudents(vm.searchKeyword)();
            }
            return retrieveStudents();
        }

        function orderClass(property) {
            return OrderService.orderClass(vm.orderBy, property);
        }

        function viewPersonnelProfile(studentId) {
            $window.location.href = "/Student/View/" + studentId;
        }

        function editStudent(studentId) {
            $window.location.href = "/Student/" + studentId + "/Edit";
        }

        // Form 4 Checkbox

        function onLMVNTChecked() {
            if (document.getElementById('cbLMVNT').checked) {
                vm.LMVNT = true;
            } else {
                vm.LMVNT = false;
            }
        }

        function onMCWGChecked() {
            if (document.getElementById('cbMCWG').checked) {
                vm.MCWG = true;
            } else {
                vm.MCWG = false;
            }
        }

        function onMCWOGChecked() {
            if (document.getElementById('cbMCWOG').checked) {
                vm.MCWOG = true;
            } else {
                vm.MCWOG = false;
            }
        }

        function onLMVTRChecked() {
            if (document.getElementById('cbLMVTR').checked) {
                vm.LMVTR = true;
            } else {
                vm.LMVTR = false;
            }
        }

        function onARTRChecked() {
            if (document.getElementById('cbARTR').checked) {
                vm.ARTR = true;
            } else {
                vm.ARTR = false;
            }
        }

        function onARNTChecked() {
            if (document.getElementById('cbARNT').checked) {
                vm.ARNT = true;
            } else {
                vm.ARNT = false;
            }
        }

        function createFormOneA(drivingSchoolId, studentId) {
            var formOneA = {
                IdentificationMarks1: vm.identificationMarks1,
                IdentificationMarks2: vm.identificationMarks2
            }
            return StudentService.createFormOneA(formOneA, drivingSchoolId, studentId);
        }

        function createFormFour(drivingSchoolId, studentId) {
            var formFour = {
                IsLMVNT: vm.LMVNT,
                IsMCWG: vm.MCWG,
                IsMCWOG: vm.MCWOG,
                IsLMVTR: vm.LMVTR,
                IsARTR: vm.ARTR,
                IsARNT: vm.ARNT,
                DurationOfStayAtPresentAddress: vm.durationOfStayAtPresentAddress,
                MigratedToIndia: vm.migratedToIndia
            }
            return StudentService.createFormFour(formFour, drivingSchoolId, studentId);
        }

        function createFormFive(drivingSchoolId, studentId) {
            var formFive = {
                EnrollmentDate: vm.enrollmentDateFormFive._d,
                EnrollmentNumber: vm.enrollmentNumber,
                StartDate: vm.startDateFormFive._d,
                EndDate: vm.endDateFormFive._d
            }
            return StudentService.createFormFive(formFive, drivingSchoolId, studentId);
        }

        function createFormEight(drivingSchoolId, studentId) {
            var formEight = {
                TestedAndPassedOn: vm.testedAndPassedOn,
                MDLNo: vm.mDLNo,
                MDLFor: vm.mDLFor,
                ValidUpto: vm.validUpto,
                Age: vm.age,
                RecommendedMDLNo: vm.recommendedMDLNo,
                ToEndrossmentFor: vm.toEndrossmentFor,
                PaidFee: vm.paidFee
            }
            return StudentService.createFormEight(formEight, drivingSchoolId, studentId);
        }

        function createFormFourteen(drivingSchoolId, studentId) {
            var formFourteen = {
                EnrollmentNumber: vm.enrollmentNumberFormFourteen,
                ClassOfVehical: vm.classOfVehical,
                EnrollmentDate: vm.enrollmentDateFormFourteen,
                LLRNumber: vm.lLRNumber,
                EnquiryDate: vm.enquiryDate,
                PassingDate: vm.passingDate,
                DrivingLicenseNumber: vm.drivingLicenseNumber,
                IssueDate: vm.issueDate,
                RNumber: vm.rNumber,
                InwardNumber: vm.inwardNumber
            }
            return StudentService.createFormFourteen(formFourteen, drivingSchoolId, studentId);
        }
        
        function retrieveFormOneA(studentId) {
            return StudentService.retrieveFormOneA(studentId)
                .then(function (response) {
                    vm.studentFormOneA = response.data;
                    vm.identificationMarks1 = vm.studentFormOneA.IdentificationMarks1;
                    vm.identificationMarks2 = vm.studentFormOneA.IdentificationMarks2;
                    return vm.studentFormFour;
                });
        }

        function retrieveFormFour(studentId) {
            return StudentService.retrieveFormFour(studentId)
            .then(function (response) {
                vm.studentFormFour = response.data;
                vm.LMVNT = vm.studentFormFour.IsLMVNT;
                vm.MCWG = vm.studentFormFour.IsMCWG;
                vm.MCWOG = vm.studentFormFour.IsMCWOG;
                vm.LMVTR = vm.studentFormFour.IsLMVTR;
                vm.ARTR = vm.studentFormFour.IsARTR;
                vm.ARNT = vm.studentFormFour.IsARNT;
                vm.durationOfStayAtPresentAddress = vm.studentFormFour.DurationOfStayAtPresentAddress;
                vm.migratedToIndia = vm.studentFormFour.MigratedToIndia;
                return vm.studentFormFour;
            });
        }

        function retrieveFormFive(studentId) {
            return StudentService.retrieveFormFive(studentId)
                .then(function (response) {
                    vm.studentFormFive = response.data;
                    vm.enrollmentDateFormFive = vm.studentFormFive.EnrollmentDate;
                    vm.enrollmentNumber = vm.studentFormFive.EnrollmentNumber;
                    vm.startDate = vm.studentFormFive.StartDate;
                    vm.endDate = vm.studentFormFive.EndDate;
                    return vm.studentFormFive;
                });
        }

        function retrieveFormEight(studentId) {
            return StudentService.retrieveFormEight(studentId)
                .then(function (response) {
                    vm.studentFormEight = response.data;
                    vm.testedAndPassedOn = vm.studentFormEight.TestedAndPassedOn;
                    vm.mDLNo = vm.studentFormEight.MDLNo;
                    vm.mDLFor = vm.studentFormEight.MDLFor;
                    vm.validUpto = vm.studentFormEight.ValidUpto;
                    vm.age = vm.studentFormEight.Age;
                    vm.recommendedMDLNo = vm.studentFormEight.RecommendedMDLNo;
                    vm.toEndrossmentFor = vm.studentFormEight.ToEndrossmentFor;
                    vm.paidFee = vm.studentFormEight.PaidFee;
                    return vm.studentFormEight;
                });
        }

        function retrieveFormFourteen(studentId) {
            return StudentService.retrieveFormFourteen(studentId)
                .then(function (response) {
                    vm.studentFormFourteen = response.data;
                    vm.enrollmentNumberFormFourteen = vm.studentFormFourteen.EnrollmentNumber;
                    vm.classOfVehical = vm.studentFormFourteen.ClassOfVehical;
                    vm.enrollmentDateFormFourteen = vm.studentFormFourteen.EnrollmentDate;
                    vm.lLRNumber = vm.studentFormFourteen.LLRNumber;
                    vm.enquiryDate = vm.studentFormFourteen.EnquiryDate;
                    vm.passingDate = vm.studentFormFourteen.PassingDate;
                    vm.drivingLicenseNumber = vm.studentFormFourteen.DrivingLicenseNumber;
                    vm.issueDate = vm.studentFormFourteen.IssueDate;
                    vm.rNumber = vm.studentFormFourteen.RNumber;
                    vm.inwardNumber = vm.studentFormFourteen.InwardNumber;
                    return vm.studentFormFourteen;
                });
        } 

        function createFormOneAPdf(studentId) {
            return StudentService.createFormOneAPdf(studentId);
        }

        function createFormFourPdf(studentId) {
            return StudentService.createFormFourPdf(studentId);
        }

        function createFormFivePdf(studentId) {
            return StudentService.createFormFivePdf(studentId);
        }

        function createFormEightPdf(studentId) {
            return StudentService.createFormEightPdf(studentId);
        }

        function createFormFourteenPdf(studentId) {
            return StudentService.createFormFourteenPdf(studentId);
        }

        function updateFormOneA(drivingSchoolId, studentId) {
            vm.studentFormOneA.IsLMVNT = vm.LMVNT;
            vm.studentFormOneA.IsMCWG = vm.MCWG;
            return StudentService.updateFormOneA(vm.studentFormOneA, drivingSchoolId, studentId).then(function (response) {
                var alertMessage = response.data ? "Form 1A Updated Successfully" : "Error";
                alert(alertMessage);
                retrieveFormOneA(studentId);
            });
        }

        function updateFormFour(drivingSchoolId, studentId) {
            vm.studentFormFour.IsLMVNT = vm.LMVNT;
            vm.studentFormFour.IsMCWG = vm.MCWG;
            vm.studentFormFour.IsMCWOG = vm.MCWOG;
            vm.studentFormFour.IsLMVTR = vm.LMVTR;
            vm.studentFormFour.IsARTR = vm.ARTR;
            vm.studentFormFour.IsARNT = vm.ARNT;
            vm.studentFormFour.DurationOfStayAtPresentAddress = vm.durationOfStayAtPresentAddress;
            vm.studentFormFour.MigratedToIndia = vm.migratedToIndia;
            return StudentService.updateFormFour(vm.studentFormFour, drivingSchoolId, studentId).then(function (response) {
                var alertMessage = response.data ? "Form 4 Updated Successfully" : "Error";
                alert(alertMessage);
                retrieveFormFour(studentId);
            });
        }

        function updateFormFive(drivingSchoolId, studentId) {
            vm.studentFormFive.EnrollmentDate = vm.enrollmentDateFormFive._d;
            vm.studentFormFive.EnrollmentNumber = vm.enrollmentNumber;
            vm.studentFormFive.StartDate = vm.startDateFormFive._d;
            vm.studentFormFive.EndDate = vm.endDateFormFive._d;
            return StudentService.updateFormFive(vm.studentFormFive, drivingSchoolId, studentId).then(function (response) {
                retrieveFormFive(studentId);
            });
        }

        function updateFormEight(drivingSchoolId, studentId) {
            vm.studentFormEight.TestedAndPassedOn = vm.testedAndPassedOn;
            vm.studentFormEight.MDLNo = vm.mDLNo;
            vm.studentFormEight.MDLFor = vm.mDLFor;
            vm.studentFormEight.ValidUpto = vm.validUpto;
            vm.studentFormEight.Age = vm.age;
            vm.studentFormEight.RecommendedMDLNo = vm.recommendedMDLNo;
            vm.studentFormEight.ToEndrossmentFor = vm.toEndrossmentFor;
            vm.studentFormEight.PaidFee = vm.paidFee;
            return StudentService.updateFormEight(vm.studentFormEight, drivingSchoolId, studentId).then(function (response) {
                retrieveFormEight(studentId);
            });
        }

        function updateFormFourteen(drivingSchoolId, studentId) {
            vm.studentFormFourteen.EnrollmentNumber = vm.enrollmentNumberFormFourteen;
            vm.studentFormFourteen.ClassOfVehical = vm.classOfVehical;
            vm.studentFormFourteen.EnrollmentDate = vm.enrollmentDateFormFourteen;
            vm.studentFormFourteen.LLRNumber = vm.lLRNumber;
            vm.studentFormFourteen.EnquiryDate = vm.enquiryDate;
            vm.studentFormFourteen.PassingDate = vm.passingDate;
            vm.studentFormFourteen.DrivingLicenseNumber = vm.drivingLicenseNumber;
            vm.studentFormFourteen.IssueDate = vm.issueDate;
            vm.studentFormFourteen.RNumber = vm.rNumber;
            vm.studentFormFourteen.InwardNumber = vm.inwardNumber;
            return StudentService.updateFormFourteen(vm.studentFormFourteen, drivingSchoolId, studentId).then(function (response) {
                retrieveFormFourteen(studentId);
            });
        }
    }
})();
