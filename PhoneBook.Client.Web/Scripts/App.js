
var commonModule = angular.module('common', ['ngRoute']);

// Non-SPA views will use Angular controllers created on the appMainModule.
var appMainModule = angular.module('appMain', ['common', 'ui.bootstrap', 'ui.bootstrap.tpls']);

// SPA-views will attach to their own module and use their own data-ng-app and nested controllers.
// Each MVC-delivered top-spa-level view will link its needed JS files.

// Services attached to the commonModule will be available to all other Angular modules.

commonModule.factory('viewModelHelper', function ($http, $q) {
    return PhoneBook.viewModelHelper($http, $q);
});

(function (pb) {
    var viewModelHelper = function ($http, $q) {

        var self = this;

        self.modelIsValid = true;
        self.modelErrors = [];
        self.isLoading = false;

        self.apiGet = function (uri, data, success, failure, always) {
            self.isLoading = true;
            self.modelIsValid = true;
            $http.get(PhoneBook.rootPath + uri, data)
                .then(function (result) {
                    success(result);
                    if (always != null)
                        always();
                    self.isLoading = false;
                }, function (result) {
                    if (failure == null) {
                        if (result.status != 400)
                            self.modelErrors = [result.status + ':' + result.statusText + ' - ' + result.data.Message];
                        else
                            self.modelErrors = [result.data.Message];
                        self.modelIsValid = false;
                    }
                    else
                        failure(result);
                    if (always != null)
                        always();
                    self.isLoading = false;
                });
        }

        self.apiPost = function (uri, data, success, failure, always) {
            self.isLoading = true;
            self.modelIsValid = true;
            $http.post(PhoneBook.rootPath + uri, data)
                .then(function (result) {
                    success(result);
                    if (always != null)
                        always();
                    self.isLoading = false;
                }, function (result) {
                    if (failure == null) {
                        if (result.status != 400)
                            self.modelErrors = [result.status + ':' + result.statusText + ' - ' + result.data.Message];
                        else
                            self.modelErrors = [result.data.Message];
                        self.modelIsValid = false;
                    }
                    else
                        failure(result);
                    if (always != null)
                        always();
                    isLoading = false;
                });
        }

        return this;
    }
    pb.viewModelHelper = viewModelHelper;
}(window.PhoneBook));

