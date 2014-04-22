(function ($) {
    'use strict';

    $(document).ready(function () {
        $('#search').on('click', search);
    });
    var search = function () {
        var keywords = $('#keywords').val();
        $.get('/dashboard/publicsearch?keyword=' + keywords).done(function (res) {
            console.log(res.length);
            $('#circularG').remove();
            for (var i = 0; i < res.length; ++i) {
                addResult(res[i]);
            }
        });
        $('#search-results').empty();
        addSpinner();
    }
    var addResult = function (res) {
        var tpl = '';
        tpl += '<a href="/course/' + res.Id + '">';
        tpl += '<div class="col-md-5 course-item">';
        tpl += '<img src="' + res.PictureUrl + '" />';
        tpl += '<div class="course-body">';
        tpl += '<h4>' + res.Title + '</h4>';
        tpl += '<span>' + res.TeacherName + '</span>';
        tpl += '</div></div></a>';

        $('#search-results').append(tpl);
    }
    var addSpinner = function () {
        var tpl = '';
        tpl += '<div id="circularG" style="margin: 0 auto 0 auto">';
        tpl += '<div id="circularG_1" class="circularG"></div><div id="circularG_2" class="circularG"></div>';
        tpl += '<div id="circularG_3" class="circularG"></div><div id="circularG_4" class="circularG"></div>';
        tpl += '<div id="circularG_5" class="circularG"></div><div id="circularG_6" class="circularG"></div>';
        tpl += '<div id="circularG_7" class="circularG"></div><div id="circularG_8" class="circularG"></div></div>';

        $('#search-results').append(tpl);
    }
}).call(document, jQuery);