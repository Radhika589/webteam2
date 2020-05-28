$(document).ready(function () {
    let selectedValue;
    let selectedText;
    let Payment;
    $.getJSON("/Currency/GetCurrencies", null, function (data) {
        $.each(data, function () {
            $('#LocalCurrency').append('<option value=' + this.id + '>' + this.abbreviation + '</option>');
        });
    }).fail(function () { alert('No currencies found.') });

    $(function () {
        $("#LocalCurrency").on("change", async function () {
            selectedValue = $('#LocalCurrency')[0].selectedOptions[0].value;
            selectedText = $('#LocalCurrency')[0].selectedOptions[0].text;
            Paymeny = $('#Payment').value;
            console.log(selectedValue);
            console.log(selectedText);            
        });
    });

    $(function () {
        $("#Payment").on("change", async function () {
            Payment = $('#Payment')[0].value;
            console.log(Payment);            
        });
    });
});