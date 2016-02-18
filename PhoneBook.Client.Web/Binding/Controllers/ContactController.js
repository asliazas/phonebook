appMainModule.controller("ContactController", function ($scope, $http, $uibModal, viewModelHelper) {
    $scope.viewModelHelper = viewModelHelper;

    $scope.getContacts = function () {
        var filter = $scope.filterText ? '?filter=' + $scope.filterText : '';
        viewModelHelper.apiGet('api/contact/getallcontacts' + filter, null,
        function (result) {
            $scope.allContacts = result.data;
        });
    };

    $scope.addContact = function (contact) {
        viewModelHelper.apiPost('api/contact/insertcontact', contact,
            function (result) {
                $scope.getContacts();
            });
    };

    $scope.editContact = function (contact) {
        viewModelHelper.apiPost('api/contact/updatecontact', contact,
            function (result) {
                $scope.getContacts();
            });
    };

    $scope.deleteContact = function (contact) {
        viewModelHelper.apiPost('api/contact/deletecontact?id=' + contact.Id, null,
        function (result) {
            $scope.getContacts();
        });
    };

    $scope.openModal = function (contact) {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'contactModal.html',
            controller: 'ModalInstanceCtrl',
            resolve: {
                contactViewModel: function () {
                    return contact ? angular.copy(contact) : new PhoneBook.ContactViewModel();
                }
            }
        });

        modalInstance.result.then(function (contactFromModal) {
            if (contactFromModal.Id) {
                $scope.editContact(contactFromModal);
            } else {
                $scope.addContact(contactFromModal);
            }
        });
    };

    $scope.getContacts();
});

appMainModule.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, contactViewModel) {

    $scope.contactViewModel = contactViewModel;

    $scope.saveContact = function () {
        $uibModalInstance.close($scope.contactViewModel);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.addPhoneNumber = function () {
        var phone = new PhoneBook.PhoneViewModel();
        phone.ContactTypeId = '1';
        phone.PersonId = $scope.contactViewModel.Id;
        $scope.contactViewModel.Phones.push(phone);
    }

    $scope.addEmailAddress = function () {
        var email = new PhoneBook.EmailViewModel();
        email.ContactTypeId = '4';
        console.log($scope.contactViewModel);
        email.PersonId = $scope.contactViewModel.Id;
        $scope.contactViewModel.Emails.push(email);
    }

    $scope.removePhoneNumber = function (item) {
        var index = $scope.contactViewModel.Phones.indexOf(item);
        $scope.contactViewModel.Phones.splice(index, 1);
    };

    $scope.removeEmailAddress = function (item) {
        var index = $scope.contactViewModel.Emails.indexOf(item);
        $scope.contactViewModel.Emails.splice(index, 1);
    };
});