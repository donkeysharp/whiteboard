Sidebar = Backbone.View.extend({
    LastSelect: $('#default-select'),
    events: {
        'click .command': 'onClick'
    },
    onClick: function (event) {
        var element = $(event.currentTarget);
        this.LastSelect.removeClass('active');
        if (element.is('.single')) {
            this.LastSelect = element;
        } else {
            this.LastSelect = element.parent().parent().parent().find('.multiple').first();
        }
        this.LastSelect.addClass('active');
        return false;
    }
});