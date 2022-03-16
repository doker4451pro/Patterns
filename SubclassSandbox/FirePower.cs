using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePower : WizardPower
{
    public override void Active()
    {
        Move(new Vector3(1, 1, 1));
        Shot(12, gameObject);
        SpawnParticles("Fire");
    }
}
