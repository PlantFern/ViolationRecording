namespace ViolationsRecording.Models.Reports;

public record ViolationTypeDTO
{
    public string Name { get; set; } = string.Empty;
    public double FineAmount { get; set; }
}
