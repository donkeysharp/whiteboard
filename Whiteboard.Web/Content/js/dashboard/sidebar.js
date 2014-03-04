$(document).ready(function () {
    if (document.getElementById('school-sidebar')) {
        var schoolSidebar = new Sidebar({ el: document.getElementById('school-sidebar') });
    } else if (document.getElementById('teacher-sidebar')) {
        var teacherSidebar = new Sidebar({ el: document.getElementById('teacher-sidebar') });
    } else if (document.getElementById('student-sidebar')) {
        var studentSidebar = new Sidebar({ el: document.getElementById('student-sidebar') });   
    }
});