CourseDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-course-search').html()),
    events: {
        'keyup #search-text': 'filterData'
    },
    initialize: function () {
        this.collection = new GeneralCourseCollection();
        this.collection.bind('reset', this.successData.bind(this));
        this.fetch();
    },
    fetch: function() {
        this.collection.fetch({ reset: true });
    },
    successData: function() {
        this.renderResults(this.collection.models);
    },
    filterData: function () {
        var text = $(this.el).find('#search-text').val();
        var results = this.collection.filter(function (course) {
            if (text.length === 0) return true;
            return course.get('Title').toLowerCase().indexOf(text.toLowerCase()) >= 0;
        });
        this.renderResults(results);
    },
    render: function () {
        $(this.el).html(this.template());
        return this;
    },
    renderResults: function (data) {
        var resultEl = $(this.el).find('#search-results');
        resultEl.empty();
        _.each(data, function (course) {
            resultEl.append(new CourseSearchItemView({ model: course }).render().el);
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