using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UXManager : MonoBehaviour
{
    public static UXManager Instance;

    [SerializeField] private TextMeshProUGUI _dayCount, _cashOnHand, _rating;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateDayCount(int day)
    {
        _dayCount.text = "Day: " + day;
    }

    public void UpdateCash(int cash)
    {
        _cashOnHand.text = "Cash: " + cash;
    }

    public void UpdateRating(float rating)
    {
        _rating.text = "Rating: " + rating.ToString("0.00") + " / 5";
    }
}
