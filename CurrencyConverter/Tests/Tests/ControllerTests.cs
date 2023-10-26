using System.Net;

namespace CurrencyConverter.Tests;
public class CurrencyControllerTests : TestBase
{
    [Fact]
    public async Task GetSumAndConvertToRub_ValidConversion_ShouldReturnOkResult()
    {
        // Arrange
        var euro = new MoneyBatch()
        {
            Currency = "€",
            Value = 10
        };
        var dollar = new MoneyBatch()
        {
            Currency = "$",
            Value = 12
        };
        var request = new Request
        {
            Summa = new MoneyBatch[] { euro, dollar },
            ResultCurrency = "₽"
        };
        // Act
        var result = await Api.Currency.GetSumAndConvert(request);

        // Assert
        decimal expectedResult = 10 * 98.96m + 12 * 93.55m;
        Assert.Equal(expectedResult, result.Sum);
    }

    [Fact]
    public async Task GetSumAndConvertToRub_InvalidCurrency_ShouldReturnBadRequest()
    {
        // Arrange
        var euro = new MoneyBatch()
        {
            Currency = "byn", //Не поддерживаемая валюта
            Value = 10
        };
        var dollar = new MoneyBatch()
        {
            Currency = "$",
            Value = 12
        };
        var request = new Request
        {
            Summa = new MoneyBatch[] { euro, dollar },
            ResultCurrency = "€"
        };
        // Act
        var result = await Assert.ThrowsAsync<HttpRequestException>(() => Api.Currency.GetSumAndConvert(request));
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest ,result.StatusCode);
    }

    [Fact]
    public async Task GetSumAndConvertToUSD_ValidConversion_ShouldReturnOkResult()
    {
        // Arrange
        var euro = new MoneyBatch()
        {
            Currency = "€",
            Value = 10
        };
        var rub = new MoneyBatch()
        {
            Currency = "₽",
            Value = 100
        };
        var request = new Request
        {
            Summa = new MoneyBatch[] { euro, rub },
            ResultCurrency = "$"
        };
        // Act
        var result = await Api.Currency.GetSumAndConvert(request);

        // Assert
        Assert.InRange(result.Sum, 11.59m, 11.60m);
    }
}
