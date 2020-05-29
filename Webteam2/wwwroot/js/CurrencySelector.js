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
                $.ajax({
                    url: `/currency/CalculateLocalCurrency?currencyAbbreviation=${selectedText}&amount=${payment}`,
                    success: function (data) {
                        (data.localCurrency) ? $("#convertedToLocalCurrency").html
                            (`This equats to ${data.calculatedAmount} ${data.localCurrency} 
                            at a rate of 100 ${data.baseCurrency} = 
                            ${new Intl.NumberFormat('en-US', { style: 'currency', currency: `${data.localCurrency}` }).format(data.baseToLocalCurrencyRate * 100)} ${data.localCurrency}.`) :
                            $("#convertedToLocalCurrency").html(``);
                    }
                });
            }
        });
    });

    $(function () {
        $("#Payment").on("change", async function () {
            payment = $('#Payment')[0].value;
            if (selectedText && payment) {
            }
        });
    });
});