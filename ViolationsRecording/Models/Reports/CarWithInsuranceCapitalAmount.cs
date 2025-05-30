namespace ViolationsRecording.Models.Reports;

public record CarWithInsuranceCapitalAmount
{
    public string FullName;
    public string Brand = string.Empty;
    public string Model = string.Empty;
    public string Color = string.Empty;
    public int ProductionYear;
    public string StateNumber = string.Empty;
    public double InsuranceCost;
    public double InsuranceCapitalAmount;
}
