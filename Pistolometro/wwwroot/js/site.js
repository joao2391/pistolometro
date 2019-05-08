'use strict';
//$(document).ready(function () {

    $('#login').click(function () {

        var url = "/Identity/Account/Login";
        var position = getLocation();
        var _latitude = position.latitude;
        var _longitude = position.longitude;

        $.post(url, { latitude: _latitude, longitude: _longitude }, function (data) {
            console.log('lat:' + data);
        });
    });
//});

function getLocation() {

    'use strict';

    if ("geolocation" in navigator) {       
        'use strict';
        navigator.geolocation.getCurrentPosition((position) => {
            'use strict';
            console.log(position.coords.latitude, position.coords.longitude);
            return {
                "latitude": position.coords.latitude,
                "longitude": position.coords.longitude
            };
        });

    } else {
        'use strict';
        return {
            "latitude": 0,
            "longitude": 0
        };
    }
}

//$(document).ready(function () {

//    var id = $('#id').val();

//    $.post('', { latitude: _latitude, longitude: _longitude }, function (data) {
//        console.log('lat:' + data);
//    });

//});