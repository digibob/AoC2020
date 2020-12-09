using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Puzzle08
    {
        enum InstructionType
        {
            Nop,
            Acc,
            Jmp,
        }

        class HandheldProgram
        {
            public HandheldProgram(string[] lines)
            {
                ProgramCounter = 0;
                Accumulator = 0;

                Instructions = lines.Select(l =>
                {
                    string[] split = l.Split(' ');
                    int value = split[1].StartsWith("+")
                        ? int.Parse(split[1].Substring(1))
                        : -int.Parse(split[1].Substring(1));

                    switch (split[0])
                    {
                        case "acc":
                            return new Tuple<InstructionType, int>(InstructionType.Acc, value);

                        default:
                        case "nop":
                            return new Tuple<InstructionType, int>(InstructionType.Nop, value);

                        case "jmp":
                            return new Tuple<InstructionType, int>(InstructionType.Jmp, value);
                    }
                }).ToArray();
            }

            public HandheldProgram(HandheldProgram other)
            {
                Accumulator = other.Accumulator;
                Instructions = (Tuple<InstructionType, int>[])other.Instructions.Clone();
                ProgramCounter = other.ProgramCounter;
            }

            public void StepOnce()
            {
                if (ProgramCounter < 0 || ProgramCounter >= Instructions.Length)
                {
                    return;
                }

                switch (Instructions[ProgramCounter].Item1)
                {
                    case InstructionType.Acc:
                        Accumulator += Instructions[ProgramCounter].Item2;
                        ProgramCounter++;
                        break;

                    case InstructionType.Jmp:
                        ProgramCounter += Instructions[ProgramCounter].Item2;
                        break;

                    case InstructionType.Nop:
                        ProgramCounter++;
                        break;
                }
            }

            public int Accumulator { get; private set; }
            public int ProgramCounter { get; private set; }

            public Tuple<InstructionType, int>[] Instructions { get; private set; }
        }

        public Puzzle08(string[] lines)
        {
            program = new HandheldProgram(lines);
        }

        public void Run()
        {
            RunTest1();
            RunTest2();
        }

        private void RunTest1()
        {
            HandheldProgram test1Program = new HandheldProgram(program);

            HashSet<int> visitedInstructions = new HashSet<int>();

            int lastAccumulator = 0;
            while (!visitedInstructions.Contains(test1Program.ProgramCounter))
            {
                lastAccumulator = test1Program.Accumulator;
                visitedInstructions.Add(test1Program.ProgramCounter);
                test1Program.StepOnce();
            }

            Console.WriteLine("{0}", lastAccumulator);
        }

        private void RunTest2()
        {
            for (int index = 0; index < program.Instructions.Length; index++)
            {
                InstructionType instructionType = program.Instructions[index].Item1;
                if (instructionType != InstructionType.Acc)
                {
                    int value = program.Instructions[index].Item2;

                    HandheldProgram programCopy = new HandheldProgram(program);
                    programCopy.Instructions[index] = instructionType == InstructionType.Nop
                        ? new Tuple<InstructionType, int>(InstructionType.Jmp, value)
                        : new Tuple<InstructionType, int>(InstructionType.Nop, value);


                    HashSet<int> visitedInstructions = new HashSet<int>();

                    while (!visitedInstructions.Contains(programCopy.ProgramCounter)
                        && programCopy.ProgramCounter != programCopy.Instructions.Length)
                    {
                        visitedInstructions.Add(programCopy.ProgramCounter);
                        programCopy.StepOnce();
                    }

                    if (programCopy.ProgramCounter == programCopy.Instructions.Length)
                    {
                        Console.WriteLine("{0}", programCopy.Accumulator);
                        return;
                    }
                }
            }
        }

        private HandheldProgram program;
    }
}
