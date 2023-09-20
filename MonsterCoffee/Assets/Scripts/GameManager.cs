using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState { get; private set; } = GameState.StartDay;

    private void Awake()
    {
        Instance = this;
    }

    public void NextGameState()
    {
        CurrentState = (GameState)((int)CurrentState + 1 % Enum.GetValues(typeof(GameState)).Length);
        _StartGameState(CurrentState);
    }

    private void _StartGameState(GameState state)
    {
        switch (state)
        {
            case GameState.StartDay:
                NextGameState();
                break;
            case GameState.Customers:
                break;
            case GameState.CloseShop:
                break;
            case GameState.EndDay:
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
    Customers = 1,
    CloseShop = 2,
    EndDay = 3
}