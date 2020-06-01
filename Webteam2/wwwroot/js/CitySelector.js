$(document).ready(function () {
    $.getJSON("/Locations/GetAllRegions",
        null,
        function (data) {
            $.each(data,
                function () {
                    $('#Region').append('<option value=' + this.id + '>' + this.name + '</option>');
                    populateCities(this.id);
                });
        }).fail(function () {
        alert('No Regions found.');
    });
});
$(function () {
    $("#Region").on("change", function () {
        var regionId = $(this).val();
        $("#City").empty();
        populateCities(regionId);
    });
});

function populateCities(regionId) {
    $("#City").empty();
    $.getJSON(`/Locations/GetCities?region=${regionId}`, (data) => {
        $.each(data,
            function(i, item) {
                $("#City").append(`<option value="${item.id}">${item.name}</option>`);
            });

    }).fail(function() {
        alert('No Cities found.');
    });
}