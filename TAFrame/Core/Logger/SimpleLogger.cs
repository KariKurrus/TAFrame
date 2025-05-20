namespace TAFrame.Core.Logger
{
    public static class SimpleLogger
    {
        public static void Log(string message, Enums.LogLevel level = Enums.LogLevel.Log)
        {
            string prefix = level switch
            {
                Enums.LogLevel.Debug => "[DEBUG]",
                Enums.LogLevel.Error => "[ERROR]",
                _ => "[LOG]"
            };

            TestContext.Out.WriteLine($"{prefix} {message}");
        }
    }
}
