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
    public GameObject CurrentlyDragging { get; private set; } = null;

    public void StartDragging(GameObject target)
    {
        if (CurrentlyDragging == null || target == null)
        {
            CurrentlyDragging = target;
            if (CurrentlyDragging != null)
            {
                CurrentlyDragging.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Dragging");
            }
        }
    }

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

    public void AddCash(int amount)
    {
        CashOnHand += amount;
    }
    public void SpendCash(int amount)
    {
        CashOnHand -= amount;
    }

    public void IncreaseRating(float amount)
    {
        Rating += amount;
        if (Rating > 5) Rating = 5;
        UXManager.Instance.UpdateRating(Rating);
    }

    public void DecreaseRating(float amount)
    {
        Rating -= amount;
        if (Rating < 0) Rating = 0;
        UXManager.Instance.UpdateRating(Rating);
    }

    private void Awake()
    {
        Instance = this;
    }
}
