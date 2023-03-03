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
        // SprawdŸ, czy ScrollView jest na górze i wy³¹cz widocznoœæ strza³ki w górê
        if (scrollRect.verticalNormalizedPosition >= 1)
        {
            upButton.gameObject.SetActive(false);
        }
        else
        {
            upButton.gameObject.SetActive(true);
        }

        // SprawdŸ, czy ScrollView jest na dole i wy³¹cz widocznoœæ strza³ki w dó³
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
