using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseUI : MonoBehaviour
{

    //[SerializeField] private Button resumeButton;
    //[SerializeField] private Button mainMenuButton;
    //[SerializeField] private Button optionsButton;
    private void Awake()
    {
        //resumeButton.onClick.AddListener(() =>
        //{
        //    KitchenGameManager.Instance.TogglePauseGame();
        //});
        //mainMenuButton.onClick.AddListener(() =>
        //{
        //    Loader.Load(Loader.Scene.MainMenuScene);
        //});
        //optionsButton.onClick.AddListener(() =>
        //{
        //    Hide();
        //    OptionsUI.Instance.Show(Show);
        //});
    }
    private void Start()
    {
        SubwaySurfersGameManager.Instance.OnGamePaused += SubwaySurfersGameManager_OnGamePaused;
        SubwaySurfersGameManager.Instance.OnGameUnpaused += SubwaySurfersGameManager_OnGameUnpaused;
        Hide();
    }

    private void SubwaySurfersGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void SubwaySurfersGameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        //resumeButton.Select();

    }
    private void Hide()
    {
        gameObject.SetActive(false);

    }
}
