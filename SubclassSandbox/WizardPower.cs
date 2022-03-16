using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WizardPower: MonoBehaviour
{
    public abstract void Active();

    protected void Move(Vector3 vector) 
    {
        transform.position = vector;
    }
    protected void Shot(int damage, GameObject game) 
    {
        Debug.Log($"Damaget {game} for {damage}");
    }
    protected void SpawnParticles(string nameParticles) 
    {
        Debug.Log($"SwawnParticles: {nameParticles}");
    }
}
