namespace ViolationsRecording.Models.Reports;

public record ViolationsByStateNumber
{
    public string StateNumber = string.Empty;
    public int ViolationsCount;
    public double TotalFineAmount;
}
