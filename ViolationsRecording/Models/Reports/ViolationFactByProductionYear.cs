namespace ViolationsRecording.Models.Reports;

public record ViolationFactByProductionYear
{
    public DateTime FixationDate { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string StateNumber { get; set; } = string.Empty;
    public int ProductionYear { get; set; }
    public string ViolationType { get; set; } = string.Empty;
}
