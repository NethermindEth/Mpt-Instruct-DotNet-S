namespace MptLibrary;

public class MptActionBased : Mpt
{
    public Action<string> LogMessageEvent;
    public Action<string> NewTokenProcessedEvent;

    internal MptActionBased(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
    {
    }

    public MptActionBased(mpt_params params_) : base(params_)
    {
    }

    public override void OnLogMessage(string information)
    {
        LogMessageEvent?.Invoke(information);
    }

    public override void OnNewTokenProcessed(string token)
    {
        NewTokenProcessedEvent?.Invoke(token);
    }
}