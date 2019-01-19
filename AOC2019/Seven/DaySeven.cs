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

        public int PartTwo(IEnumerable<string> input)
        {
            var instructions = BuildInstructions(input).ToList();

            var instructionNodes = BuildInstructionNodes(instructions);

            instructionNodes = BuildRelationships(instructionNodes, instructions);

            return CalculateTimeTaken(instructionNodes, 5);
        }

        public IList<Instruction> BuildInstructions(IEnumerable<string> input)
        {
            return input.Select(i => new Instruction() { Current = i.Substring(5, 1), Next = i.Substring(36, 1) }).ToList();
        }

        public IList<InstructionNode> BuildInstructionNodes(IList<Instruction> instructions)
        {
            var befores = instructions.Select(i => i.Current);
            var afters = instructions.Select(i => i.Next);

            var instructionNodes = befores.Union(afters).Distinct().Select(i => new InstructionNode() { Instruction = i }).OrderBy(i => i.Instruction).ToList();

            var duration = 1;

            foreach (var instructionNode in instructionNodes)
            {
                instructionNode.Duration = 60 + duration;
                instructionNode.Remaining = 60 + duration;

                duration++;
            }

            return instructionNodes;
        }

        public void AssignWorkers(IList<InstructionNode> instructionNodes, IList<Worker> workers)
        {
            foreach (var worker in workers.Where(w => !w.Busy))
            {
                var node = GetNextFreeNode(instructionNodes);

                if (node != null)
                {
                    worker.Busy = true;
                    node.Worker = worker;
                }                 
            }
        }

        public void DoWork(IList<InstructionNode> instructionNodes)
        {
            foreach (var inProgressNode in instructionNodes.Where(n => n.Worker != null))
            {
                inProgressNode.Remaining--;
            }
        }

        public IList<InstructionNode> CompleteWork(IList<InstructionNode> instructionNodes)
        {
            foreach (var completedNode in instructionNodes.Where(n => n.Remaining == 0))
            {
                completedNode.Worker.Busy = false;
                completedNode.Worker = null;

                completedNode.Next.ForEach(n => n.Previous.Remove(completedNode));
            }

            return instructionNodes.Where(n => n.Remaining > 0).ToList();
        }

        public IList<Worker> BuildWorkers(int numberOfWorkers)
        {
           return Enumerable.Range(0, numberOfWorkers).Select(w => new Worker() { Id = w }).ToList();
        }

        public int CalculateTimeTaken(IList<InstructionNode> instructionNodes, int numberOfWorkers)
        {
            var workers = BuildWorkers(numberOfWorkers);
            var second = 0;

            while(instructionNodes.Any())
            {
                AssignWorkers(instructionNodes, workers);

                DoWork(instructionNodes);

                instructionNodes = CompleteWork(instructionNodes);

                second++;
            }
            
            return second;
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

        public InstructionNode GetNextFreeNode(IList<InstructionNode> instructionNodes)
        {
            return instructionNodes.Where(i => !i.Previous.Any() && i.Worker == null).OrderBy(i => i.Instruction).FirstOrDefault();
        }
    }
}
