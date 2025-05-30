namespace ViolationsRecording.Models.Reports;

public record ViolationFactByProductionYear
{
    public DateTime FixationDate;
    public string FullName = string.Empty;
    public string StateNumber = string.Empty;
    public int ProductionYear;
    public string ViolationType = string.Empty;
}
