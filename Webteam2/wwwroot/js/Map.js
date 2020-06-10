/*
 * Still needs alot of cleaning... //author
 */

const mapId = 'map'; //Target div id for Openlayers
var mapDiv = document.getElementById(mapId);
var mapContainer = document.getElementById("mapContainer");
var map;

var cityMarker;
var userMarker;
var lineMark;
//init map onload
window.addEventListener('load', () => {
    $.ajax({
        type: "POST",
        url: "/locations/GetLocation",
        data: {id: document.getElementById('CityId').value},
        dataType: "json",
        success: function(response){ // {[double, double]}
            loadMap(response);
        },
        error: function (req, status, error) {
            alert(error);
        }
    });
});
function Track(checkbox) {
    if (checkbox.checked) {
        var loc = GetUserLocation((location) => {
            userMarker = mapMarkerFeature(location, "user");
            userMarker.setStyle(makeMarkerStyle("blue"))
            markersSource.addFeature(userMarker)
            DrawLine(true);
        });

    } else {
        markersSource.removeFeature(userMarker);
        DrawLine(false)
    }
}

function DrawLine(bool) {
    if (bool) {
     lineMark.getGeometry().setCoordinates([this.userMarker.getGeometry().getCoordinates(), this.cityMarker.getGeometry().getCoordinates()])   
    } else {
        lineMark.getGeometry().setCoordinates([])  
    }
    lineMark.setVisibility
    console.log(this.cityMarker.getGeometry().getCoordinates());
}
function GetUserLocation(callback) {
    fetch("https://freegeoip.app/json/")
        .then(response => {
            if (response.status === 200) {
                return response.json();
            } else {
                throw new Error('Api server problems...');
            }
        })
        .then(response => {
            console.log(response);
            //markers.getSource().addFeature(mapMarkerFeature(ol.proj.fromLonLat([response.longitude, response.latitude]), "user"))
            callback([response.longitude, response.latitude]);
        }).catch(error => {
            console.error(error);
            alert(error);
        });
}

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

var lineSource;
var markersSource;

function loadMap(location) {
    createToggleBtn(mapDiv, mapContainer);
    var cityLocation = ol.proj.fromLonLat(location);
    //cityMarker = MakeMapMarker(location, "red")
    cityMarker = mapMarkerFeature(location, "city");
    markersSource = new ol.source.Vector();
    lineSource= new ol.source.Vector();
    lineMark = new ol.Feature({
        geometry: new ol.geom.LineString([])
    });
    lineSource.addFeature(lineMark);
    cityMarker.setStyle(makeMarkerStyle("red"))
    markersSource.addFeature(cityMarker)


    map = new ol.Map({
        target: mapId,
        view: 
            makeView(cityLocation, 10),
        layers: [
            new ol.layer.Tile({
                source: new ol.source.OSM()
            }),
            new ol.layer.Vector({
                source: markersSource,
                //style: function(feature, resolution) {
                //    const name = feature.get('name').toUpperCase();
                //    return name == "CITY" ? makeMarkerStyle("red") : makeMarkerStyle("blue");
                //}
            }),
            new ol.layer.Vector({
                source: lineSource,
                style: new ol.style.Style({
                    fill: new ol.style.Fill({ color: 'black', weight: 2 }),
                    stroke: new ol.style.Stroke({ color: 'black', width: 2,lineDash: [.2, 5] })

                })
            })
                ]

    });
}
function MakeMapMarker(pos, color) {
    var layer = new ol.layer.Vector({
        source: new ol.source.Vector({
            features: [
                new ol.Feature({
                    geometry: new ol.geom.Point(ol.proj.fromLonLat(pos))
                })
            ]
        }),
        style:
            new ol.style.Style({
                image: new ol.style.Circle({
                    radius: 5,
                    fill: new ol.style.Fill({ color: color})
                })
            })
    });
    return layer;
}
function mapMarkerFeature(pos, name) {
    var marker = new ol.Feature({
        geometry: new ol.geom.Point(ol.proj.fromLonLat(pos)),
        name: name
})
    return marker;
}

function makeMarkerStyle(color) {
    var style = new ol.style.Style({
        image: new ol.style.Circle({
            radius: 5,
            fill: new ol.style.Fill({ color: color })
        })
    });
    return style;
}


function makeView(location, zoom) {
    return new ol.View({
        center: location,
        zoom: zoom
    });
}


function toggleUserLocation(bool) {
    if (bool && userMarker == null) {
        GetUserLocation();
    }
    userMarker.setVisible(bool);
}
