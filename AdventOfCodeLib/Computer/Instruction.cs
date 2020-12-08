using System;

namespace AdventOfCodeLib.Computer
{
    public class Instruction
    {
        public Instruction(string name, string value)
        {
            InstructionType = (InstructionTypes) Enum.Parse(typeof(InstructionTypes), name);
            Value = int.Parse(value);
        }

        public Instruction(InstructionTypes toggleInsType, int value)
        {
            InstructionType = toggleInsType;
            Value = value;
        }

        public InstructionTypes InstructionType { get; }
        public int Value { get; }

        public enum InstructionTypes {nop, jmp, acc};
    }
}