(function () {
    "use strict";

    jQuery.validator.addMethod("cpf", function (value, element, params) {
        if (this.optional(element)) {
            return true;
        }
        
        return cpfValido(value);
    }, "Cpf inválido");

    jQuery.validator.addMethod("cnpj", function (value, element, params) {
        if (this.optional(element)) {
            return true;
        }

        return cnpjValido(value);
    }, "Cnpj inválido");

    jQuery.validator.addMethod("cpfcnpj", function (value, element, params) {
        if (this.optional(element)) {
            return true;
        }

        return cpfValido(value) || cnpjValido(value);
    }, "CPF ou CNPJ inválido");

    $.validator.addMethod("maxDate", function (value, element) {
        if (this.optional(element)) {
            return true;
        }

        var curDate = moment().toDate();
        var inputDate = moment(value, "DD/MM/yyyy").toDate();

        return inputDate < curDate
    }, "Data inválida"); 

    jQuery.validator.unobtrusive.adapters.add('maxDate', {}, function (options) {
        options.rules['maxDate'] = true;
        options.messages['maxDate'] = options.message;
    });

    jQuery.validator.unobtrusive.adapters.add('cpfcnpj', {}, function (options) {
        options.rules['cpfcnpj'] = true;
        options.messages['cpfcnpj'] = options.message;
    });

    jQuery.validator.unobtrusive.adapters.add('cpf', {}, function (options) {
        options.rules['cpf'] = true;
        options.messages['cpf'] = options.message;
    });

    jQuery.validator.unobtrusive.adapters.add('cnpj', {}, function (options) {
        options.rules['cnpj'] = true;
        options.messages['cnpj'] = options.message;
    });

    $.validator.methods.range = function (value, element, param) {
        if (element.type === 'checkbox') {
            // if it's a checkbox return true if it is checked
            return element.checked;
        }

        var globalizedValue = value.replaceAll(".", "").replace(",", ".");

        return this.optional(element) ||
            (globalizedValue >= param[0] &&
                globalizedValue <= param[1]);
    };

    $.validator.methods.number = function (value, element) {
        return this.optional(element) ||
            /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/
                .test(value);
    };

    function cpfValido(value) {
        var cpf = value.replace(/[^\d]+/g, '');
        if (cpf == '') return false;
        if (cpf.length != 11 ||
            cpf == "00000000000" ||
            cpf == "11111111111" ||
            cpf == "22222222222" ||
            cpf == "33333333333" ||
            cpf == "44444444444" ||
            cpf == "55555555555" ||
            cpf == "66666666666" ||
            cpf == "77777777777" ||
            cpf == "88888888888" ||
            cpf == "99999999999")
            return false;
        var add = 0;
        for (var i = 0; i < 9; i++)
            add += parseInt(cpf.charAt(i)) * (10 - i);
        var rev = 11 - (add % 11);
        if (rev == 10 || rev == 11)
            rev = 0;
        if (rev != parseInt(cpf.charAt(9)))
            return false;
        add = 0;
        for (i = 0; i < 10; i++)
            add += parseInt(cpf.charAt(i)) * (11 - i);
        rev = 11 - (add % 11);
        if (rev == 10 || rev == 11)
            rev = 0;
        if (rev != parseInt(cpf.charAt(10)))
            return false;
        return true;
    }

    function cnpjValido(valor) {
        var cnpj = valor.replace(/[^\d]+/g, '');

        if (cnpj == '') return false;

        if (cnpj.length != 14)
            return false;

        // Elimina CNPJs invalidos conhecidos
        if (cnpj == "00000000000000" ||
            cnpj == "11111111111111" ||
            cnpj == "22222222222222" ||
            cnpj == "33333333333333" ||
            cnpj == "44444444444444" ||
            cnpj == "55555555555555" ||
            cnpj == "66666666666666" ||
            cnpj == "77777777777777" ||
            cnpj == "88888888888888" ||
            cnpj == "99999999999999")
            return false;

        // Valida DVs
        var tamanho = cnpj.length - 2
        var numeros = cnpj.substring(0, tamanho);
        var digitos = cnpj.substring(tamanho);
        var soma = 0;
        var pos = tamanho - 7;
        for (var i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        var resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0))
            return false;

        tamanho = tamanho + 1;
        numeros = cnpj.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1))
            return false;

        return true;
    }
}());
