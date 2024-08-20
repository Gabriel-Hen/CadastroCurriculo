(function ($) {
    function initFormValidation() {
        // Example starter JavaScript for disabling form submissions if there are invalid fields
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        // Loop over them and prevent submission
        document.querySelectorAll('.needs-validation').forEach(form => {
            form.addEventListener('submit', event => {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
    }

    // Form Advance
    function initFormAdvance() {
        // Select2
        if (jQuery().select2) {
            $('[data-toggle="select2"]').select2();
        }

        // Input Mask
        if (jQuery().mask) {
            $('[data-toggle="input-mask"]').each(function (idx, obj) {
                var maskFormat = $(obj).data("maskFormat");
                var reverse = $(obj).data("reverse");
                if (reverse != null)
                    $(obj).mask(maskFormat, { 'reverse': reverse });
                else
                    $(obj).mask(maskFormat);
            });
        }

        // Date-Range-Picker
        if (jQuery().daterangepicker) {
            //date pickers ranges only
            var start = moment().subtract(29, 'days');
            var end = moment();
            var defaultRangeOptions = {
                startDate: start,
                endDate: end,
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                }
            };

            $('[data-toggle="date-picker-range"]').each(function (idx, obj) {
                var objOptions = $.extend({}, defaultRangeOptions, $(obj).data());
                var target = objOptions["targetDisplay"];
                //rendering
                $(obj).daterangepicker(objOptions, function (start, end) {
                    if (target)
                        $(target).html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
                });
            });

            // Datetime and date range picker
            var defaultOptions = {
                "cancelClass": "btn-light",
                "applyButtonClasses": "btn-success"
            };

            $('[data-toggle="date-picker"]').each(function (idx, obj) {
                var objOptions = $.extend({}, defaultOptions, $(obj).data());
                $(obj).daterangepicker(objOptions);
            });
        }

        // Bootstrap Timepicker
        if (jQuery().timepicker) {
            var defaultOptions = {
                "showSeconds": true,
                "icons": {
                    "up": "mdi mdi-chevron-up",
                    "down": "mdi mdi-chevron-down"
                }
            };

            $('[data-toggle="timepicker"]').each(function (idx, obj) {
                var objOptions = $.extend({}, defaultOptions, $(obj).data());
                $(obj).timepicker(objOptions);
            });
        }

        // Bootstrap Touchspin
        if (jQuery().TouchSpin) {
            var defaultOptions = {

            };

            $('[data-toggle="touchspin"]').each(function (idx, obj) {
                var objOptions = $.extend({}, defaultOptions, $(obj).data());
                $(obj).TouchSpin(objOptions);
            });
        }

        // Bootstrap Maxlength
        if (jQuery().maxlength) {
            var defaultOptions = {
                warningClass: "badge bg-success",
                limitReachedClass: "badge bg-danger",
                separator: ' out of ',
                preText: 'You typed ',
                postText: ' chars available.',
                placement: 'bottom',
            };

            $('[data-toggle="maxlength"]').each(function (idx, obj) {
                var objOptions = $.extend({}, defaultOptions, $(obj).data());
                $(obj).maxlength(objOptions);
            });
        }
    }

    function resetarValidacaoForm(form) {
        $(form)
            .find("[data-valmsg-replace]")
            .removeClass("field-validation-error")
            .addClass("field-validation-valid")
            .empty();
    }
    function init() {
        initFormValidation()
        initFormAdvance()
    }

    init()


    jQuery(function ($) {
        $.datepicker.regional['pt-BR'] = {
            closeText: 'Fechar',
            prevText: '&#x3c;Anterior',
            nextText: 'Pr&oacute;ximo&#x3e;',
            currentText: 'Hoje',
            monthNames: ['Janeiro', 'Fevereiro', 'Mar&ccedil;o', 'Abril', 'Maio', 'Junho',
                'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun',
                'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
            dayNames: ['Domingo', 'Segunda-feira', 'Ter&ccedil;a-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado'],
            dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
            dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 0,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['pt-BR']);
    });
    
})(jQuery)