let marker = null
let map = null

//Нажать по карте, чтобы получить широту и долготу
//function ClickToGetLongitudeAndLatitude() {

//        map = L.map('map').setView([parseFloat(56.4977100), parseFloat(84.9743700)], 13)

//        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
//            attribution:
//                '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
//        }).addTo(map)

//    var popup = L.popup();

//    function onMapClick(e) {
//        popup
//            .setLatLng(e.latlng)
//            .setContent("You clicked the map at " + e.latlng.toString())
//            .openOn(map);
//    }

//    map.on('click', onMapClick);
//}