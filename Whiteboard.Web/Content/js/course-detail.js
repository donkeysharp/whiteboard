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
        $('a[data-student-id]').on('click', deleteStudent);
    });
    var deleteStudent = function(e) {
        e.preventDefault();
        //var studentId = e.currentTarget.dataset.studentId;
        //data = { studentId: studentId };
        //alert("delete : " + studentId);
        alert("piii");
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