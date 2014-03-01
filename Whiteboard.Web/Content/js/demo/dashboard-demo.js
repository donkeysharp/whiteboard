//Date Range Picker
$(document).ready(function() {
   
});

//Morris Area Chart
var sales_data = [{
    date: '2014-1-25',
    productA: 80.26,
    productB: 92.26,
    productC: 79.91,
    productD: 81.63
}, {
    date: '2014-1-26',
    productA: 251.34,
    productB: 115.62,
    productC: 128.34,
    productD: 92.35
}, {
    date: '2014-1-27',
    productA: 90.91,
    productB: 89.26,
    productC: 124.48,
    productD: 152.61
}, {
    date: '2014-1-28',
    productA: 91.23,
    productB: 87.94,
    productC: 250.79,
    productD: 352.24
}, {
    date: '2014-1-29',
    productA: 148.26,
    productB: 151.98,
    productC: 164.33,
    productD: 142.43
}, {
    date: '2014-1-30',
    productA: 74.53,
    productB: 71.26,
    productC: 78.91,
    productD: 76.32
}, {
    date: '2014-1-31',
    productA: 84.26,
    productB: 62.87,
    productC: 156.72,
    productD: 163.06
}, ];


//Flot Chart Dynamic Chart

var container = $("#flot-chart-moving-line");

// Determine how many data points to keep based on the placeholder's initial size;
// this gives us a nice high-res plot while avoiding more than one point per pixel.

var maximum = container.outerWidth() / 10 || 300;

//

var data = [];

function getRandomData() {

    if (data.length) {
        data = data.slice(1);
    }

    while (data.length < maximum) {
        var previous = data.length ? data[data.length - 1] : 50;
        var y = previous + Math.random() * 10 - 5;
        data.push(y < 0 ? 0 : y > 100 ? 100 : y);
    }

    // zip the generated y values with the x values

    var res = [];
    for (var i = 0; i < data.length; ++i) {
        res.push([i, data[i]])
    }

    return res;
}

//

series = [{
    data: getRandomData(),
    lines: {
        fill: true,
        fillColor: "rgba(255,255,255,0.4)",
    },
}];

//


// Update the random dataset at 25FPS for a smoothly-animating chart




//Chat Widget SlimScroll Box
$(function() {
    $('.chat-widget').slimScroll({
        start: 'bottom',
        height: '300px',
        alwaysVisible: true,
        disableFadeOut: true,
        touchScrollStep: 50
    });
});

//Moment.js Time Display
var datetime = null,
    date = null;

var update = function() {
    date = moment(new Date())
    datetime.html(date.format('dddd<br>MMMM Do, YYYY<br>h:mm:ss A'));
};

$(document).ready(function() {
    datetime = $('#datetime')
    update();
    setInterval(update, 1000);
});

//Custom jQuery - Changes background on time tile based on the time of day.
$(document).ready(function() {
    datetoday = new Date(); // create new Date()
    timenow = datetoday.getTime(); // grabbing the time it is now
    datetoday.setTime(timenow); // setting the time now to datetoday variable
    hournow = datetoday.getHours(); //the hour it is

    if (hournow >= 18) // if it is after 6pm
        $('div.tile-img').addClass('evening');
    else if (hournow >= 12) // if it is after 12pm
        $('div.tile-img').addClass('afternoon');
    else if (hournow >= 6) // if it is after 6am
        $('div.tile-img').addClass('morning');
    else if (hournow >= 0) // if it is after midnight
        $('div.tile-img').addClass('midnight');
});

//To-Do List jQuery - Adds a strikethrough on checked items
$('.checklist input:checkbox').change(function() {
    if ($(this).is(':checked'))
        $(this).parent().addClass('selected');
    else
        $(this).parent().removeClass('selected')
});


//DataTables Initialization for Map Table Example
$(document).ready(function() {
});
