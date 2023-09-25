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
        _countdownTimer.TimerFinished.AddListener(Leave);
        _countdownTimer.StartTimer(_maxTime);
    }

    public void RecieveOrder(GameObject dropped)
    {
        var cup = dropped.GetComponent<Cup>();
        if (cup != null)
        {
            _countdownTimer.StopTimer();
        }
    }

    public void Leave()
    {
        Destroy(gameObject);
    }
}
