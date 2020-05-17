const mapId = 'map'; //Target div id for Openlayers
var mapDiv = document.getElementById(mapId);
var mapContainer = document.getElementById("mapContainer");
var map;
//init map onload
window.addEventListener('load', () => {
    $.ajax({
        type: "POST",
        url: "/locations/GetLocation",
        data: {id: document.getElementById('CityId').value},
        dataType: "json",
        success: function(response){ // {[double, double]}
            map = loadMap(response);
        },
        error: function (req, status, error) {
            alert(error);
        }
    });
    console.log("ajax done");
});

function createToggleBtn(target, parent) {
    var toggleBtn = document.createElement("button");
    toggleBtn.innerText = "Hide Map";
    toggleBtn.addEventListener("click",
        () => {
            target.style.display === "none"
                ? (target.style.display = "block", toggleBtn.innerText = "Hide map")
                : (target.style.display = "none", toggleBtn.innerText = "Show map");
        });
    parent.insertBefore(toggleBtn, mapDiv);
}

function loadMap(location) {
    createToggleBtn(mapDiv, mapContainer);
    var cityLocation = ol.proj.fromLonLat(location);

    return new ol.Map({
        target: mapId,
        view: 
            makeView(cityLocation, 10),
        layers: 
            makeLayers(cityLocation)
    });

}

function makeView(location, zoom) {
    return new ol.View({
        center: location,
        zoom: zoom
    });
}

function makeLayers(loc) {

    const tileLayer = new ol.layer.Tile({
        source: new ol.source.OSM()
    });
    const markerLayer = new ol.layer.Vector({
        source: new ol.source.Vector({
            features: [
                new ol.Feature(
                    new ol.geom.Point(loc))
            ]
        }),
        style:
            new ol.style.Style({
                image: new ol.style.Circle({
                    radius: 5,
                    fill: new ol.style.Fill({ color: "red" })
                })
            })
    });

    return [tileLayer, markerLayer];
}

