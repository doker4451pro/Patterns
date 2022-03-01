using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public void OnClick() 
    {
        EventManager.Instance.TriggerEvent(EventEnum.ChangeDamage);
    }
}
