using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Seven.Model
{
    public class InstructionNode
    {
        public string Instruction { get; set; }

        public List<InstructionNode> Previous { get; set; } = new List<InstructionNode>();

        public List<InstructionNode> Next { get; set; } = new List<InstructionNode>();

        public int Duration { get; set; }

        public int Remaining { get; set; }

        public int WorkerNumber { get; set; }
    }
}
