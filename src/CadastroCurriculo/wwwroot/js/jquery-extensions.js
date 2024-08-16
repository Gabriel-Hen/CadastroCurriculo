(function (w, $) {
    "use strict";

    $.fn.aplicarMaxLength = function () {
        this.maxlength({
            alwaysShow: true,
            warningClass: "badge bg-success",
            limitReachedClass: "badge bg-success",
            placement: 'bottom',
            message: '%charsTyped% de %charsTotal%'
        });

        return this;
    };

    $.fn.aplicarDateRangePickerComRanges = function (ranges, inicio, fim, callback) {
        var $this = this;
        var $span = $this.find("span");

        function cb(start, end) {
            var valid = start && start._isValid && end && end._isValid;

            if (valid) {
                $span.html(start.format('DD/MM/YYYY') + ' - ' + end.format('DD/MM/YYYY'));

                callback(start, end);
            }
            else {
                $span.html("");

                callback(null, null);
            }
        }

        var parametros = {
            language: "pt-BR",
            autoUpdateInput: false,
            autoApply: true,
            ranges: ranges,
            locale: {
                format: "DD/MM/YYYY",
                customRangeLabel: "Customizado"
            }
        };

        if (inicio && fim) {
            parametros.startDate = inicio.format("DD/MM/YYYY");
            parametros.endDate = fim.format("DD/MM/YYYY");
        }

        $this.daterangepicker(parametros, cb);

        cb(inicio, fim);

        if (inicio && fim) {
            $this.trigger("apply.daterangepicker");
        }

        return this;
    }

    $.fn.aplicarTimePicker = function () {
        this.daterangepicker({
            singleDatePicker: true,
            timePicker: true,
            language: "pt-BR",
            autoUpdateInput: false,
            timePicker24Hour: true,
            locale: {
                applyLabel: "Aplicar",
                cancelLabel: "Cancelar",
                format: "DD/MM/YYYY HH:mm"
            }
        }).on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('DD/MM/YYYY HH:mm')).valid();
        });

        return this;
    }

    $.fn.aplicarDatePicker = function () {
        this.daterangepicker({
            singleDatePicker: true,
            language: "pt-BR",
            autoUpdateInput: false,
            autoApply: true,
            locale: {
                applyLabel: "Aplicar",
                cancelLabel: "Cancelar",
                format: "DD/MM/YYYY"
            }
        }).on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('DD/MM/YYYY')).change();
        });

        return this;
    }

    $.fn.aplicarDateRangePicker = function () {
        this.daterangepicker({
            singleDatePicker: false,
            language: "pt-BR",
            autoUpdateInput: false,
            autoApply: true,
            locale: {
                applyLabel: "Aplicar",
                cancelLabel: "Cancelar",
                format: "DD/MM/YYYY"
            }
        }).on('apply.daterangepicker', function (ev, picker) {
            var $this = $(this);

            var start = picker.startDate.format('DD/MM/YYYY');
            var end = picker.endDate.format('DD/MM/YYYY');

            $this.val(start + " - " + end).change();
        });

        return this;
    }

    $.fn.aplicarMascaraDataHora = function () {
        this.mask("00/00/0000 00:00", {
            reverse: true
        });

        return this;
    }

    $.fn.aplicarMascaraData = function () {
        this.mask("00/00/0000", {
            reverse: true
        });

        return this;
    }

    $.fn.aplicarMascaraPreco = function () {
        this.maskMoney({ thousands: ".", decimal: "," });

        return this;
    }

    $.fn.aplicarMascaraCpfCnpj = function () {
        var $this = this;
        var options = {
            onKeyPress: function (cpfCnpj, e, field, options) {
                var masks = ['000.000.000-00#', '00.000.000/0000-00'];
                var mask = (cpfCnpj.length > 14) ? masks[1] : masks[0];
                $this.mask(mask, options);
            }
        };
        $this.mask('000.000.000-00#', options);

        return this;
    }

    $.fn.aplicarSelect2 = function () {
        this.select2();

        return this;
    }

}(window, jQuery));