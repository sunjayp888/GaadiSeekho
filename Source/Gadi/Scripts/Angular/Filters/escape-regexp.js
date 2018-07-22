/**
 * @ngdoc filter
 * @name escape-regex
 * @description
 *   Escapes all regex special characters in a string
 */
(function() {
  'use strict';



  var escapeRegexpFilter = function() {
    return function(string) {
			return string.replace(/[.*+?^${}()|[\]\\]/g, '\\$&'); // $& means the whole matched string
		};
  };

  angular.module('Gadi').filter('escapeRegexp', escapeRegexpFilter);
})();
