namespace CurrencyConverter;

public class Converter
{
    // Курс взят за 25.10.2023 (Предположим, что тут можно подключить API с актуальным крусом)
    private readonly decimal euroToRubRate = 98.96m;
    private readonly decimal dollarToRubRate = 93.55m;
    private readonly decimal euroToDollarRate = 0.95m;

    public decimal ConvertToCurrency(decimal amount, string fromCurrency, string toCurrency)
        => (fromCurrency, toCurrency) switch
        {
            ("€", "₽") => amount * euroToRubRate,
            ("$", "₽") => amount * dollarToRubRate,
            ("$", "€") => amount * euroToDollarRate,
            ("₽", "€") => amount / euroToRubRate,
            ("₽", "$") => amount / dollarToRubRate,
            ("€", "$") => amount / euroToDollarRate,
            _ => throw new InvalidOperationException("Невозможно конвертировать указанные валюты")
        };
}
