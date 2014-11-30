(function ($) {
    var VISABILITY_INTERVAL = 1000,
        ACTIVE_TIME = 3000;

    function box(className, parentId) {
        var $box = $('<div class="messageBox ' + className + '">')
            .css('opacity', '0')
            .appendTo('#' + parentId)
            .animate({
                opacity: '+=1'
            }, VISABILITY_INTERVAL);
        setTimeout(
            function() {
                $box.remove();
            }, ACTIVE_TIME
        );
        return $box;
    }

    $.prototype.messageBox = function(id) {
        $this = $(this);

        if ($('#' + id).length === 0) {
            $('<div id="' + id + '">').appendTo('body');
        }

        $('<style>' +
            '.messageBox {padding: 10px; width: 400px} ' +
            '.success {background: #66FF33;} ' +
            '.error {background: #FF1919;}' +
            '</style>'
        ).appendTo('head');

        function success(message) {
            return box('success', id).text(message);
        }

        function error(message) {
            return box('error', id).text(message);
        }

        return {
            success: success,
            error: error
        }
    }

})(jQuery);

$('<button>Success</button>')
.appendTo('body')
.click(function () {
    $().messageBox('message').success('success message').css('border-radius', '15px');
});

$('<button>Error</button><br/><br/>')
.appendTo('body')
.click(function () {
        $().messageBox('message').error('error message').css('border-radius', '15px');
    });
