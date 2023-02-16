using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SubwaySurfersGameManager : MonoBehaviour
{

    public static SubwaySurfersGameManager Instance { get; private set; }
    [SerializeField] private Player player;
    public event EventHandler OnStateChanged;
    public event EventHandler OnGameUnpaused;
    public event EventHandler OnGamePaused;
    //public static void ResetStaticData()
    //{
    //    OnAnyObjectPlaceHere = null;
    //}
    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }
    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }
    private State state;
    private float countdownTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 100f;
    private bool isGamePaused = false;
    private bool isSaved = false;

    private void Start()
    {
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
        GameInput.Instance.OnPauseAction += SubwaySurfersGameManager_OnPauseAction;
        //if (state == State.WaitingToStart)
        //{
            
        //    state = State.CountdownToStart;
        //    OnStateChanged?.Invoke(this, new EventArgs());
        //}
        //GameInput.Instance.OnPauseAction += SubwaySurfersGameManager_OnPauseAction;
    }




    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if (state == State.WaitingToStart)
        {
            state = State.CountdownToStart;
            OnStateChanged?.Invoke(this, new EventArgs());
            SoundManager.Instance.PlayCountdownSound();
        }
    }

    private void SubwaySurfersGameManager_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }
    public void Reset()
    {
        state = State.WaitingToStart;
        player.ResetPosition();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
        DistanceCounter.Instance.ResetDistance();
        CoinsCounter.Instance.ResetCoins();

    }
    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }


    private void Update()
    {
        Debug.Log(state);
        switch (state)
        {
            case State.WaitingToStart:

                break;
            case State.CountdownToStart:
                countdownTimer -= Time.deltaTime;

                if (countdownTimer < 0f)
                {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);

                }
                break;
            case State.GamePlaying:
                if (player.IsCollision())
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                if (!isSaved)
                { SaveCoins(); }
                break;

        }
    }
    private void SaveCoins()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        currentCoins += CoinsCounter.Instance.GetCoinsAmount();
        PlayerPrefs.SetInt("Coins", currentCoins);
        Debug.Log(currentCoins);
        isSaved= true;
    }
    public bool IsGamePlaying()
    {

        return state == State.GamePlaying;
    }
    public bool IsCountdownToStartActive()
    {
        Debug.Log(state);
        return state == State.CountdownToStart;
    }
    public float GetCountdownToStartTimer()
    {
        return countdownTimer;
    }
    public bool IsGameOver()
    {
        return state == State.GameOver;

    }
    public float GetGameTimerNormalized()
    {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax);
    }
}


