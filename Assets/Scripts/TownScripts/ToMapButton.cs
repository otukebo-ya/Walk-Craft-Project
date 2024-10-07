using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToMapButton : ButtonScript
{
    
    public override void OnClick() 
    {
        MoveMapScene();
    }
    private void MoveMapScene()
    {
        Debug.Log("ToMapScene!");
        SceneManager.LoadScene("MapScene");
    }
    public override IEnumerator FadeIn()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 currentPosition = GetComponent<RectTransform>().anchoredPosition;
        Vector2 delta = new Vector2((defaultPosition.x - currentPosition.x)/ FADE_TIME, (defaultPosition.y - currentPosition.y)/ FADE_TIME);
        for (int i = 0; i < FADE_TIME; i++) 
        {
            rectTransform.anchoredPosition += delta;
            yield return null;
        }
        yield return StartCoroutine(base.FadeIn());
    }

    public override IEnumerator FadeOut()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        var width = GetComponent<RectTransform>().rect.width;
        rectTransform.anchoredPosition = new Vector2(defaultPosition.x, defaultPosition.y);
        Vector2 delta = new Vector2(width / FADE_TIME, 0);
        
        for (int i = 0; i < FADE_TIME; i++)
        {
            rectTransform.anchoredPosition += delta;
            yield return new WaitForSeconds(0.01f);
        }
        yield return StartCoroutine(base.FadeOut());
    }
}
