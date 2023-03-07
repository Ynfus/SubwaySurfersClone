using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        SubwaySurfersGameManager.Instance.OnStateChanged += SubwaySurfersGameManager_OnStateChanged;
        Hide();
    }
    private async void SubwaySurfersGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (SubwaySurfersGameManager.Instance.IsGameOver())
        {
            await Task.Delay(3000);
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
            Loader.Load(Loader.Scene.GameScene);

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
