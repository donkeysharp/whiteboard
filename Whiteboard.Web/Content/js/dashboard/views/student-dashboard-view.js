StudentDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-student-dashboard').html()),
    title: undefined,

    events: {
    },
    initialize: function () {
        this.collection = new CourseCollection();
        this.collection.bind('reset', this.render.bind(this));
    },
    fetchData: function () {
        this.collection.fetch({ reset: true });
    },
    render: function () {
        $(this.el).html(this.template({ title: this.title }));
        var courseList = $(this.el).find('#course-list');
        _.each(this.collection.models, function (courseItem) {
            alert(courseItem.get('Title'));
            courseList.append(new CourseItemView({ model: courseItem }).render().el);
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