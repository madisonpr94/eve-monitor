using System;
using System.Collections.Generic;

namespace Eve.Models
{
    public class Graph
    {
        public string Labels
        {
            get
            {
                return @"'January',
                    'February',
                    'March',
                    'April',
                    'May',
                    'June',";
            }
        }

        public string Title
        {
            get; set;
        } = "Example Graph";

    }
}