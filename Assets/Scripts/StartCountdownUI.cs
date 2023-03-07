using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI confirmText;
    [SerializeField] private TextMeshProUGUI jumpText;
    void Start()
    {
        SubwaySurfersGameManager.Instance.OnStateChanged += SubwaySurfersGameManager_OnStateChanged;
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        confirmText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Confirm);
        jumpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Jump);
    }

    private void SubwaySurfersGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (SubwaySurfersGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
            
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
