using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region Singleton
    public static EventManager Instance;
    private void Awake()
    {
        Instance = this;
        dicEvent = new Dictionary<EventEnum, Action>();
    }
    #endregion

    private Dictionary<EventEnum, Action> dicEvent;
    public void AddLisener(EventEnum eventEnum, Action lisenerAction) 
    {
        Action thisAction;
        if (dicEvent.TryGetValue(eventEnum, out thisAction))
        {
            thisAction += lisenerAction;
        }
        else 
        {
            thisAction += lisenerAction;
            dicEvent.Add(eventEnum, thisAction);
        }
    }

    public void TriggerEvent(EventEnum eventEnum) 
    {
        dicEvent[eventEnum]?.Invoke();
    }
}
