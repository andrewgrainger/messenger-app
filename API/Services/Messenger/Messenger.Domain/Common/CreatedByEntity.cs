namespace Messenger.Domain.Common;

public abstract class CreatedByEntity : GuidEntity
{
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
}
