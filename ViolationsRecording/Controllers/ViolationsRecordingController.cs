

using ViolationsRecording.Models;

namespace ViolationsRecording.Controllers;

public class ViolationsRecordingController(ViolationsRecordingContext db)
{
    public ViolationsRecordingController() : this(new ViolationsRecordingContext()) { }
}
