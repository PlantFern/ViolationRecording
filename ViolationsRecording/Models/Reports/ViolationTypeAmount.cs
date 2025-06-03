namespace ViolationsRecording.Models.Reports;

public record ViolationTypeAmount
{
    public string Name { get; set; } = string.Empty;
    public int ViolationCount { get; set; }
}
