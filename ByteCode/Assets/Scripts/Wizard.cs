using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int health = 45;
    [SerializeField] private int wisdom = 11;
    [SerializeField] private int agility = 7;

    public int Health 
    { get 
        {
            Debug.Log($"{_name} health-{health} now");
            return health;
        }
        set 
        {
            health = value;
            Debug.Log($"{_name} health  has become {health}");
        }
    }
    public int Wisdom
    {
        get
        {
            Debug.Log($"{_name} wisdom-{wisdom} now");
            return wisdom;
        }
        set
        {
            wisdom = value;
            Debug.Log($"{_name} wisdom  has become {wisdom}");
        }
    }
    public int Agility
    {
        get
        {
            Debug.Log($"{_name} agility-{agility} now");
            return agility;
        }
        set
        {
            agility = value;
            Debug.Log($"{_name} agility  has become {agility}");
        }
    }
}
