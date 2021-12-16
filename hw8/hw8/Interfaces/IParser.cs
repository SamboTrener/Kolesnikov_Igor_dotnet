namespace hw8
{
    public interface IParser
    {
        internal bool TryParseOperationOrQuit(string arg, out Operation operation);
        internal bool TryParseOrQuit(string arg, out double val);
    }
}