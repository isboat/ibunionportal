(function () {
    'use strict';

    var core = angular.module('app.core');
    
    var config = {
        appSettings : window.appSettings
    }

    core.constant("config", config);
})();