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

  myApp.controller("newVisitController", function (visitService) {
    var me = this;

    me.newVisit = {};
    me.busy = false;
    me.errorMessage = "";

    me.save = function () {

      me.errorMessage = "";
      me.busy = true;

      visitService.add(me.newVisit)
      .then(function () {
        me.errorMessage = "Added...";
        me.newVisit = {};
      },
      function (err) {
        me.errorMessage = "Failed to add new visit";
      })
      .finally(function () {
        me.busy = false;
      });

    };

  });


})();