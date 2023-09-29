using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    [SerializeField] private CreatureTypes _creatureType;
    [SerializeField] private HeadModifier _headModifier;
    [SerializeField] private FaceModifier _faceModifier;
    [SerializeField] private DrinkNames _preferredDrink;
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
            var success = DrinkValidator.ValidateDrink(cup.Ingredients, DrinkConverter.GetIngredientList(_preferredDrink), _dislikes);
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
        GameManager.Instance.NextGameState();
    }
}

public enum CreatureTypes
{
    Ghost = 0,
    Skeleton = 1,
    Reaper = 2,
    SeaCreature = 3,
    Cthulhu = 4
}

public enum HeadModifier
{
    Plain = 0,
    Helmet = 1,
    PirateHat = 2,
}

public enum FaceModifier
{
    Plain = 0,
    EyePatch = 1,
    Bandage = 2
}