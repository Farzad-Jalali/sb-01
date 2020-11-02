using System.Collections.Generic;

namespace sb.ConsoleApp1.Domain
{
    public class InsurerConfigurationType
    {
        public List<Insurer> InsurerRates { get; set; }

        public class Insurer
        {
            public string Name { get; set; }
            public List<string> Parts { get; set; }
        }
    }
}