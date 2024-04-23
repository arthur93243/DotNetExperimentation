using BenchmarkDotNet.Attributes;

namespace BenchMarkSample.MaxByVSDescending;

[MaxColumn, MinColumn, MeanColumn]
public class MaxByVSDescending
{
    readonly List<ChargeFactorConfig> chargeFactorConfigList;
    readonly int stockAge;


    public MaxByVSDescending()
    {
        chargeFactorConfigList =
        [
            new("", 1, 0.7m),
            new("", 10, 0.9m),
            new("", 31, 1m),
            new("", 101, 2.05m)
        ];

        stockAge = 104;
    }

    [Benchmark]
    public void WhereMaxBy()
    {
        var result =
            chargeFactorConfigList
                .Where(c => stockAge >= c.ChargeAfterStockAge)
                .MaxBy(x => x.ChargeAfterStockAge)
                .ChargeAmountPerCbm;
    }

    [Benchmark]
    public void DescendingFirst()
    {
        var result =
            chargeFactorConfigList
                .OrderByDescending(c => c.ChargeAfterStockAge)
                .First(x => stockAge >= x.ChargeAfterStockAge)
                .ChargeAmountPerCbm;
    }

    [Benchmark]
    public void DescendingMaxBy()
    {
        var result =
            chargeFactorConfigList
                .OrderByDescending(c => c.ChargeAfterStockAge)
                .MaxBy(x => stockAge >= x.ChargeAfterStockAge)
                .ChargeAmountPerCbm;
    }
}