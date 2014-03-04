TeacherDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-teacher-dashboard').html()),
    title: undefined,
    initialize: function () {
        this.collection = new CourseCollection();
        this.collection.bind('reset', this.render.bind(this));
    },
    // Descarga los datos
    fetchData: function () {
        this.collection.fetch({ reset: true });
    },
    render: function () {
        $(this.el).html(this.template({ title: this.title }));
        var courseList = $(this.el).find('#teacher-course-list');
        _.each(this.collection.models, function (courseItem) {
            courseList.append(new TeacherCourseItemView({ model: courseItem }).render().el);
        });
    }
});
TeacherCourseItemView = Backbone.View.extend({
    tagName: 'li',
    template: _.template($('#tpl-teacher-course-item').html()),
    initialize: function () { },
    render: function () {
        $(this.el).html(this.template(this.model.toJSON()));
        return this;
    }
});