SchoolDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-school-dashboard').html()),
    title: undefined,
    events:{},
    initialize: function () {
        this.coursesCollection = new CourseCollection();
        this.coursesCollection.url = '/dashboard/courses/';
        this.coursesCollection.bind('reset', this.render.bind(this));

        this.teachersCollection = new TeacherCollection();
        //change url
        this.teachersCollection.bind('reset', this.render.bind(this));

        this.studentsCollection = new StudentCollection();
        this.studentsCollection.bind('reset', this.render.bind(this));
    },
    fetchData: function () {
        this.coursesCollection.fetch({ 'reset': true });
        this.teachersCollection.fetch({ 'reset': true });
        this.studentsCollection.fetch({ 'reset': true });
    },
    render: function () {
        
        $(this.el).html(this.template({ coursesTitle: 'Nuestros cursos', teachersTitle: 'Nuestros maestros', studentsTitle: 'Nuestros estudiantes' }));

        var courseList = $(this.el).find('#course-list');
        _.each(this.coursesCollection.models, function (courseItem) {
            courseList.append(new CourseItemView({ model: courseItem }).render().el);
        });

        var teacherList = $(this.el).find('#teacher-list');
        _.each(this.teachersCollection.models, function (teacherItem) {
            teacherList.append(new TeacherItemView({ model: teacherItem }).render().el);
        });

        var courseList = $(this.el).find('#student-list');
        _.each(this.studentsCollection.models, function (studentItem) {
            courseList.append(new StudentItemView({ model: studentItem }).render().el);
        });
    }
});


