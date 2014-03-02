window.Whiteboard = {
    "Routes": undefined,
    "Models": undefined,
    "Collections": undefined,
    "Views": undefined
};

DashboardRouter = Backbone.Router.extend({
    routes: {
        "": "routeDashboard",
        "dashboard": "routeDashboard",
        "profile": "routeProfile"
    },

    routeDashboard: function() {
        var el1 = document.getElementById("render-here");
        var view = new StudentDashboardView({ el: el1 });
        view.render();
    },
    routeProfile: function () {
        alert("asd");
    }
});

var router = new DashboardRouter();
Backbone.history.start();
