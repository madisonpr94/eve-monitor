using System;
using System.Collections.Generic;
using System.Linq;

namespace Eve.Models
{
    public class Graph
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Title
        {
            get; set;
        } = "Example Graph";

        public string Labels
        {
            get 
            {
                return string.Join(',', LabelValues.Select(x => "'" + x + "'"));
            }
        }

        public List<string> LabelValues
        {
            get; set;
        } = new List<string>() {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June"
        };

        public string Data
        {
            get
            {
                return "[" + 
                        string.Join(',', DataValues.Select(x => x.ToString())) +
                        "]";
            }
        }

        public List<int> DataValues
        {
            get; set;
        } = new List<int>() {0, 10, 5, 2, 20, 30, 45};

    }
}