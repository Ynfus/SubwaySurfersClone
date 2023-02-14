using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button retryButton;
    private void Start()
    {
        SubwaySurfersGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        Hide();
    }
    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (SubwaySurfersGameManager.Instance.IsGameOver())
        {
            Show();
            coinsText.text = CoinsCounter.Instance.GetCoinsAmount().ToString();
            scoreText.text= DistanceCounter.Instance.GetDistanceAmount();
        }
        else
        {
            Hide();
        }
    }
    private void Awake()
    {
        retryButton.onClick.AddListener(() =>
        {
            Hide();
            SubwaySurfersGameManager.Instance.Reset();
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
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
