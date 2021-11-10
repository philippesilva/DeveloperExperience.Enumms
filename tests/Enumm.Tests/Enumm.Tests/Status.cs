using System.ComponentModel;

namespace Enumms.Tests
{
    public enum Status
    {
        [Description("Success")]
        Success,

        [Description("Information")]
        Information,

        [Description("Error")]
        Error,

        [Description("Warning")]
        Warning,
    }
}
