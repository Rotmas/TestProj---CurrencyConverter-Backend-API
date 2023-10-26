namespace CurrencyConverter.Tests;
public class CurrencyConverterTests : TestBase
{
    [Fact]
    public void ConvertToRub_ValidEuroAmount_ShouldReturnCorrectRubAmount()
    {
        // Arrange
        var converter = new Converter();
        decimal euroAmount = 10;
        string fromCurrency = "€";
        string toCurrency = "₽";

        // Act
        decimal result = converter.ConvertToCurrency(euroAmount, fromCurrency, toCurrency);

        // Assert
        Assert.Equal(989.60m, result);
    }

    [Fact]
    public void ConvertToRub_ValidDollarAmount_ShouldReturnCorrectRubAmount()
    {
        // Arrange
        var converter = new Converter();
        decimal dollarAmount = 12;
        string fromCurrency = "$";
        string toCurrency = "₽";
        // Act
        decimal result = converter.ConvertToCurrency(dollarAmount, fromCurrency, toCurrency);

        // Assert
        Assert.Equal(1122.60m, result);
    }

    [Fact]
    public void ConvertToInvalidCurrency_ShouldThrowException()
    {
        // Arrange
        var converter = new Converter();
        decimal dollarAmount = 12;
        string fromCurrency = "$";
        string invalidCurrency = "byn"; //Не поддерживаемая валюта

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => converter.ConvertToCurrency(dollarAmount, fromCurrency, invalidCurrency));
    }
}