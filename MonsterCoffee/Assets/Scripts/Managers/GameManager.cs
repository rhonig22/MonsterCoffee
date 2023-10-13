using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public readonly int MaxDays = 3;

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

    public void EndDay()
    {
        _StartGameState(GameState.EndDay);
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
                GeneratorManager.Instance.EnableDay(PlayerManager.Instance.DayCount);
                UXManager.Instance.ShowDayBoard(PlayerManager.Instance.DayCount);
                break;
            case GameState.SpawnCustomer:
                CustomerManager.Instance.SpawnNextCustomer();
                break;
            case GameState.PickCup:
                GeneratorManager.Instance.EnableCupGenerators();
                break;
            case GameState.MakeDrink:
                GeneratorManager.Instance.DisableCupGenerators();
                break;
            case GameState.EndDay:
                if (CustomerManager.Instance.HasMoreCustomers())
                {
                    _StartGameState(GameState.SpawnCustomer);
                    break;
                }

                PlayerManager.Instance.IncreaseDay();
                if (PlayerManager.Instance.DayCount > MaxDays)
                    EndGame();
                else
                    NextGameState();
                break;
            default:
                break;
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("CreditsScreen");
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