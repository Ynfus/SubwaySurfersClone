using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    private Animator animator;

    private const string NUMBER_POPUP = "NumberPopUp";
    private int previousCountdownNumber;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        SubwaySurfersGameManager.Instance.OnStateChanged += SubwaySurfersGameManager_OnStateChanged;
        Hide();
    }


    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(SubwaySurfersGameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();
        if (previousCountdownNumber != countdownNumber)
        {
            previousCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            //SoundManager.Instance.PlayCountdownSound();
        }
    }

    private void SubwaySurfersGameManager_OnStateChanged(object sender, System.EventArgs e)
    {

        gameObject.SetActive(SubwaySurfersGameManager.Instance.IsCountdownToStartActive());        
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
