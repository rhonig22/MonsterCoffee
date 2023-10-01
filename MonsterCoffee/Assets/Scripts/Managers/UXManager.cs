using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UXManager : MonoBehaviour
{
    public static UXManager Instance;

    [SerializeField] private TextMeshProUGUI _dayCount, _cashOnHand, _rating, _itemName, _dayNumber;
    [SerializeField] private GameObject _itemInfo, _dayBoard;
    private float _dayboardWaitTime = 2f;

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

    public void ToggleItemInfo(bool turnOn, string name)
    {
        _itemInfo.SetActive(turnOn);
        _itemName.text = name;
    }

    public void ShowDayBoard(int day)
    {
        _dayNumber.text = "Day " + day;
        _dayBoard.SetActive(true);
        StartCoroutine(HideDayBoard());
    }

    private IEnumerator HideDayBoard()
    {
        yield return new WaitForSeconds(_dayboardWaitTime);
        _dayBoard.SetActive(false);
        GameManager.Instance.NextGameState();
    }
}
