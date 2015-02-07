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

    me.deleteVisit = function (id) {
      // HACK to not use a Bootstrap Dialog, will fix later
      if (confirm("Are you sure you want to delete this visit?")) {
        me.busy = true;
        me.errorMessage = "";
        visitService.deleteVisit(id)
          .then(function () {
            // NOOP
          }, function () {
            me.errorMessage = "Failed to delete the visit";
          })
          .finally(function () { me.busy = false;});
      }
    };

  });

  myApp.controller("newVisitController", function (visitService, $window) {
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
        $window.location = "#/";
      },
      function (err) {
        me.errorMessage = "Failed to add new visit";
      })
      .finally(function () {
        me.busy = false;
      });

    };

  });

  myApp.controller("editVisitController", function (visitService, $routeParams, $window) {

    var me = this;

    var visitId = $routeParams.id;
    me.theVisit = null;

    me.busy = true;
    me.errorMessage = "";

    // get the visit from the service
    visitService.getVisitById(visitId)
      .then(function (visit) {
        me.theVisit = visit;
        me.theVisit.visitDate = moment.utc(me.theVisit.visitDate).format("MM/DD/YYYY");

      }, function () {
        me.errorMessage = "Failed to find the visit.";
        $window.location = "#/";
      })
      .finally(function () {
        me.busy = false;
      });

    me.save = function () {

      me.busy = true;
      me.errorMessage = "";

      visitService.update(me.theVisit)
        .then(function () {
          $window.location = "#/";
        },
        function () {
          me.errorMessage = "Failed to update the visit";
        })
      .finally(function () {
        me.busy = false;
      });

    };
  });

})();