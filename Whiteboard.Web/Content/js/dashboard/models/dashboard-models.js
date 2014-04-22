CourseItemModel = Backbone.Model.extend({
    defaults: {
        "Id": 0,
        "PictureUrl": "",
        "Title": "",
        "Description": ""
    }
});
TeacherItemModel = Backbone.Model.extend({
    defaults: {
        "Id": 0,
        "PictureUrl": "",
        "Name":""
    }
});
StudentItemModel = Backbone.Model.extend({
    defaults: {
        "Id": 0,
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
StudentCollection = Backbone.Collection.extend({
    url: '/dashboard/students',
    model:StudentItemModel,
});
