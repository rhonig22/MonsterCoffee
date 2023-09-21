using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private int _cash = 50;
    public int CashOnHand {
            get
            {
                return _cash;
            }
            private set
            {
                _cash = value < 0 ? 0 : value;
                UXManager.Instance.UpdateCash(_cash);
            }
    }
    public int DayCount { get; private set; } = 1;
    public float Rating { get; private set; } = 1;

    public void UpdateAllUX()
    {
        UXManager.Instance.UpdateCash(CashOnHand);
        UXManager.Instance.UpdateDayCount(DayCount);
        UXManager.Instance.UpdateRating(Rating);
    }

    public void IncreaseDay()
    {
        DayCount++;
        UpdateAllUX();
    }

    private void Awake()
    {
        Instance = this;
    }
}
