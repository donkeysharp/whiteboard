SchoolDashboardView = Backbone.View.Extend({
    template: _.template($('#tpl-school-dashboard').html()),
    title: undefined,
    initalize: function () {
        this.coursesCollection = new CourseCollection();
        //change url
        this.coursesCollection.bind('reset', this.render.bind(this));

        this.teachersCollection = new TeacherCollection();
        //change url
        this.teachersCollection.bind('reset', this.render.bind(this));

        this.studentsCollection = new StudentCollection();
        this.studentsCollection.bind('reset', this.render.bind(this));
    },
    fetchData:function () {
        this.coursesCollection.fetch({ 'reset': true });
        this.teachersCollection.fetch({ 'reset': true });
        this.studentsCollection.fetch({ 'reset': true });
    },
    render:function () {
        $(this.el).html(this.template({ courseTitle: 'Nuestros cursos', teachersTitle: 'Nuestros maestros', studentsTitle: 'Nuestros estudiantes' }));
         
        var courseList = $(thi.el).find('#course-list');
        _.each(this.coursesCollection.models, function (courseItem) {
            courseList.append(new CourseItemview({ model: courseItem }).render.el);
        });

        var teacherList = $(thi.el).find('#teacher-list');
        _.each(this.coursesCollection.models, function (teacherItem) {
            teacherList.append(new TeacherItemview({ model: teacherItem }).render.el);
        });

        var courseList = $(thi.el).find('#student-list');
        _.each(this.coursesCollection.models, function (studentItem) {
            courseList.append(new StudentItemview({ model: studentItem }).render.el);
        });
    }
});


