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
    [SerializeField] private DialogueBox _dialogueBox;
    [SerializeField] private float _maxTime;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _drinkOrder;
    [SerializeField] private string _drinkCorrect;
    [SerializeField] private string _drinkWrong;
    [SerializeField] private string _drinkClose;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void RecieveOrder(GameObject dropped)
    {
        var cup = dropped.GetComponent<Cup>();
        if (cup != null)
        {
            _countdownTimer.StopTimer();
            _countdownTimer?.gameObject.SetActive(false);
            _dialogueBox?.gameObject.SetActive(true);
            _dialogueBox?.DialogueFinished.AddListener(Leave);
            var success = DrinkValidator.ValidateDrink(cup.Ingredients, DrinkConverter.GetIngredientList(_preferredDrink), _dislikes);
            switch (success)
            {
                case DrinkSuccess.Wrong:
                    _dialogueBox?.SetText(_drinkWrong);
                    PlayerManager.Instance.DecreaseRating(.2f);
                    CustomerManager.Instance.RedoCustomer();
                    break;
                case DrinkSuccess.Fine:
                    _dialogueBox?.SetText(_drinkClose);
                    PlayerManager.Instance.AddCash(5);
                    break;
                case DrinkSuccess.Perfect:
                    _dialogueBox?.SetText(_drinkCorrect);
                    PlayerManager.Instance.IncreaseRating(.2f);
                    PlayerManager.Instance.AddCash(6);
                    break;
                default:
                    break;

            }

            Destroy(dropped);
        }
    }

    public void TimeRanOut()
    {
        CustomerManager.Instance.RedoCustomer();
        Leave();
    }

    public void Leave()
    {
        _dialogueBox?.gameObject.SetActive(false);
        _countdownTimer?.gameObject.SetActive(false);
        var lerper = GetComponent<Lerper>();
        lerper.TargetReached.AddListener(Remove);
        lerper.StartLerping(transform.position - Vector3.right * 12, 5);
        StartWalking();
    }

    public void Remove()
    {
        GameManager.Instance.EndDay();
        Destroy(gameObject);
    }

    public void StartDrinkOrder()
    {
        _animator?.SetBool("IsWalking", false);
        _dialogueBox?.gameObject.SetActive(true);
        _dialogueBox?.SetText(_drinkOrder);
        _dialogueBox?.DialogueFinished.AddListener(StartDrinkMaking);
    }

    public void StartDrinkMaking()
    {
        _dialogueBox?.gameObject.SetActive(false);
        _countdownTimer?.gameObject.SetActive(true);
        _countdownTimer.TimerFinished.AddListener(TimeRanOut);
        _countdownTimer.StartTimer(_maxTime);
        GameManager.Instance.NextGameState();
    }

    public void StartWalking()
    {
        _animator?.SetBool("IsWalking", true);
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