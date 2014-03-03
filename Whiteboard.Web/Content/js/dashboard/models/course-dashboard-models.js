GeneralCourse = Backbone.Model.extend({
    defaults: {
        "Title": undefined,
        "Description": undefined,
        "PictureUrl": undefined,
        "Teacher": undefined
    }
});

GeneralCourseCollection = Backbone.Collection.extend({
    url: '/dashboard/listcourses',
    model: GeneralCourse
});