(function ($) {
    var addAdmin = function () {

    };
    $(document).ready(function () {
        var options = {
            tokenLimit: 1
        };
        $("#admin-name").tokenInput("http://shell.loopj.com/tokeninput/tvshows.php", options);
        $('#add-admin').on('click', addAdmin);
    });
}).call(document, jQuery);