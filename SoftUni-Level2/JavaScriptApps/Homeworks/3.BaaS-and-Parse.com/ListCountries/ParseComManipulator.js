$(function() {
    //"use strict";

    var PARSE_APP_ID = 'pSleLOfgeyCUYtXfp0KbkOllUcyKPtsqJA01MWAj';
    var PARSE_REST_API_KEY = 'ncnBbjO0Wq9EbBOgHr7EQ74nHJOHmKijdDOcZXId';
    
    // Adding data
    //var newCountry = {
    //    "name": "CountryCreatedByJQuery"
    //}
    //var newCountryStringified = JSON.stringify(newCountry);

    //$.ajax({
    //    method: "POST",
    //    headers: {
    //        "X-Parse-Application-Id": PARSE_APP_ID,
    //        "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
    //    },
    //    data: newCountryStringified,
    //    dataType: "json",
    //    url: "https://api.parse.com/1/classes/Country",
    //    contentType: "application/json"
    //}).success(function() {
    //    console.log('Country created');
    //}).error(function() {
    //    console.log('Country not created');
    //});
    
    // Modifying existing data
    //var updateCountry = { "name": "Updated country" }
    //var stringifiedCountry = JSON.stringify(updateCountry);

    //$.ajax({
    //    method: "PUT",
    //    headers: {
    //        "X-Parse-Application-Id": PARSE_APP_ID,
    //        "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
    //    },
    //    data: stringifiedCountry,
    //    url: "https://api.parse.com/1/classes/Country/9kMCckVl8N", // Example object id from: https://www.parse.com/apps/geography--2/collections#class/Country
    //    contentType: "application/json"
    //}).success(function () {
    //    console.log('Country updated');
    //}).error(function () {
    //    console.log('Country not updated');
    //});
    
    // Deleting data
    //$.ajax({
    //    method: "DELETE",
    //    headers: {
    //        "X-Parse-Application-Id": PARSE_APP_ID,
    //        "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
    //    },
    //    url: "https://api.parse.com/1/classes/Country/1CJIBdT8g4"
    //}).success(function() {
    //    console.log('Country deleted');
    //}).error(function() {
    //    console.log('Country not deleted');
    //});

    // Retrieving data
    loadCountries();
    function loadCountries() {
        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Country",
            success: countriesLoaded,
            error: ajaxError
        });
    }
    
    function countriesLoaded(data) {
        for (var c in data.results) {
            var country = data.results[c];
            var countryItem = $('<li>').css('list-style-type', 'square');
            var countryLink = $("<a href='#'>").text(country.name);
            $(countryLink).data('country', country);
            countryLink.appendTo(countryItem);
            $(countryLink).click(countryClicked);
            countryItem.appendTo($("#countriesList"));
        }
    }

    function countryClicked() {
        var country = $(this).data('country');
        $('#towns').hide();
        $('#towns h2').text(country.name);
        var countryId = country.objectId;
        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + countryId + '"}}',
            success: townsLoaded,
            error: ajaxError
        });
    }

    function townsLoaded(data) {
        $('#towns ul').html('');
        for (var t in data.results) {
            var town = data.results[t];
            var townItem = $('<li>');
            townItem.text(town.name); // ...
            townItem.appendTo($('#towns ul'));
        }
        $('#towns').show();
    }

    function ajaxError() {
        console.log('Cannot load AJAX data');
    }

});