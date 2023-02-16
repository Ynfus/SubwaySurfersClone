using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private GameObject shop;
    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);

        });
        shopButton.onClick.AddListener(() =>
        {
            shop.gameObject.SetActive(true);

        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();

        });
        Time.timeScale = 1.0f;
    }
}
