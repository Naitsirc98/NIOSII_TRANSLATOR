using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyToBinaryTranslator
{
    public static class AssemblyTranslator
    {

        private static Dictionary<string, int> registers;

        #region INITIALIZE REGISTERS

        static AssemblyTranslator()
        {
            registers = new Dictionary<string, int>()
            {
                {"r0", 0}, {"zero",0},
                {"r1", 1}, {"at",1},
                {"r2", 2},
                {"r3", 3},
                {"r4", 4},
                {"r5", 5},
                {"r6", 6},
                {"r7", 7},
                {"r8", 8},
                {"r9", 9},
                {"r10", 10},
                {"r11", 11},
                {"r12", 12},
                {"r13", 13},
                {"r14", 14},
                {"r15", 15},
                {"r16", 16},
                {"r17", 17},
                {"r18", 18},
                {"r19", 19},
                {"r20", 20},
                {"r21", 21},
                {"r22", 22},
                {"r23", 23},
                {"r24", 24},
                {"r25", 25},
                {"r26", 26},
                {"r27", 27},
                {"r28", 28},
                {"r29", 29},
                {"r30", 29},
                {"r31", 29},

            };
        }

            #endregion

        public static string Translate(string input)
        {

            string name = input.Substring(0, input.IndexOf(" "));

            input = input.Replace(name,"").Trim();

            Instruction instruction = Instructions.Get(name);

            switch(instruction.type)
            {
                case InstructionType.R:
                    return TranslateRType(instruction, input);
                case InstructionType.I:
                    return TranslateIType(instruction, input);
                case InstructionType.J:
                    return TranslateJType(instruction, input);
                
            }

            throw new ArgumentException("That instruction do not exists!");

        }

        private static bool GetImmediate(string exp, out int imm)
        {

            if (exp.StartsWith("0x"))
            {
                imm = Convert.ToInt16(exp.Replace("0x", ""), 16);
            }
            else if (exp.StartsWith("0b"))
            {
                imm = Convert.ToInt16(exp.Replace("0b", ""), 2);

            }
            else
            {
                imm = Convert.ToInt16(exp, 10);
            }

            return true;

        }

        #region SPECIFIC TRANSLATIONS

        private static string TranslateJType(Instruction instruction, string input)
        {

            // IMM26 OP

            int imm;

            GetImmediate(input.Trim(), out imm);

            return BinaryUtilities.ToBinary(imm, 26) + BinaryUtilities.ToBinary(instruction.opCode, 6);
            
        }

        private static string TranslateIType(Instruction instruction, string input)
        {
            // A B IMM16 0P

            string[] regs = input.Split(new char[] { ',' });

            int a, b, imm;

            string exp;

            if (instruction.expOrder != "")
            {
                a = registers[regs[instruction.expOrder.IndexOf("A")].Trim()];
                b = registers[regs[instruction.expOrder.IndexOf("B")].Trim()];
                exp = regs[2].Trim();
            }
            else
            {
                a = b = 0;
                exp = regs[0].Trim();
            }

            GetImmediate(exp, out imm);

            string result = BinaryUtilities.ToBinary(a, 5) + BinaryUtilities.ToBinary(b, 5);

            result += BinaryUtilities.ToBinary(imm, 16) + BinaryUtilities.ToBinary(instruction.opCode, 6);

            return result;
        }

        private static string TranslateRType(Instruction instruction, string input)
        {
            // A B C OPX OP

            string[] regs = input.Split(new char[] {','});

            int a = 0, b = 0, c = 0;

            if (instruction.expOrder.Contains("A"))
            {
                a = registers[regs[instruction.expOrder.IndexOf("A")].Trim()];
            }
            else
            {
                a = instruction.A;
            }

            if (instruction.expOrder.Contains("B"))
            {
                a = registers[regs[instruction.expOrder.IndexOf("B")].Trim()];
            }
            else
            {
                a = instruction.B;
            }

            if (instruction.expOrder.Contains("C"))
            {
                a = registers[regs[instruction.expOrder.IndexOf("C")].Trim()];
            }
            else
            {
                a = instruction.C;
            }

            string result = BinaryUtilities.ToBinary(a, 5) + BinaryUtilities.ToBinary(b, 5) +
                BinaryUtilities.ToBinary(c, 5);

            result += BinaryUtilities.ToBinary(instruction.opxCode, 11,false) +
                BinaryUtilities.ToBinary(instruction.opCode, 6);

            return result;

        }

        #endregion
    }
}
