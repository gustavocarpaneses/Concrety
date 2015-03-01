'use strict';

app.directive('printDiv', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind('click', function (evt) {
                evt.preventDefault();
                PrintElem(attrs.printDiv);
            });

            function PrintElem(elem) {
                PrintWithIframe($(elem).html());
            }

            function PrintWithIframe(data) {
                if ($('iframe#printf').size() == 0) {
                    $('html').append('<iframe id="printf" name="printf"></iframe>');  // an iFrame is added to the html content, then your div's contents are added to it and the iFrame's content is printed

                    var mywindow = window.frames["printf"];
                    mywindow.document.write('<html><head><title></title><style>@page {size: A4; margin: 25mm 0mm 25mm 5mm;} .page { page-break-after: always; } .page:last-child { page-break-after: auto; }</style>'  // Your styles here, I needed the margins set up like this
                                    + '</head><body><div>'
                                    + data
                                    + '</div></body></html>');

                    $(mywindow.document).ready(function () {
                        mywindow.print();
                        setTimeout(function () {
                            $('iframe#printf').remove();
                        },
                        2000);  // The iFrame is removed 2 seconds after print() is executed, which is enough for me, but you can play around with the value
                    });
                }

                return true;
            }
        }
    };
});