CourseDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-course-search').html()),
    events: {
        'click #search-text': 'search'
    },
    initialize: function () {
    },
    render: function () {
        return this;
    }
});