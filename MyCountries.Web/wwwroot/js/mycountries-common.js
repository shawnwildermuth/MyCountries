// mycountries-common.js
(function () {

  "use strict";

  var app = angular.module("myCountries", []);

  app.factory("visitService", function ($http, $q) {

    var _loaded = false;
    var _visits = [];
    var _baseUrl = "/api/visits";

    var _add = function (newVisit) {

      var deferred = $q.defer();

      $http.post(_baseUrl, newVisit)
        .then(function (response) {
          if (_loaded) {
            _visits.push(response.data);
          }
          deferred.resolve();
        },
        function () {
          deferred.reject("Failed to save new visit");
        });

      return deferred.promise;

    };

    var _load = function () {

      var deferred = $q.defer();

      $http.get(_baseUrl)
        .then(function (response) {
          _loaded = true;
          angular.copy(response.data, _visits);
          deferred.resolve();
        },
        function () {
          deferred.reject("Failed to load visits");
        });

      return deferred.promise;

    };

    return {
      visits: _visits,
      load: _load,
      add: _add
    };

  });


})();