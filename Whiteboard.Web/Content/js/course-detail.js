(function ($) {
    $(document).ready(function () {
        $('#add-student').on('click', addStudent);
        $('#student-name').autocomplete({
            serviceUrl: '/course/students',
            noCache: true,
            onSelect: function (info) {
                console.log(info.data + " " + info.value);
                $('#studentId').val(info.data);
            }
        });
        $(document.body).on('click', 'a[data-student-id]', deleteStudent);
        $('#start-class').on('click', startClass);
    });
    var startClass = function (e) {
        if (confirm("Do you want to start a class?")) {
            var courseId = $('#hiddenCourseId').val();
            var data = {
                courseId: courseId
            };
            $.post('/courseclass/start', data).done(function (res) {
                window.location = "/course/courseclass/" + res.courseClassId;
            });
        }
    };
    var deleteStudent = function(e) {
        e.preventDefault();
        var studentId = e.currentTarget.dataset.studentId;
        data = { courseStudentId: studentId };
        $.post('/course/student/delete', data).done(function(res) {
            e.currentTarget.parentNode.parentNode.remove();
        });
    };
    var addStudent = function (e) {
        e.preventDefault();
        var studentId = $('#studentId').val();
        $('#studentId').val('');
        $('#student-name').val('');
        var data = {
            'studentId': studentId
        };
        $.post('/course/addstudent', data).done(function (res) {
            var tpl = '';
            tpl += '<tr>';
            tpl += '<td>' + res.name + '</td>';
            tpl += '<td><a href="#" data-student-id="' + res.id + '"><i class="fa fa-trash-o fa-lg"></i></a></td>';
            tpl += '</tr>';

            $('#students-tbody').append(tpl);
        });
    };
}).call(document, jQuery);