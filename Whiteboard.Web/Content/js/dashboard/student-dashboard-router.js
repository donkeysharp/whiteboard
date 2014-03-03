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
        "profile": "routeProfile",
        "courses": "routeCourses"
    },

    routeDashboard: function() {
        var el = document.getElementById("dashboard-container");
        var view = new StudentDashboardView({ el: el });
        view.title = 'My Courses';
        view.fetchData();
    },

    routeProfile: function () {
    },

    routeCourses: function() {
        var el = document.getElementById("dashboard-container");
        var view = new CourseDashboard();
    }
});

var router = new DashboardRouter();
Backbone.history.start();
