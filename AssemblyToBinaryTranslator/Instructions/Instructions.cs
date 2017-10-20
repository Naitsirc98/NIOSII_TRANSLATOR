using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyToBinaryTranslator
{
    public static class Instructions
    {

        private static Dictionary<string, Instruction> instructionSet;

        #region INITIALIZE INSTRUCTIONS

        static Instructions()
        {

            instructionSet = new Dictionary<string, Instruction>()
            {

                {"add", new Instruction(type:InstructionType.R, opxCode:0x31)},
                {"addi", new Instruction(type:InstructionType.I, expOrder:"BA", opCode:0x04)},
                {"and", new Instruction(type:InstructionType.R, opxCode:0x0e, opCode:0x3a)},
                {"andi", new Instruction(type:InstructionType.I, expOrder:"BA", opCode:0x0c)},

                {"beq", new Instruction(type:InstructionType.I, expOrder:"AB",opCode:0x26)},
                {"bge", new Instruction(type:InstructionType.I, expOrder:"AB", opCode:0x0e)},
                {"bgt", new Instruction(type:InstructionType.I, expOrder:"BA", opCode:0x0e)},
                {"ble", new Instruction(type:InstructionType.I, expOrder:"BA", opCode:0x0e)},
                {"blt", new Instruction(type:InstructionType.I, expOrder:"AB", opCode:0x16)},
                {"bne", new Instruction(type:InstructionType.I, expOrder:"AB",opCode:0x1e)},
                {"br", new Instruction(type:InstructionType.I, expOrder:"",opCode:0x06)},

                {"call", new Instruction(type:InstructionType.J,opCode:0)},
                {"callr", new Instruction(type:InstructionType.R, expOrder: "A", C:0x1f, opxCode: 0x1d, opCode:0x3a)},
                {"cmpeq", new Instruction(type:InstructionType.R, opxCode:0x20)},
                {"cmpeqi", new Instruction(type:InstructionType.I, expOrder:"BA", opCode:0x20)},
                {"cmpge", new Instruction(type:InstructionType.R, opxCode:0x08)},
                {"cmpgei", new Instruction(type:InstructionType.I, expOrder:"BA", opCode:0x08)},
                {"cmplt", new Instruction(type:InstructionType.R, opxCode:0x10)},
                {"cmplti", new Instruction(type:InstructionType.I, expOrder:"BA", opCode:0x10)},
                {"cmpgt", new Instruction(type:InstructionType.I, expOrder:"CBA", opCode:0x10)},
                {"cmpgti", new Instruction(type:InstructionType.R, expOrder:"BA", opxCode:0x08)},
                {"cmple", new Instruction(type:InstructionType.R, expOrder:"CBA", opxCode:0x08)},
                {"cmplei", new Instruction(type:InstructionType.I, opCode:0x08)},
                {"cmpne", new Instruction(type:InstructionType.R, opxCode:0x18)},
                {"cmpnei", new Instruction(type:InstructionType.I, opCode:0x18)},

                {"div", new Instruction(type:InstructionType.R, opxCode:0x25)},



                {"jmp", new Instruction(type:InstructionType.R, opxCode:0x0d)},
                {"jmpi", new Instruction(type:InstructionType.J, opCode:0x01)},

                {"ldb", new Instruction(type:InstructionType.I,expOrder:"B", opCode:0x07)},
                {"ldbio", new Instruction(type:InstructionType.I,expOrder:"B", opCode:0x07)},
                {"ldh", new Instruction(type:InstructionType.I, expOrder:"B",opCode:0x0f)},
                {"ldhio", new Instruction(type:InstructionType.I,expOrder:"B", opCode:0x0f)},
                {"ldw", new Instruction(type:InstructionType.I,expOrder:"B", opCode:0x17)},
                {"ldwio", new Instruction(type:InstructionType.I,expOrder:"B", opCode:0x17)},

                {"nor", new Instruction(type:InstructionType.R, opxCode:0x06)},

                {"or", new Instruction(type:InstructionType.R, opxCode:0x16)},
                {"orhi", new Instruction(type:InstructionType.I, expOrder:"BA", opCode:0x34)},

            };

        }

            #endregion

        public static Instruction Get(string name)
        {
            return instructionSet[name];
        }


    }
}
