namespace ViolationsRecording.Models.Reports;

public record CarDTO
{
    public string Brand = string.Empty;
    public string Model = string.Empty;
    public string Color = string.Empty;
    public int ProductionYear;
    public string StateNumber = string.Empty;
    public double InsuranceCost;
}
