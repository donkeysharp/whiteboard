(function ($) {
    $(document).ready(function () {
        registerAutoComplete();
        registerAjaxEvents();
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
    },
    registerAjaxEvents = function () {
        $('#add-student').on('click', function (e) {
            var studentId = $('#studentId').val();

            var data = { studentId: studentId };
            $.post('/schoolmanager/addstudent', data).done(function(res){
                alert('student added');
            }).error(function (res) {

            });
        });
    }
}).call(document, jQuery);