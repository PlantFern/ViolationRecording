namespace ViolationsRecording.Models.Reports;

public record ViolationTypeAmountWithFineAmount
{
    public string Name { get; set; } = string.Empty;
    public int ViolationCount { get; set; }
    public double FineAmountMin { get; set; }
    public double FineAmountMax { get; set; }
    public double FineAmountAverage { get; set; }
    public double FineAmountTotal { get; set; }
}
