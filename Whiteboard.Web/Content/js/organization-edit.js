(function ($) {
    $(document).ready(function () {
        initializeSummerNotes();
        $('#organization-form').on('submit', formSubmit);
    });
    initializeSummerNotes = function () {
        var options = {
            height: 200,
            toolbar: [
                ['style', ['bold', 'italic', 'underline', 'clear']],
                ['fontsize', ['fontsize']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['height', ['height']]
            ]
        };
        $('#description').summernote(options);
    };
    formSubmit = function () {
        alert('submit');
        $('textarea[name="description"]').html($('#description').code());
    };
}).call(document, jQuery);