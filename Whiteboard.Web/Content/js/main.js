$(document).ready(function () {
    window.roles = {
        "student": "Profile.StudentRole",
        "teacher": "Profile.TeacherRole",
        "school": "Profile.SchoolRole"
    };

    $(".navbar-login").on("click", function (e) {
        e.stopPropagation();
    });
    //$('a[href^="#"]').on('click', function (e) {
    //    e.preventDefault();

    //    var target = this.hash,
	//    $target = $(target);

    //    $('html, body').stop().animate({
    //        'scrollTop': $target.offset().top
    //    }, 900, 'swing', function () {
    //        window.location.hash = target;
    //    });
    //});
});