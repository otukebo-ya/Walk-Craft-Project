using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : ButtonScript
{
    public static float BOTTOM_SPACE = 40f;
    public override void OnClick()
    {
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.ViewState);
    }

    public override IEnumerator FadeOut()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 currentPosition = GetComponent<RectTransform>().anchoredPosition;
        Vector2 delta = new Vector2((defaultPosition.x - currentPosition.x) / FADE_TIME, (defaultPosition.y - currentPosition.y) / FADE_TIME);
        for (int i = 0; i < FADE_TIME; i++)
        {
            Debug.Log("Return");
            rectTransform.anchoredPosition += delta;
            yield return null;
        }
    }

    public override IEnumerator FadeIn()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        var height = GetComponent<RectTransform>().rect.height + BOTTOM_SPACE;
        rectTransform.anchoredPosition = new Vector2(defaultPosition.x, defaultPosition.y);
        Vector2 delta = new Vector2(0,height / FADE_TIME);
        for (int i = 0; i < FADE_TIME; i++)
        {
            rectTransform.anchoredPosition += delta;
            Debug.Log("Return");
            yield return new WaitForSeconds(0.01f);
        }
    }
}
