CourseItemView = Backbone.View.extend({
    tagName: 'li',
    template: _.template($('#tpl-course-item').html()),
    initialize: function () { },
    render: function () {
        $(this.el).html(this.template(this.model.toJSON()));
        return this;
    }
});
TeacherItemView = Backbone.View.extend({

    tagName: 'li',
    template: _.template($('#tpl-teacher-item').html()),
    initialize: function () { },
    render: function () {
        $(this.el).html(this.template(this.model.toJSON()));
        return this;
    }
});

StudentItemView = Backbone.View.extend({
    tagName: 'li',
    template: _.template($('#tpl-student-item').html()),
    initialize: function () { },
    render: function () {
        $(this.el).html(this.template(this.model.toJSON()));
        return this;
    }
});