using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCode : MonoBehaviour
{
    [SerializeField] private byte[] spellCodes;
    [SerializeField] private VirtualMashine virtualMashine;

    public void CastSpell() 
    {
        virtualMashine.DoVm(spellCodes);
    }

    private void Start()
    {
        CastSpell();
    }
}
