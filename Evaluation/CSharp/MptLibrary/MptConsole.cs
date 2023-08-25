namespace MptLibrary;

public class MptConsole : Mpt
{


    internal MptConsole(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
    {
    }

    public MptConsole(mpt_params params_) : base(params_)
    {
    }

    public override void OnLogMessage(string information)
    {
        Console.WriteLine(information.FilterString());
    }

    public override void OnNewTokenProcessed(string token)
    {
        Console.Write(token.FilterString());
    }
}