using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollButtons : MonoBehaviour
{
    public ScrollRect scrollRect;
    [SerializeField] Button upButton;
    [SerializeField] Button downButton;

    private void Start()
    {
        upButton.onClick.AddListener(ScrollUp);
        downButton.onClick.AddListener(ScrollDown);
    }

    private void ScrollUp()
    {
        scrollRect.verticalNormalizedPosition += 0.2f;
    }

    private void ScrollDown()
    {
        scrollRect.verticalNormalizedPosition -= 0.2f;
    }

    private void Update()
    {
        // Sprawd�, czy ScrollView jest na g�rze i wy��cz widoczno�� strza�ki w g�r�
        if (scrollRect.verticalNormalizedPosition >= 1)
        {
            upButton.gameObject.SetActive(false);
        }
        else
        {
            upButton.gameObject.SetActive(true);
        }

        // Sprawd�, czy ScrollView jest na dole i wy��cz widoczno�� strza�ki w d�
        if (scrollRect.verticalNormalizedPosition <= 0)
        {
            downButton.gameObject.SetActive(false);
        }
        else
        {
            downButton.gameObject.SetActive(true);
        }
    }
}
