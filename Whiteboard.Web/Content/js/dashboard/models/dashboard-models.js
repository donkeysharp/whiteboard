CourseItemModel = Backbone.Model.extend({
    defaults: {
        "PictureUrl": "",
        "CourseName": "",
        "Description": ""
    }
});
TeacherItemModel = Backbone.Model.extend({
    defaults: {
        "PictureUrl": "",
        "Name":""
    }
});
StudentItemModel = Backbone.Model.extend({
    defaults: {
        "PictureUrl": "",
        "Name": ""
    }
});
CourseCollection = Backbone.Collection.extend({
    url: '/dashboard/mycourses',
    model: CourseItemModel,
});
TeacherCollection = Backbone.Collection.extend({
    url: '/dashboard/teachers',
    model: TeacherItemModel,
});
