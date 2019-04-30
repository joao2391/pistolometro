// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getLocation() {

    if (navigator.geolocation) {

        navigator.geolocation.getCurrentPosition((position) => {

            console.log(position.coords.latitude, position.coords.longitude);
        });

    } else {

        console.log('Geolocalizacao nao suportada');
    }
}
