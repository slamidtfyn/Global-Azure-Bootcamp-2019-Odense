using System.Collections.Generic;
using System.Linq;

namespace GacBootcampWebsite.Models.ApplicationInsights
{
    public class ApplicationInsightsResult
    {
        public ApplicationInsightsResult()
        {
            Tables = new List<ApplicationInsightsTable>();
        }

        public List<ApplicationInsightsTable> Tables { get; set; }

        public ApplicationInsightsTable GetFirstTable()
        {
            return Tables.FirstOrDefault() != null ? Tables.FirstOrDefault() : null;
        }
    }
}
