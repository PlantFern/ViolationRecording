namespace ViolationsRecording.Models.Reports;

public record CarOwnerWithViolantialType
{
    public string FullName = string.Empty;
    public string Passport = string.Empty;
    public bool IsOwner;
    public string ViolationType = string.Empty;
    public double FineAmount;
}
