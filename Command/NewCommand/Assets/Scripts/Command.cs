using System;
using UnityEngine;

public class Command
{
    public Command(Action<GameObject> func) 
    {
        Execute = func;
    }
    public Action<GameObject> Execute { get; private set;}
}
