using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button jumpButton;

    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI confirmText;
    [SerializeField] private TextMeshProUGUI jumpText;
    [SerializeField] private TextMeshProUGUI pauseText;

    [SerializeField] private Transform pressToRebindKeyTransform;

    private Action onCloseButtonAction;


    private void Awake()
    {
        Instance = this;
        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();

        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();

        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            onCloseButtonAction();
        });
        moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Left); });
        moveRightButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Right); });
        confirmButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Confirm); });
        jumpButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Jump); });
        pauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Pause); });
    }
    private void Start()
    {
        SubwaySurfersGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        UpdateVisual();
        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects:  " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music:  " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        confirmText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Confirm);
        jumpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Jump);
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
    }
    public void Show(Action onCloseButtonAction)
    {
        this.onCloseButtonAction = onCloseButtonAction;
        gameObject.SetActive(true);
        soundEffectsButton.Select();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);

    }
    private void HidePressToRebindKey()
    {

        pressToRebindKeyTransform.gameObject.SetActive(false);
    }
    private void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.Instance.RebindBinding(binding, () =>
        {
            HidePressToRebindKey();
            UpdateVisual();


        });
    }
}
