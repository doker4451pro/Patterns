using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPower : WizardPower
{
    public override void Active()
    {
        Shot(-12, gameObject);
        SpawnParticles("water");
    }
}
