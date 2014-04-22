SchoolDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-school-dashboard').html()),
    title: undefined,
    events:{},
    initialize: function () {
        this.coursesCollection = new CourseCollection();
        this.coursesCollection.url = '/dashboard/courses/';
        this.coursesCollection.bind('reset', this.render1.bind(this));

        this.teachersCollection = new TeacherCollection();
        //change url
        this.teachersCollection.bind('reset', this.render2.bind(this));

        this.studentsCollection = new StudentCollection();
        this.studentsCollection.bind('reset', this.render.bind(this));
    },
    // Hacky solution
    render1: function() {
        this.teachersCollection.fetch({ 'reset': true });
    },
    render2: function() {
        this.studentsCollection.fetch({ 'reset': true });
    },
    fetchData: function () {
        this.coursesCollection.fetch({ 'reset': true });
    },
    render: function () {
        
        $(this.el).html(this.template({ coursesTitle: 'Our Courses', teachersTitle: 'Our Teachers', studentsTitle: 'Our Students' }));

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


