using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyToBinaryTranslator
{
    public struct Instruction
    {

        public readonly int opxCode;
        public readonly int opCode;
        public readonly string expOrder;
        public readonly InstructionType type;
        public int A, B, C;

        public Instruction(InstructionType type, string expOrder = "CAB", int A = 0, int B = 0, int C = 0, 
            int opxCode = 0,int opCode = 0x3a)
        {
           
            this.type = type;
            this.expOrder = expOrder;
            this.opCode = opCode;
            this.opxCode = opxCode;
            this.A = A;
            this.B = B;
            this.C = C;
        }
    };
}
