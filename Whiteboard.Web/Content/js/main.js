$(document).ready(function () {
    window.roles = {
        "student": "Profile.StudentRole",
        "teacher": "Profile.TeacherRole",
        "school": "Profile.SchoolRole"
    };

    $(".navbar-login").on("click", function (e) {
        e.stopPropagation();
    });
});