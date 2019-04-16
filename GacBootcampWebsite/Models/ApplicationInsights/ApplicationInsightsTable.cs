using System.Collections.Generic;

namespace GacBootcampWebsite.Models.ApplicationInsights
{
    public class ApplicationInsightsTable
    {
        public string TableName { get; set; }
        public List<Column> Columns { get; set; }
        public List<List<object>> Rows { get; set; }
    }

    public class Column
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

}
