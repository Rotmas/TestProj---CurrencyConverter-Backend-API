using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter;

[Route("api/currency")]
[ApiController]
public class CurrencyController : ControllerBase
{
    readonly Converter Сonverter;

    public CurrencyController(Converter converter)
        => Сonverter = converter;

    [HttpPost("convert")]
    public ActionResult<Response> GetSumAndConvertToRub([FromBody] Request request)
    {
        try
        {
            var result = new Response()
            {
                Sum = request.Summa.Sum(moneyBatch 
                    => Сonverter.ConvertToCurrency(moneyBatch.Value, moneyBatch.Currency, request.ResultCurrency))
            };
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public class Request
{
    public MoneyBatch[] Summa { get; init; } = Array.Empty<MoneyBatch>();
    public string ResultCurrency { get; init; } = string.Empty;
}

public class MoneyBatch
{
    public string Currency { get; init; } = string.Empty;
    public decimal Value { get; init; }
}

public class Response
{
    public decimal Sum { get; init; }
}