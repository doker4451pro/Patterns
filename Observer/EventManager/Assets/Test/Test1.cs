using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    private void Change() 
    {
        Debug.Log("��� ���");
    }

    private void Start()
    {
        EventManager.Instance.AddLisener(EventEnum.ChangeDamage, Change);
    }
}
