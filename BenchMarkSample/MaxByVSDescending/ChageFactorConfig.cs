namespace BenchMarkSample.MaxByVSDescending;

public class ChargeFactorConfig
{
    public string ConfigName { get; set; }
    public int ChargeAfterStockAge { get; set; }
    public decimal ChargeAmountPerCbm { get; set; }

    public ChargeFactorConfig(
        string configName,
        int chargeAfterStockAge,
        decimal chargeAmountPerCbm)
    {
        ConfigName = configName;
        ChargeAfterStockAge = chargeAfterStockAge;
        ChargeAmountPerCbm = chargeAmountPerCbm;
    }
}