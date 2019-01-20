using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Eight.Model
{
    public class Node
    {
        public int ChildNodeCount { get; set; }

        public int MetadataCount { get; set; }

        public List<Node> ChildNodes { get; set; } = new List<Node>();

        public List<int> Metadata { get; set; } = new List<int>();

        public int Value => CalculateValue();

        private int CalculateValue()
        {
            if (!ChildNodes.Any())
            {
                return Metadata.Sum();
            }
            else
            {
                var value = 0;

                foreach(var metadataEntry in Metadata)
                {
                    var index = metadataEntry - 1;
                    
                    if (index >= 0 && metadataEntry <= ChildNodeCount)
                    { 
                        value = value + ChildNodes[index].Value;
                    }
                }

                return value;
            }
        }
    }
}
