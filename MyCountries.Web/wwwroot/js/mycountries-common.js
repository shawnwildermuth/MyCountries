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

    var _getVisitById = function (visitId) {

      var deferred = $q.defer();

      // Load if necessary
      if (!_loaded) {
        _load()
          .then(function () {
            resolveGetVisit(deferred, visitId);
          },
          function () {
            deferred.reject("Failed to load visits");
          });
      } else {
        resolveGetVisit(deferred, visitId);
      }

      return deferred.promise;

    };

    // localize the resolution of the get visit to not dup code
    function resolveGetVisit(deferred, visitId) {
      var found = _.find(_visits, function (item) {
        return item.id == visitId;
      });

      if (found) {
        deferred.resolve(found);
      } else {
        deferred.reject();
      }
    }

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

    var _update = function (visit) {

      var deferred = $q.defer();

      $http.put(_baseUrl + "/" + visit.id, visit)
        .then(function (response) {
          deferred.resolve();
        },
        function () {
          deferred.reject("Failed to update new visit");
        });

      return deferred.promise;

    };

    var _deleteVisit = function (visitOrVisitId) {

      var deferred = $q.defer();

      if (Number.isInteger(visitOrVisitId)) {
        _getVisitById(visitOrVisitId).
         then(function (found) {
           deleteActualVisit(found, deferred);
         }, function () {
           deferred.reject("Failed to find the visit");
         })
      } else {
        deleteActualVisit(visitOrVisitId, deferred);
      }

      return deferred.promise;
    };

    function deleteActualVisit(visit, deferred) {
      $http.delete(_baseUrl + "/" + visit.id)
        .then(function (success) {
          var index = _.indexOf(visit);
          _visits.splice(index, 1);
          deferred.resolve();
        }, function () {
          deferred.reject();
        });
    }

    return {
      visits: _visits,
      load: _load,
      add: _add,
      getVisitById: _getVisitById,
      update: _update,
      deleteVisit: _deleteVisit
    };

  });


})();