using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private event Action OnHPChanged;

    public void AddLisener(Action action) 
    {
        OnHPChanged += action;
    }
    public void DeleteLisener(Action action) 
    {
        OnHPChanged -= action;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            OnHPChanged?.Invoke();
        }
    }
}
