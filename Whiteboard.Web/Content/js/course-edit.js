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

    initializeDateComponents();
    $('#add-class').on('click', addClass);
    formatDates();
});
var postForm = function () {
    $('textarea[name="description"]').html($('#description').code());
    $('textarea[name="aboutCourse"]').html($('#aboutCourse').code());
    $('textarea[name="syllabus"]').html($('#syllabus').code());
    $('textarea[name="lectures"]').html($('#lectures').code());
}

function initializeDateComponents() {
    $('#timepicker1').timepicker({
        showMeridian: false
    });

    $('#timepicker2').timepicker({
        showMeridian: false
    });

    //setTimeout(function () {
    //    $('#timeDisplay').text($('#timepicker1').val());
    //}, 100);

    //$('#timepicker1').on('changeTime.timepicker', function (e) {
    //    $('#timeDisplay').text(e.time.value);
    //});


    $('#sandbox-container input').datepicker({
        autoclose: true,
        todayHighlight: true,
        startDate: new Date()
    }).datepicker("setDate", new Date());
}
function addClass(e) {
    e.preventDefault();
    // class-desc, class-date, timepicker1
    var description = $('#class-desc').val();
    var hour1 = $('#timepicker1').data('timepicker').hour;
    var minute1 = $('#timepicker1').data('timepicker').minute;
    var hour2 = $('#timepicker2').data('timepicker').hour;
    var minute2 = $('#timepicker2').data('timepicker').minute;
    var date1 = $('#sandbox-container input').datepicker("getDate");
    var date2 = $('#sandbox-container input').datepicker("getDate");
    date1.setMinutes(minute1);
    date1.setHours(hour1);
    date1.setSeconds(0);
    date2.setMinutes(minute2);
    date2.setHours(hour2);
    date2.setSeconds(0);

    var courseId = $('#courseId').val();
    var data = {
        courseId: courseId,
        description: description,
        beginTime: date1.getTime(),
        endTime: date2.getTime()
    }

    $.post('/course/addclass/', data).done(function (data) {
        console.log(data);
    }, 'json');
}
function formatDates() {
    var items = document.getElementsByClassName('format-date');
    for (var i = 0; i < items.length; ++i) {
        var date = new Date();
        date.setTime(parseInt(items[i].innerHTML));

        var month = date.getMonth() + 1;
        var day = date.getDate();
        var year = date.getFullYear();
        var hour = date.getHours();
        var minute = date.getMinutes();
        hour = hour < 10 ? '0' + hour : hour;
        minute = minute < 10 ? '0' + minute : minute;
        month = month < 10 ? '0' + month : month;
        day = day < 10 ? '0' + day : day;

        var format = month + "/" + day + "/" + year + " " + hour + ":" + minute;
        items[i].innerHTML = format;
    }
}