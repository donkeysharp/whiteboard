CourseTeacherItemModel = Backbone.Model.extend({
    defaults: {
        "Id": 0,
        "PictureUrl": "",
        "CourseName": "",
        "Description": "",
        "NumberStudents": 0
    }
});
CourseTeacherCollection = Backbone.Collection.extend({
    url: '/dashboard/GetCoursesInformation',
    model: CourseTeacherItemModel,
    getGeneralInfo: function () {
        var courses = 0, students = 0;
        _.each(this.models, function (item) {
            courses++;
            students += item.get('NumberStudents')
        });
        return { courses: courses, students: students };
    }
});
﻿//CourseTeacherItemModel = Backbone.Model.extend({
//    defaults: {
//        "PictureUrl": "",
//        "CourseName": "",
//        "Description": ""
//    }
//});
//CourseTeacherCollection = Backbone.Collection.extend({
//    url: '/dashboard/mycourses',
//    model: CourseTeacherItemModel
//});
