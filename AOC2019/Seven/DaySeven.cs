using AOC2019.Seven.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Seven
{
    public class DaySeven
    {
        public string PartOne(IEnumerable<string> input)
        {
            var instructions = BuildInstructions(input).ToList();
            
            var instructionNodes = BuildInstructionNodes(instructions);

            instructionNodes = BuildRelationships(instructionNodes, instructions);

            var orderedInstructionNodes = OrderNodes(instructionNodes);

            return string.Concat(orderedInstructionNodes.Select(i => i.Instruction));
        }

        public IList<Instruction> BuildInstructions(IEnumerable<string> input)
        {
            return input.Select(i => new Instruction() { Current = i.Substring(5, 1), Next = i.Substring(36, 1) }).ToList();
        }

        public IList<InstructionNode> BuildInstructionNodes(IList<Instruction> instructions)
        {
            var befores = instructions.Select(i => i.Current);
            var afters = instructions.Select(i => i.Next);

            return befores.Union(afters).Distinct().Select(i => new InstructionNode() { Instruction = i }).ToList();
        }

        public IList<InstructionNode> OrderNodes(IList<InstructionNode> instructionNodes)
        {
            InstructionNode node = GetNextNode(instructionNodes);
            List<InstructionNode> orderedInstructionNodes = new List<InstructionNode>();

            while(node != null)
            {
                orderedInstructionNodes.Add(node);

                node.Next.ForEach(n => n.Previous.Remove(node));
                
                instructionNodes.Remove(node);

                node = GetNextNode(instructionNodes);
            }

            return orderedInstructionNodes;
        }

        public IList<InstructionNode> BuildRelationships(IList<InstructionNode> instructionNodes, IList<Instruction> instructions)
        {
            instructionNodes = instructionNodes.ToList();

            foreach (var instruction in instructions)
            {
                var current = instructionNodes.First(i => i.Instruction == instruction.Current);
                var next = instructionNodes.First(i => i.Instruction == instruction.Next);

                current.Next.Add(next);
                next.Previous.Add(current);
            }

            return instructionNodes;
        }

        public InstructionNode GetNextNode(IList<InstructionNode> instructionNodes)
        {
            return instructionNodes.Where(i => !i.Previous.Any()).OrderBy(i => i.Instruction).FirstOrDefault();

        }
    }
}
