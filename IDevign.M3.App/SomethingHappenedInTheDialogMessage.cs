using System;

namespace IDevign.M3.App
{
    /// <summary>
    /// A trivial message about something that happened somewhere...
    /// </summary>
    public class SomethingHappenedInTheDialogMessage
    {
        public SomethingHappenedInTheDialogMessage(string info)
        {
            this.Info = info;
        }

        public string Info { get; private set; }
    }
}