using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeLib.Computer
{
    public class Computer
    {
        private readonly List<Instruction> m_Instructions;
        private readonly HashSet<int> m_PreviousExecutedInstructions = new HashSet<int>();
        private int m_CurrentInstruction;
        public int Acc { get; private set; }

        public ComputerState State { get; private set; } = ComputerState.Ready;

        public Computer(IEnumerable<string> enumerable) : this(Parse(enumerable))
        {
        }

        private Computer(List<Instruction> instructions)
        {
            m_Instructions = instructions;
        }

        private static List<Instruction> Parse(IEnumerable<string> instructions) => instructions.Select(Parse).ToList();

        private static Instruction Parse(string instruction)
        {
            var split = instruction.Split(' ');
            return new Instruction(split[0], split[1]);
        }

        public static Computer FindAWorkingComputer(IEnumerable<string> textInstructions)
        {
            var instructions = Parse(textInstructions);
            
            var possibleErrors = instructions.Select((ins, i) => (ins, i))
                                             .Where(ins => ins.ins.InstructionType != Instruction.InstructionTypes.acc)
                                             .Select(i => i.i);

            return possibleErrors.Select(index => CreateComputerWithTweak(index, instructions.ToList()))
                                 .First(val => val.State == ComputerState.Finished);
        }

        private static Computer CreateComputerWithTweak(int index, List<Instruction> toList)
        {
            var currentInsType = toList[index].InstructionType;
            if (currentInsType == Instruction.InstructionTypes.acc) throw new ArgumentException();
            var toggleInsType = currentInsType == Instruction.InstructionTypes.jmp
                                    ? Instruction.InstructionTypes.nop
                                    : Instruction.InstructionTypes.jmp;
            toList[index] = new Instruction(toggleInsType, toList[index].Value);

            var computer = new Computer(toList);
            computer.Run();
            return computer;
        }
        
        public void Run()
        {
            while (m_PreviousExecutedInstructions.Add(m_CurrentInstruction))
            {
                var instruction = m_Instructions[m_CurrentInstruction];
                switch (instruction.InstructionType)
                {
                    case Instruction.InstructionTypes.acc:
                        Acc += instruction.Value;
                        break;
                }

                if (!UpdateNextInstructions(instruction.InstructionType == Instruction.InstructionTypes.jmp
                                               ? instruction.Value
                                               : 1))
                {
                    return;
                }
            }

            State = ComputerState.InfiniteLoop;
        }

        private bool UpdateNextInstructions(int jmpNextInstruction)
        {
            m_CurrentInstruction += jmpNextInstruction;
            if (m_CurrentInstruction < m_Instructions.Count)
            {
                return true;
            }

            State = ComputerState.Finished;
            return false;
        }

        public enum ComputerState {Ready, Finished, InfiniteLoop}

    }
}