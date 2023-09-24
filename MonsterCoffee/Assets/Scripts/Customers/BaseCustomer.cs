using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    [SerializeField] private CountdownTimer _countdownTimer;
    [SerializeField] private float _maxTime;

    // Start is called before the first frame update
    void Start()
    {
        _countdownTimer.StartTimer(_maxTime);
    }

    public void RecieveOrder(GameObject dropped)
    {
        Debug.Log(dropped.ToString());
    }

}
