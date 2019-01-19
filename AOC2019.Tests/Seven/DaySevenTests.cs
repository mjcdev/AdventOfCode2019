using AOC2019.Seven;
using AOC2019.Seven.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AOC2019.Tests.Seven
{
    public class DaySevenTests
    {
        private const string FileName = @"Seven/Seven.txt";

        [Fact]
        public void PartOne()
        {
            var input = File.ReadAllLines(FileName);

            var result = NewDay().PartOne(input);
        }

        [Fact]
        public void PartTwo()
        {
            var input = File.ReadAllLines(FileName);

            var result = NewDay().PartTwo(input);
        }

        [Fact]
        public void BuildRelationships()
        {
            var instructions = new List<Instruction>()
            {
                new Instruction() { Current = "C", Next = "A" },
                new Instruction() { Current = "C", Next = "F" },
                new Instruction() { Current = "A", Next = "B" },
                new Instruction() { Current = "A", Next = "D" },
                new Instruction() { Current = "B", Next = "E" },
                new Instruction() { Current = "D", Next = "E" },
                new Instruction() { Current = "F", Next = "E" }
            };

            var instructionNodes = new List<InstructionNode>()
            {
                new InstructionNode() { Instruction = "A" },
                new InstructionNode() { Instruction = "B" },
                new InstructionNode() { Instruction = "C" },
                new InstructionNode() { Instruction = "D" },
                new InstructionNode() { Instruction = "E" },
                new InstructionNode() { Instruction = "F" },
            };


            var built = NewDay().BuildRelationships(instructionNodes, instructions);
            


        }

        private DaySeven NewDay()
        {
            return new DaySeven();
        }
    }
}
