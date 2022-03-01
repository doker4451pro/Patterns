using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Subject subject;

    private void Start()
    {
        subject.AddLisener(Do);
    }
    private void Do() 
    {
        Debug.Log("I saw that hp has changed");
    }
    //do not forget to unsubscribe from events
    private void OnDestroy()
    {
        subject.DeleteLisener(Do);
    }
}
