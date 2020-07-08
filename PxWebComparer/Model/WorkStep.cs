using System.Collections.Generic;

namespace PxWebComparer.Model
{
    public class WorkStep
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public Dictionary<string, string> Params { get; private set; }

        public WorkStep()
        {
            Params = new Dictionary<string, string>();
        }
    }
}