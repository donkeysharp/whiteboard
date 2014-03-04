StudentDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-student-dashboard').html()),
    title: undefined,

    events: {
    },
    initialize: function () {
        this.myCoursesCollection = new CourseCollection();
        this.myCoursesCollection.bind('reset', this.render.bind(this));

        this.friendsCoursesCollection = new CourseCollection();
        //change url
        //this.friendsCoursesCollection.url = '/dashboard/friendsCourses';
        this.friendsCoursesCollection.bind('reset', this.render.bind(this));

        this.sugestedCoursesCollection = new CourseCollection();
        //change url
        //this.sugestedCoursesCollection.url = '/dashboard/sugestedCourses';    
        this.sugestedCoursesCollection.bind('reset', this.render.bind(this));

    },
    fetchData: function () {
        this.myCoursesCollection.fetch({ reset: true });
        this.friendsCoursesCollection.fetch({ reset: true });
        this.sugestedCoursesCollection.fetch({ reset: true });
    },
    render: function () {
        $(this.el).html(this.template({ coursesTitle: 'Mis cursos', friendsCourseTitle:'Los cursos de tus amigos', sugestedCoursesTitle :'Sugerencias'}));

        var courseList = $(this.el).find('#course-list');
        _.each(this.myCoursesCollection.models, function (courseItem) {
            courseList.append(new CourseItemView({ model: courseItem }).render().el);
        });

        var friendcourseList = $(this.el).find('#friend-course-list');
        _.each(this.friendsCoursesCollection.models, function (courseItem) {
            friendcourseList.append(new CourseItemView({ model: courseItem }).render().el);
        });

        var sugestedcourseList = $(this.el).find('#sugested-course-list');
        _.each(this.sugestedCoursesCollection.models, function (courseItem) {
            sugestedcourseList.append(new CourseItemView({ model: courseItem }).render().el);
        });
    }
});

CourseItemView = Backbone.View.extend({
    tagName: 'li',
    template: _.template($('#tpl-course-item').html()),
    initialize: function () { },
    render: function () {
        $(this.el).html(this.template(this.model.toJSON()));
        return this;
    }
});