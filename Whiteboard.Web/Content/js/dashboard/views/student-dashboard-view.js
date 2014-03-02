StudentDashboardView = Backbone.View.extend({
    template: _.template($('#tpl-student-dashboard').html()),
    events: {
        "click #clickme": "doClick"
    },
    initialize: function () {
    },
    doClick: function() {
        alert("clicked");
    },
    render: function () {
        $(this.el).html(this.template({foo: "wooooow"}));
    }
});