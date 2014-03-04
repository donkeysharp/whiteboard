SchoolDashboardRouter = Backbone.Router.extend({
    routes: {
        "": "schoolRouteDashboard",
        "schoolDashboard": "schoolRouteDashboard",
        "dashboard":"schoolRouteDashboard"
    },
    schoolRouteDashboard: function () {
        var el = document.getElementById('dashboard-container');
        var view = new SchoolDashboardView({ el: el });
        view.fetchData();
    }
});
var router = new SchoolDashboardRouter();
Backbone.history.start();