using AOC2019.Eight.Model;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Eight
{
    public class DayEight
    {
        public int PartOne(string input)
        {
            var inputIntList = BuildIntList(input);

            var node = BuildNode(inputIntList);

            return SumTreeMetadata(node);
        }

        public int PartTwo(string input)
        {
            var inputIntList = BuildIntList(input);

            var node = BuildNode(inputIntList);

            return node.Value;
        }

        private List<int> BuildIntList(string input)
        {
            return input.Split(' ').Select(int.Parse).ToList();
        }

        private int SumTreeMetadata(Node node)
        {
            var nodeSum = node.Metadata.Sum();

            return nodeSum + node.ChildNodes.Select(SumTreeMetadata).Sum();
        }

        private Node BuildNode(List<int> inputList)
        {
            var node = new Node()
            {
                ChildNodeCount = inputList[0],
                MetadataCount = inputList[1],
            };

            inputList.RemoveRange(0, 2);

            for (var i = 0; i < node.ChildNodeCount; i++)
            {
                node.ChildNodes.Add(BuildNode(inputList));
            }

            if (node.ChildNodeCount == node.ChildNodes.Count)
            {
                node.Metadata = inputList.GetRange(0, node.MetadataCount);
                inputList.RemoveRange(0, node.MetadataCount);                
            }

            return node;
        }
    }
}
