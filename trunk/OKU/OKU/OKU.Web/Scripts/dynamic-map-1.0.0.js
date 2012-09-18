(function ($) {
    $.fn.extend({
        dynamicMap: function (options) {

            var defaults = {
                pointClick: pointClickCustomHandler,
                mapClick: mapClickCustomHandler,
                addPointServerUrl: '/addPoint',
                removePointServerUrl: '/removePoint'
            };

            var options = $.extend(defaults, options);

            return this.each(function () {

                var map = $(this);
                var mapId = map.attr('id');

                map.data('dynamicMapOptions', options);

                $('.point', map).addClass('sync');
                $('.point', map).click(map, pointClickDefaultHandler);

                map.click(function (event) {

                    if (!event) {
                        event = window.event;
                    }

                    //IE9 & Other Browsers
                    if (event.stopPropagation) {
                        event.stopPropagation();
                    }
                    //IE8 and Lower
                    else {
                        event.cancelBubble = true;
                    }

                    var pointX = (event.offsetX == undefined ? event.originalEvent.layerX : event.offsetX) - 2;
                    var pointY = (event.offsetY == undefined ? event.originalEvent.layerY : event.offsetY) - 2;

                    var pointXpro = Math.round(pointX * 1000 / map.width());
                    var pointYpro = Math.round(pointY * 1000 / map.height());

                    var point = $('<div></div>');
                    point.addClass('point');
                    point.addClass('nonsync');
                    point.css('left', pointXpro / 10 + '%');
                    point.css('top', pointYpro / 10 + '%');

                    point.click(map, pointClickDefaultHandler);

                    map.append(point);

                    $.post(options.addPointServerUrl, { viewItemId: mapId, x: pointXpro, y: pointYpro }, function (data, textStatus, jqXHR) {
                        point.attr('id', data.pointId);
                        point.removeClass('nonsync');
                        point.addClass('sync');

                        options.mapClick(map, point, data);
                    });
                });
            });

            function pointClickDefaultHandler(e) {
                if (!e) {
                    e = window.e;
                }

                //IE9 & Other Browsers
                if (e.stopPropagation) {
                    e.stopPropagation();
                }
                //IE8 and Lower
                else {
                    e.cancelBubble = true;
                }

                options.pointClick(e.data, $(this));
            }

            function pointClickCustomHandler(map, point) {
                removeDynamicMapPoint(map.attr('id'), point.attr('id'));
            }

            function mapClickCustomHandler(map, point, data) {
            }
        }
    });
})(jQuery);

function removeDynamicMapPoint(mapId, pointId) {
    var map = $('#' + mapId + '.dynamic-map').first();
    var point = $('#' + pointId + '.point', map).first();

    var options = map.data('dynamicMapOptions');

    point.removeClass('sync');
    point.addClass('nonsync');

    $.post(options.removePointServerUrl, { viewItemId: mapId, pointId: pointId }, function (data, textStatus, jqXHR) {
        point.remove();
        //alert('Point ' + point.attr('id') + ' removed from map ' + map.attr('id'));
    });
}