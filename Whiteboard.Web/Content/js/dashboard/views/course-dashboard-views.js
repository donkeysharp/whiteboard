CourseDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-course-search').html()),
    events: {
        'change #search-text': 'render'
    },
    initialize: function () {
        this.collection = new GeneralCourseCollection();
        this.collection.bind('reset', this.renderResults.bind(this));
        this.fetch();
    },
    fetch: function() {
        this.collection.fetch({ reset: true });
    },
    render: function () {
        $(this.el).html(this.template());
        return this;
    },
    renderResults: function () {
        var resultList = $(this.el).find('#search-results');
        _.each(this.collection.models, function (course) {
            resultList.append(new CourseSearchItemView({model: course}).render().el);
        });
        return this;
    }
});
CourseSearchItemView = Backbone.View.extend({
    template: _.template($('#tpl-course-search-item').html()),
    render: function () {
        $(this.el).html(this.template(this.model.toJSON()));
        return this;
    }
});