SchoolDashboardView = Backbone.View.Extend({
    template: _.template($('#tpl-school-dashboard').html()),
    title: undefined,
    initalize: function () {
        this.coursesCollection = new CourseCollection();
        //change url
        this.coursesCollection.bind('reset', this.render.bind(this));

        //this.teachersCollection=new 
    }
});