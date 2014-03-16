(function ($) {
    $(document).ready(function () {
        registerAutoComplete();
    }),
    registerAutoComplete = function () {
        $('#student-name').autocomplete({
            serviceUrl: '/schoolmanager/students',
            noCache: true,
            onSelect: function (info) {
                console.log(info.data + " " + info.value);
                $('#studentId').val(info.data);
            }
        });
    }
}).call(document, jQuery);