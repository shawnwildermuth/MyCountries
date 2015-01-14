// myApp.js
(function () {

  "use strict";

  var myApp = angular.module("myApp", ["ngRoute"]);

  myApp.config(function ($routeProvider) {
    
    $routeProvider.when("/", {
      controller: "visitsController",
      controllerAs: "visits",
      templateUrl: "/Templates/MyVisits"
    });

    $routeProvider.when("/newVisit", {
      controller: "newVisitController",
      controllerAs: "newVisit",
      templateUrl: "/Templates/NewVisit"
    });

    $routeProvider.otherwise({ redirectTo: "/" });;

  });

})();