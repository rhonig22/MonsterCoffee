using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    [SerializeField] private List<IngredientType> _preferredIngredients;
    [SerializeField] private List<IngredientType> _dislikes;
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
            var success = DrinkValidator.ValidateDrink(cup.Ingredients, _preferredIngredients, _dislikes);
            switch (success)
            {
                case DrinkSuccess.Wrong:
                    PlayerManager.Instance.DecreaseRating(.2f);
                    break;
                case DrinkSuccess.Fine:
                    PlayerManager.Instance.AddCash(5);
                    break;
                case DrinkSuccess.Perfect:
                    PlayerManager.Instance.IncreaseRating(.2f);
                    PlayerManager.Instance.AddCash(6);
                    break;
                default:
                    break;

            }

            Leave();
        }
    }

    public void Leave()
    {
        Destroy(gameObject);
    }
}
