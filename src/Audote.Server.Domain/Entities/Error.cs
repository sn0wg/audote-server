namespace Audote.Server.Domain.Entities;

public struct Error
{
    public IList<ErrorItem> Errors { get; set; }
}

public struct ErrorItem
{
    public string Code { get; set; }
    public string Message { get; set; }
}
