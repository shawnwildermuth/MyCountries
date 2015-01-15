// myApp-controllers.js
(function () {

  "use strict";

  var myApp = angular.module("myApp");

  myApp.controller("visitsController", function (visitService) {
    var me = this;

    me.visits = visitService.visits;
    me.busy = true;
    me.errorMessage = "";

    visitService.load()
      .then(function () {
        // Noop
      }, function (err) {
        me.errorMessage = err;
      })
      .finally(function () {
        me.busy = false;
      });

  });

  myApp.controller("newVisitController", function () {
    var me = this;

    me.save = function () {



    };

  });


})();