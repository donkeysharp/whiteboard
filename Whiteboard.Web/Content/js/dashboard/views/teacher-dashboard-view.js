TeacherDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-teacher-dashboard').html()),
    title: undefined,
    initialize: function () {
        this.collection = new CourseTeacherCollection();
        this.collection.bind('reset', this.render.bind(this));
    },
    fetchData: function () {
        this.collection.fetch({ reset: true });
    },
    render: function () {
        var coursesInformation = this.collection.getGeneralInfo();
        $(this.el).html(this.template({ title: this.title, courses: coursesInformation.courses, students: coursesInformation.students }));
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