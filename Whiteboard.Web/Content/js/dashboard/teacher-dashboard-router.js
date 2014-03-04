TeacherDashboardRouter = Backbone.Router.extend({
    routes: {
        "": "teacherRouteDashboard",
        "teacherdashboard": "teacherRouteDashboard"
    },
    teacherRouteDashboard: function () {
        var el = document.getElementById('dashboard-container');
        var view = new TeacherDashboardView({ el: el });
        view.title = "Hola Mundo";
        view.fetchData();
    }
});
var router = new TeacherDashboardRouter();
Backbone.history.start();