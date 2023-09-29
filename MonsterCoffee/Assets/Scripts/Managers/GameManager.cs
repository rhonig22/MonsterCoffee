using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameState _currentState = GameState.StartDay;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _StartGameState(_currentState);
    }

    public void NextGameState()
    {
        var nextState = (GameState)(((int)_currentState + 1) % Enum.GetValues(typeof(GameState)).Length);
        _StartGameState(nextState);
    }

    private void _StartGameState(GameState state)
    {
        _currentState = state;
        switch (state)
        {
            case GameState.StartDay:
                if (PlayerManager.Instance.DayCount == 1)
                    PlayerManager.Instance.UpdateAllUX();
                CustomerManager.Instance.SetUpCustomersForTheDay(PlayerManager.Instance.DayCount);
                NextGameState();
                break;
            case GameState.SpawnCustomer:
                CustomerManager.Instance.SpawnNextCustomer();
                NextGameState();
                break;
            case GameState.PickCup:
                NextGameState();
                break;
            case GameState.MakeDrink:
                break;
            case GameState.EndDay:
                if (CustomerManager.Instance.HasMoreCustomers())
                {
                    _StartGameState(GameState.SpawnCustomer);
                    break;
                }

                PlayerManager.Instance.IncreaseDay();
                NextGameState();
                break;
            default:
                break;
        }
    }
}

public enum GameEvents
{
    NewCustomer = 0
}

public enum GameState
{
    StartDay = 0,
    SpawnCustomer = 1,
    PickCup = 2,
    MakeDrink = 3,
    EndDay = 4
}