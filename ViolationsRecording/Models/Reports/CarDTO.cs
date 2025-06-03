namespace ViolationsRecording.Models.Reports;

public record CarDTO
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int ProductionYear { get; set; }
    public string StateNumber { get; set; } = string.Empty;
    public double InsuranceCost { get; set; }
}
