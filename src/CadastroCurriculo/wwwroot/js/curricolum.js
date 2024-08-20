(function (w, $) {
    "use strict";

    function Curricolum() {
        var self = this;
        self.setColorSalaryExpectation = setColorSalaryExpectation;
        self.formatCurrency = formatCurrency;
    }

    function setColorSalaryExpectation(salary, element, average) {
        debugger;
        var $element = $(element);

        if (salary < average) {
            $element.css('color', '#008000');
        }

        if (salary > average) {
            $element.css('color', '##0000ff');
        }
    }

    function formatCurrency(valor) {
        return valor.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
    }

    function validateCpf(cpf) {
        // Remove caracteres não numéricos
        cpf = cpf.replace(/[^\d]+/g, '');

        // Verifica se o CPF tem 11 dígitos e não é uma sequência de dígitos repetidos
        if (cpf.length !== 11 || /^(\d)\1{10}$/.test(cpf)) {
            return false;
        }

        // Função para calcular o dígito verificador
        function calculateDigit(cpf, peso) {
            let soma = 0;
            for (let i = 0; i < cpf.length; i++) {
                soma += cpf[i] * peso--;
            }
            let resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        // Calcula o primeiro dígito verificador
        let firstDigit = calculateDigit(cpf.slice(0, 9), 10);
        // Calcula o segundo dígito verificador
        let secondDigit = calculateDigit(cpf.slice(0, 10), 11);

        // Verifica se os dígitos verificadores estão corretos
        return cpf.endsWith(firstDigit.toString() + secondDigit.toString());
    }

    w.Curricolum = new Curricolum();
}(window, jQuery));