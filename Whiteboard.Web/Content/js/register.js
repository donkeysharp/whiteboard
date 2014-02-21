$(document).ready(function () {
    $('input[name="role"]').on("click", function (e) {
        var label = document.getElementById("name-label");
        if (e.target.value === window.roles.student) {
            label.innerHTML = "Student Name: ";
        } else if (e.target.value === window.roles.teacher) {
            label.innerHTML = "Teacher Name: ";
        } else if (e.target.value === window.roles.school) {
            label.innerHTML = "School Name: ";
        }
    });
});