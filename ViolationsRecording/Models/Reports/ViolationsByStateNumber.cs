namespace ViolationsRecording.Models.Reports;

public record ViolationsByStateNumber
{
    public string StateNumber { get; set; } = string.Empty;
    public int ViolationsCount { get; set; }
    public double TotalFineAmount { get; set; }
}
