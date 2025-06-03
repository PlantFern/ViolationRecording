namespace ViolationsRecording.Models.Reports;

public record CarOwnerWithViolantialType
{
    public string FullName { get; set; } = string.Empty;
    public string Passport { get; set; } = string.Empty;
    public bool IsOwner { get; set; }
    public string ViolationType { get; set; } = string.Empty;
    public double FineAmount { get; set; }
}
