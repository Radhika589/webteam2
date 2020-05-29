$(document).ready(function () {
    let selectedValue;
    let selectedText;
    let payment;
    $.getJSON("/Currency/GetCurrencies", null, function (data) {
        $.each(data, function () {
            $('#LocalCurrency').append('<option value=' + this.id + '>' + this.abbreviation + '</option>');
        });
    }).fail(function () { alert('No currencies found.') });

    $(async function () {
        $("#LocalCurrency").on("change", async function () {
            selectedText = await $('#LocalCurrency')[0].selectedOptions[0].text;
            Payment = await $('#Payment').value;
            if (selectedText && payment) {
                console.log(selectedText);
                console.log(payment);
                $.ajax({
                    url: `/currency/CalculateLocalCurrency?currencyAbbreviation=${selectedText}&amount=${payment}`,
                    success: function (data) {alert(data) }
                });
                //window.location.href = `/currency/CalculateLocalCurrency?currencyAbbreviation=${selectedText}&amount=${payment}`;

            }
            
        });
    });

    $(function () {
        $("#Payment").on("change", async function () {
            payment = $('#Payment')[0].value;
            if (selectedText && payment) {
                console.log(selectedText);
                console.log(payment);
            }
        });
    });
});