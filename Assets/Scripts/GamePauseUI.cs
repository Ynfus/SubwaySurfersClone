using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;
    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            SubwaySurfersGameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        optionsButton.onClick.AddListener(() =>
        {
            Hide();
            OptionsUI.Instance.Show(Show);
        });
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

    }
    private void Hide()
    {
        gameObject.SetActive(false);

    }
}
