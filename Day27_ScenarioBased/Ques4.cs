using System;
using System.Collections.Generic;
using System.Linq;

public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType { Stock, Bond, Option, Future }

// 1. Generic portfolio
public class Portfolio<T> where T : IFinancialInstrument
{
    private Dictionary<T, int> _holdings = new();

    // TODO: Buy instrument
    public void Buy(T instrument, int quantity, decimal price)
    {
        if(quantity <= 0 || price <= 0)
            return;

        if(_holdings.ContainsKey(instrument))
            _holdings[instrument] += quantity;
        else
            _holdings[instrument] = quantity;
    }
    
    // TODO: Sell instrument
    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        if(!_holdings.ContainsKey(instrument) || _holdings[instrument] < quantity)
            return null;

        _holdings[instrument] -= quantity;

        if(_holdings[instrument] == 0)
            _holdings.Remove(instrument);
        return quantity * currentPrice;
    }

    // TODO: Calculate total value
    public decimal CalculateTotalValue()
    {
        return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }

    // TODO: Get top performing instrument
    public (T instrument, decimal returnPercentage)? GetTopPerformer(
        Dictionary<T, decimal> purchasePrices)
    {
        if(purchasePrices.Count == 0)
            return null;

        var result = purchasePrices.Select(p => (instrument: p.Key, returnPct: (p.Key.CurrentPrice - p.Value) / p.Value * 100))
            .OrderByDescending(r => r.returnPct).FirstOrDefault();
        return result;
    }
}

// 2. Specialized instruments
public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;
    public string CompanyName { get; set; }
    public decimal DividendYield { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;
    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }
}

// 3. Generic trading strategy
public class TradingStrategy<T> where T : IFinancialInstrument
{
    // TODO: Execute strategy on portfolio
    public void Execute(Portfolio<T> portfolio,
        Func<T, bool> buyCondition,
        Func<T, bool> sellCondition)
    {
        
    }

    // TODO: Calculate risk metrics
    public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
    {
        return new Dictionary<string, decimal>
        {
            { "Volatility", 0 },
            { "Beta", 0 },
            { "Sharpe Ratio", 0 }
        };
    }
}

// 4. Price history with generics
public class PriceHistory<T> where T : IFinancialInstrument
{
    private Dictionary<T, List<(DateTime, decimal)>> _history = new();

    // TODO: Add price point
    public void AddPrice(T instrument, DateTime timestamp, decimal price)
    {
        if(!_history.ContainsKey(instrument))
            _history[instrument] = new List<(DateTime, decimal)>();
        _history[instrument].Add((timestamp, price));
    }

    // TODO: Get moving average
    public decimal? GetMovingAverage(T instrument, int days)
    {
        if(!_history.ContainsKey(instrument))
            return null;

        var prices = _history[instrument].OrderByDescending(p => p.Item1).Take(days).Select(p => p.Item2);
        return prices.Any() ? prices.Average() : null;
    }

    // TODO: Detect trends
    public Trend DetectTrend(T instrument, int period)
    {
        return Trend.Sideways;
    }
}

public enum Trend { Upward, Downward, Sideways }

// 5. TEST SCENARIO
class Program9
{
    static void Main()
    {
        var stock = new Stock { Symbol = "ABC", CurrentPrice = 120 };
        var bond = new Bond { Symbol = "GOVT", CurrentPrice = 100 };

        var portfolio = new Portfolio<IFinancialInstrument>();
        portfolio.Buy(stock, 10, 100);
        portfolio.Buy(bond, 5, 95);
        Console.WriteLine(portfolio.CalculateTotalValue());

        var history = new PriceHistory<IFinancialInstrument>();
        history.AddPrice(stock, DateTime.Now, 120);
        history.AddPrice(stock, DateTime.Now.AddDays(-1), 110);
        Console.WriteLine(history.GetMovingAverage(stock, 2));
    }
}
