(function() {
    'use strict';

    $(function() {
        registerEventHandlers();

        var currentUser = userSession.getCurrentUser();
        if (currentUser) {
            showWelcomeUserView();
        } else {
            showHomeView();
        }
    });

    function registerEventHandlers() {
        $('.btn-navHome').click(showHomeView);
        $('#btn-navRegister').click(showRegisterView);
        $('#register-button').click(registerButtonClicked);
        $('#btn-RegisterViewLogin, #btn-navLogin, #btn-GuestViewLogin').click(showLoginView);
        $('#btn-LoginViewLogin').click(loginButtonClicked);
        $('#btn-navAddProduct').click(showAddProductView);
        $('#add-product-button').click(addProductButtonClicked);
        $('#btn-navListProducts').click(showProductsListView);
        $('#btn-navLogout').click(logoutButtonClicked);
        //$('.btn-EditProduct').click(showEditProductView);
    }


    function showHomeView() {
        var currentUser = userSession.getCurrentUser();
        if(currentUser) {
            showWelcomeUserView();
        } else {
            $('main > *').hide();
            $('header').show();
            $('main header nav > *').hide();
            $('#ulBeforeAuth').show();
            $('#main').show();
            $('#main > *').hide();
            $('#guestView').show();
        }
    }


    function showRegisterView() {
        $('#main > *').hide();
        // Clearing previously entered registration data
        clearInputFields();

        $('#registerSection').show();
    }

    function registerButtonClicked() {
        var username = $('#username').val();
        var password = $('#password').val();
        var passwordRepeated = $('#confirm-password').val();

        ajaxRequester.register(username, password,
            function(data) {
                if(password === passwordRepeated) {
                    data.username = username;
                    authSuccess(data);
                } else {
                    showInfoMessage('Passwords must be identical.', 'error');
                }
            },
            registerError
        );
    }

    function authSuccess(data) {
        userSession.login(data);
        showWelcomeUserView(data);
    }

    function registerError(error) {
        var errorReason = error.responseJSON.error;
        showInfoMessage('Registration failed. Reason: ' + errorReason + '!', 'error');
        clearInputFields();
    }


    function showLoginView() {
        $('#main > *').hide();
        // Clearing previously entered registration data
        clearInputFields();

        $('#loginSection').show();
    }

    function loginButtonClicked() {
        var username = $('#txt-LoginViewUsername').val();
        var password = $('#txt-LoginViewPassword').val();

        ajaxRequester.login(username, password, authSuccess, function(error) {
            showInfoMessage('Incorrect username/password', 'error');
        });
    }


    function showWelcomeUserView(data) {
        $('#main > *').hide();
        $('#ulBeforeAuth').hide();
        $('#ulAfterAuth').show();
        $('#welcomeUserView').show();
        var currentUser = userSession.getCurrentUser().username;
        $('#welcomeUserViewHeader').html('Welcome, ' + currentUser + '!');
    }


    function showAddProductView() {
        $('#main > *').hide();
        $('#ulBeforeAuth').hide();
        $('#ulAfterAuth').show();
        $('#addProductView').show();

        // TODO: to add clearing of Add Products fields somewhere
    }

    function addProductButtonClicked() {
        // name, category, userId, success, error
        var name = $('#addProductViewName').val();
        var category = $('#addProductViewCategory').val();
        var price = $('#addProductViewPrice').val();
        var userId = userSession.getCurrentUser().objectId;
        ajaxRequester.addProduct(name, category, price, userId, function(data) {
           showProductsListView();
           showInfoMessage('Product successfully created!', 'success');
        },
        function(error) {
           showInfoMessage('Error, product not added: ' + error.responseJSON.error, 'error');
        });
    }

    function showProductsListView() {

        var currentUser = userSession.getCurrentUser();
        if(currentUser) {
            $('#main > *').hide();
            $('#ulBeforeAuth').hide();
            $('#ulAfterAuth').show();
            $('#listProductView').show();

            var sessionToken = currentUser.sessionToken;
            ajaxRequester.getProducts(sessionToken, loadProductsSuccess,
                function(error) {
                    showInfoMessage('There was a problem while listing the products', 'error');
                }
            );
        } else {
            // TODO: LoginView or HomeView?
            showLoginView();
        }
    }

    function loadProductsSuccess(data) {
        var $productsUl = $("#listProductView .products ul");
        $productsUl.html('');

        for (var p in data.results) {
            var product = data.results[p];
            //console.log(product);
            var $productLi = $("<li class='product'>");
            $productLi.data("product", product);

            var $productInfoDiv = $("<div class='product-info'>");

            var $name = $("<p class='item-name'>").text(product.name);
            $productInfoDiv.append($name);
            $productLi.append($productInfoDiv);

            var $category = $("<p class='category'>").text(product.category);
            var $spanPreCategory = $("<span class='pre'>").text('Category: ');
            $category.prepend($spanPreCategory);
            $productInfoDiv.append($category);
            $productLi.append($productInfoDiv);

            var $price = $("<p class='price'>").text(product.price);
            var $spanPrePrice = $("<span class='pre'>").text('Price: ');
            $price.prepend($spanPrePrice);
            $productInfoDiv.append($price);
            $productLi.append($productInfoDiv);

            var $footer = $("<footer class='product-footer'>");
            var $editLink = $("<a href='#'>");
            var $editButton =
                $("<button class='btn-EditProduct'>")
                    .text('Edit').attr('data-productId', product.objectId)
                    .click(showEditProductView(product.objectId));
            $editLink.append($editButton);
            $footer.append($editLink);
            var $deleteLink = $("<a href='#'>");
            var $deleteButton = $("<button class='delete-button'>").text('Delete');
            $deleteLink.append($deleteButton);
            $footer.append($deleteLink);
            $productLi.append($footer);

            $productsUl.append($productLi);
            //$('.btn-EditProduct').click(showEditProductView);
        }
    }


    function showEditProductView(objectId) {
        var currentUser = userSession.getCurrentUser();
        var product = $(this).parent().data('data-productId');
        var sessionToken = currentUser.sessionToken;

        console.log(objectId);

        if(currentUser) {
            $('#main > *').hide();
            $('#ulBeforeAuth').hide();
            $('#ulAfterAuth').show();
            $('#editProductView').show();
            //var currentProductId = $(this).parent().data('product');
            //var currentProductId = $(this).data('data-product');
            //if(!window.console) console.log(currentProductId);
        } else {
            showLoginView();
        }
    }

    function deleteButtonClicked() {

        noty(
            {
                text: "Delete this product?",
                type: 'confirm',
                layout: 'topCenter',
                buttons: [
                    {
                        text : "Yes",
                        onClick : function($noty) {
                            deleteProduct(sessionToken, product);
                            $noty.close();
                        }
                    },
                    {
                        text : "Cancel",
                        onClick : function($noty) {
                            $noty.close();
                        }
                    }
                ]
        });
    }

    function logoutButtonClicked() {
        userSession.logout();
        showInfoMessage('Successfully logged out', 'success');
        showHomeView();
    }


    function clearInputFields() {
        $('#username').val('');
        $('#password').val('');
        $('#confirm-password').val('');
        $('#txt-LoginViewUsername').val('');
        $('#txt-LoginViewPassword').val('');
    }

    function showInfoMessage(msg, msgType) {
        noty({
            text: msg,
            type: msgType,
            layout: "bottomCenter",
            timeout: 3000
        });
    }
}());