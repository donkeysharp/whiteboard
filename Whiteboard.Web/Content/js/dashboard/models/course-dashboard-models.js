GeneralCourse = Backbone.Model.extend({
    defaults: {
        "Id": 0,
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