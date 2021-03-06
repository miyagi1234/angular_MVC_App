﻿app.controller('APIController', function ($scope, APIService, $uibModal) {
    $scope.colors = ['blue','red', 'green', 'yellow'];
    getAll();
    function getAll() {
        var servCall = APIService.getSubs();
        servCall.then(function (d) {
            console.log('1234 - GOT Here :)');
            $scope.subscriber = d;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.');
        });
    }
    $scope.saveSubs = function () {
        var sub = {
            Id: $scope.Id,
            Name: $scope.first_name,
            SurName: $scope.last_name,
            BirthDate: $scope.birth_date,
            ColorPreference: $scope.color_pref,
            CoffyPreference: $scope.coffy_pref,
            TimeStamp: new Date()
        };
        console.log(sub);
        var saveSubs = APIService.saveSubscriber(sub);
        saveSubs.then(function (d) {
            console.log('what is d: ' + d.data + '');
            var message = d.data;
            if (d.data !== "" && d.data.includes("Please") === false) {
                swal("PopUp", d.data, "info");
            } else if (d.data.includes("Please")) {
                swal("PopUp", d.data, "error");
            }

            
            getAll();
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.');
        });
    };
    $scope.makeEditable = function (obj) {
        obj.target.setAttribute("contenteditable", true);
        obj.target.focus();
    };
    $scope.updSubscriber = function (sub, eve) {
        sub.MailID = eve.currentTarget.innerText;
        var upd = APIService.updateSubscriber(sub);
        upd.then(function (d) {
            getAll();
        }, function (error) {
            console.log('Oops! Something went wrong while updating the data.');
        });
    };
    $scope.dltSubscriber = function (subID) {
        var dlt = APIService.deleteSubscriber(subID);
        dlt.then(function (d) {
            getAll();
        }, function (error) {
            console.log('Oops! Something went wrong while deleting the data.')
        });
    };
});