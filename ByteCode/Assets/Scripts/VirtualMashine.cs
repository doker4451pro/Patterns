using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VirtualMashine : MonoBehaviour
{
    [SerializeField] private Wizard[] wizards;
    
    private Instructions instruction;
    private Stack valueStack;
    private int value;

    private void Start()
    {
        valueStack = new Stack();
    }
    public void DoVm(byte[] bytecode) 
    {
        for (int i = 0; i < bytecode.Length; i++)
        {
            instruction = (Instructions)bytecode[i];

            switch (instruction) 
            {
                case Instructions.INST_GET_HEALTH:
                    int wizardHP = PopOffStack();       // which wizard to get health of
                    PushOnStack(wizards[wizardHP].Health);   // get the health and push it on stack
                    break;

                case Instructions.INST_SET_HEALTH:
                    int hPAmount = PopOffStack();   // how much to set health to
                    int hPWizard = PopOffStack();   // which wizard to set health of
                    wizards[hPWizard].Health = hPAmount;
                    break;

                case Instructions.INST_GET_WISDOM:  // Same as health for wisdom & agility
                    int wizardWP = PopOffStack();
                    PushOnStack(wizards[wizardWP].Wisdom);
                    break;

                case Instructions.INST_SET_WISDOM:
                    int wPAmount = PopOffStack();
                    int wPWizard = PopOffStack();
                    wizards[wPWizard].Wisdom = wPAmount;
                    break;

                case Instructions.INST_GET_AGILITY:
                    int wizardAP = PopOffStack();
                    PushOnStack(wizards[wizardAP].Agility);
                    break;

                case Instructions.INST_SET_AGILITY:
                    int aPamount = PopOffStack();
                    int aPwizard = PopOffStack();
                    wizards[aPwizard].Agility = aPamount;
                    break;

                case Instructions.INST_ADD:
                    int bAdd = PopOffStack();
                    int aAdd = PopOffStack();
                    PushOnStack(aAdd + bAdd);       // The addition result is stored on stack to be used with other instructions
                    print($"Added {bAdd} to {aAdd}");
                    break;

                case Instructions.INST_SUBTRACT:
                    int bSub = PopOffStack();
                    int aSub = PopOffStack();
                    PushOnStack(aSub - bSub);       // Same as addition for subtraction, multiplication and division
                    print($"Subtracted {bSub} from {aSub}");
                    break;

                case Instructions.INST_MULTIPLY:
                    int bMul = PopOffStack();
                    int aMul = PopOffStack();
                    PushOnStack(aMul * bMul);
                    print($"Multiplied {aMul} by {bMul}");
                    break;

                case Instructions.INST_DIVIDE:
                    int bDiv = PopOffStack();
                    int aDiv = PopOffStack();
                    PushOnStack(aDiv / bDiv);
                    print($"Divided {aDiv} by {bDiv}");
                    break;

                case Instructions.INST_LITERAL:
                    value = bytecode[++i];
                    PushOnStack(value);
                    print($"Added {value} on the stack");
                    break;

                default:
                    break;
            }
        }
    }

    void PushOnStack(int value)
    {
        valueStack.Push(value);
    }

    int PopOffStack()
    {
        if (valueStack.Count > 0)
            return (int)valueStack.Pop();
        else
        {
            print("Spell stack empty.");
            return 0;
        }
    }

    public enum Instructions : byte
    {
        INST_GET_HEALTH = 1,
        INST_SET_HEALTH = 2,
        INST_GET_WISDOM = 3,
        INST_SET_WISDOM = 4,
        INST_GET_AGILITY = 5,
        INST_SET_AGILITY = 6,
        // An instruction to set values required for methods' arguments
        INST_LITERAL = 7,
        INST_ADD = 8,
        INST_SUBTRACT = 9,
        INST_MULTIPLY = 10,
        INST_DIVIDE = 11,
    }
}
