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

function EntertainmantDetailsMap(latitude, longitude, name, size) {
    if (map === null) {

        map = L.map('map').setView([latitude.replace(',', '.'), longitude.replace(',', '.')], size)
    } else {
        console.log(latitude.replace(',','.'));
        // перемещение к следующей позиции
        map.flyTo([latitude.replace(',', '.'), longitude.replace(',', '.')], size)
    }

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution:
            '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map)

    // удаление предыдущего маркера
    if (marker) {
        map.removeLayer(marker)
    }
    marker = new L.Marker([latitude.replace(',', '.'), longitude.replace(',', '.')], size).addTo(map).bindPopup(name).openPopup()
}

function StartMapAllList(entertainmentLookupDtoByTypeAndAreaAndPrice) {
    let count = entertainmentLookupDtoByTypeAndAreaAndPrice.length //id.length
    console.log(entertainmentLookupDtoByTypeAndAreaAndPrice)
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
        console.log(count)
        for (var i = 0; i < count; i++) {
            if (e.latlng.lat == entertainmentLookupDtoByTypeAndAreaAndPrice[i].latitude & e.latlng.lng == entertainmentLookupDtoByTypeAndAreaAndPrice[i].longitude) {
                console.log(entertainmentLookupDtoByTypeAndAreaAndPrice[i].latitude)
                z = entertainmentLookupDtoByTypeAndAreaAndPrice[i].id;
            }
        }

        var url = $("#RedirectTo").val();
        location.href = url + "/" + z;
    }
}

function StartMapDetails(entertainmentLookupDtoByTypeAndAreaAndPrice) {
    let count = entertainmentLookupDtoByTypeAndAreaAndPrice.length //id.length
    console.log(entertainmentLookupDtoByTypeAndAreaAndPrice)
    map = L.map('map').setView([parseFloat(entertainmentLookupDtoByTypeAndAreaAndPrice[0].latitude), parseFloat(entertainmentLookupDtoByTypeAndAreaAndPrice[0].longitude)], 11)

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution:
            '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map)

    var markers = new L.MarkerClusterGroup();
    var markersList = [];

    function populate() {
        for (var i = 0; i < count; i++) {
            var m = new L.Marker([parseFloat(entertainmentLookupDtoByTypeAndAreaAndPrice[i].latitude), parseFloat(entertainmentLookupDtoByTypeAndAreaAndPrice[i].longitude)]).bindPopup(entertainmentLookupDtoByTypeAndAreaAndPrice[i].name);
            markersList.push(m);
            markers.addLayer(m);
        }
        return false;
    }

    populate();
    map.addLayer(markers);
}