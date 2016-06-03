(function() {
    'use strict';

    angular.module("app", [
        "ui.router",
        "app.core",
        "app.summary",
        "app.associations",
        "app.demos",

        "app.services"
    ]);
})();