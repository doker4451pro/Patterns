using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private int health = 2;
    public void ChangeHealth(int delta) =>
        health +=delta;
    //
    public void Clone(Person clonedPeron) 
    {
        health = clonedPeron.health;
    }  
}
