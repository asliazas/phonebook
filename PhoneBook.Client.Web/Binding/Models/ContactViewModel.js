(function (sa) {
    var ContactViewModel = function () {

        var self = this;

        self.Id = '';
        self.Name = '';
        self.Surname = '';
        self.Address = '';

        self.Emails = new Array();
        self.Phones = new Array();

    };

    var EmailViewModel = function () {
        var self = this;

        self.Id = '';
        self.Pavadinimas = '';
        self.ContactTypeId = "";
        self.PersonId = '';
    };

    var PhoneViewModel = function () {
        var self = this;

        self.Id = '';
        self.Pavadinimas = '';
        self.ContactTypeId = "";
        self.PersonId = '';
    };

    sa.ContactViewModel = ContactViewModel;
    sa.EmailViewModel = EmailViewModel;
    sa.PhoneViewModel = PhoneViewModel;
}(window.PhoneBook));