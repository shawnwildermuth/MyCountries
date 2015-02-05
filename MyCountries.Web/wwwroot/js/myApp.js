// myApp.js
(function () {

  "use strict";

  var myApp = angular.module("myApp", ["ngRoute", "myCountries"]);

  myApp.config(function ($routeProvider) {
    
    $routeProvider.when("/", {
      controller: "visitsController",
      controllerAs: "vm",
      templateUrl: "/Templates/MyVisits"
    });

    $routeProvider.when("/newVisit", {
      controller: "newVisitController",
      controllerAs: "vm",
      templateUrl: "/Templates/NewVisit"
    });

    $routeProvider.when("/editVisit/:id", {
      controller: "editVisitController",
      controllerAs: "vm",
      templateUrl: "/Templates/editVisit"
    });

    $routeProvider.otherwise({ redirectTo: "/" });;

  });

  myApp.filter("visitType", function () {
    return function (visit) {

      if (visit.forFun && visit.forWork) {
        return "For business and pleasure";
      } else if (visit.forFun) {
        return "For pleasure";
      } else if (visit.forWork) {
        return "For business";
      } else {
        return "Unknown visit type";
      }

    };
  });

})();