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

function StartMap(entertainmentLookupDtoByTypeAndAreaAndPrice) {
    let count = entertainmentLookupDtoByTypeAndAreaAndPrice.length //id.length
    console.log(entertainmentLookupDtoByTypeAndAreaAndPrice);
    map = L.map('map').setView([parseFloat(entertainmentLookupDtoByTypeAndAreaAndPrice[0].latitude), parseFloat(entertainmentLookupDtoByTypeAndAreaAndPrice[0].longitude)], 11)
    
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution:
            '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map)

    var markers = new L.MarkerClusterGroup();
    var markersList = [];

    function populate() {
        for (var i = 0; i < count; i++) {
            var m = new L.Marker([parseFloat(entertainmentLookupDtoByTypeAndAreaAndPrice[i].latitude), parseFloat(entertainmentLookupDtoByTypeAndAreaAndPrice[i].longitude)]).bindPopup(entertainmentLookupDtoByTypeAndAreaAndPrice[i].name).on("click", onMapClick);
            markersList.push(m);
            markers.addLayer(m);
        }
        return false;
    }

    populate();
    map.addLayer(markers);
    function onMapClick(e) {
        var z;
        for (var i = 0; i <= count; i++) {
            if (e.latlng.lat == entertainmentLookupDtoByTypeAndAreaAndPrice[i].latitude & e.latlng.lng == entertainmentLookupDtoByTypeAndAreaAndPrice[i].longitude) {
                z = i;
            }
        }

        var url = $("#RedirectTo").val();
        location.href = url + "?nameid=" + id[z];
    }
}