//Summernote WYSIWYG Initialization and Custom Height
$(document).ready(function () {
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
    $('#aboutCourse').summernote(options);
    $('#syllabus').summernote(options);
    $('#lectures').summernote(options);

    $('#teacher').autocomplete({
        serviceUrl: '/course/teachers',
        onSelect: function (info) {
            console.log(info.data + " " + info.value);
            var t = document.getElementById("teacherId");
            t.value = info.data;
        }
    });
});
var postForm = function () {
    $('textarea[name="description"]').html($('#description').code());
    $('textarea[name="aboutCourse"]').html($('#aboutCourse').code());
    $('textarea[name="syllabus"]').html($('#syllabus').code());
    $('textarea[name="lectures"]').html($('#lectures').code());
}