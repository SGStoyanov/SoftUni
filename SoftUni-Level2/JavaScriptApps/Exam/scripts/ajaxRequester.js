'use strict';

var ajaxRequester = (function() {
    var baseUrl = "https://api.parse.com/1/";

    var headers =
    {
        "X-Parse-Application-Id": "GTkimFGSHCxnNvXzAFUuiVIJ6CAcIyb5iJGvCEGE",
        "X-Parse-REST-API-Key": "ZJQeJbwwgFVIeTmGMeoZnGxyNOAu2QZEm4sgqh2J"
    };

    function login(username, password, success, error) {
        jQuery.ajax({
            method: "GET",
            headers: headers,
            url: baseUrl + "login",
            data: {username: username, password: password},
            success: success,
            error: error
        });
    }

    function register(username, password, success, error) {
        jQuery.ajax({
            method: "POST",
            headers: headers,
            url: baseUrl + "users",
            data: JSON.stringify({username: username, password: password}),
            success: success,
            error: error
        });
    }

    function getHeadersWithSessionToken(sessionToken) {
        var headersWithToken = headers;
        headersWithToken['X-Parse-Session-Token'] = sessionToken;
        return headersWithToken;
    }

    function getProducts(sessionToken, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken);
        jQuery.ajax({
            method: "GET",
            headers: headersWithToken,
            url: baseUrl + "classes/Product",
            success: success,
            error: error
        });
    }

    function addProduct(name, category, price, userId, success, error) {
        var product = {name: name, category: category, price: price, ACL : {}};
        // Setting public read and owner read+write permissions
        product.ACL[userId] = {"write": true, "read": true};
        product.ACL['*'] = {"read": true};
        jQuery.ajax({
            method: "POST",
            headers: headers,
            url: baseUrl + "classes/Product",
            data: JSON.stringify(product) || undefined,
            success: success,
            error: error
        });
    }

    function editProduct(productId, name, category, price, success, error) {
        var product = {name: name, category: category, price: price};
        jQuery.ajax({
            method: "PUT",
            headers: headers,
            url: baseUrl + "classes/Product/" + productId,
            data: JSON.stringify(product) || undefined,
            success: success,
            error: error
        });
    }

    function deleteProduct(sessionToken, bookmarkId, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken);
        jQuery.ajax({
            method: "DELETE",
            headers: headersWithToken,
            url: baseUrl + "classes/Bookmark/" + bookmarkId,
            success: success,
            error: error
        });
    }

    return {
        login: login,
        register: register,
        getProducts: getProducts,
        addProduct: addProduct,
        editProduct: editProduct//,
        //deleteProduct: deleteProduct
    };
})();