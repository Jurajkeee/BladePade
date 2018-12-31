using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationCoroutines : MonoBehaviour {
//float startTime = Time.time;
    //while(Time.time<startTime + overTime)
    //{
    //    transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
    //    yield return null;
    //}
    //transform.position = target;



    public IEnumerator DelayAndClosing(Canvas canvas, float duration)
    {
        yield return new WaitForSeconds(duration);
        canvas.enabled = !canvas.enabled;
    }

    public IEnumerator DelayAndClosing(GameObject canvas, float duration)
    {
        yield return new WaitForSeconds(duration);
        canvas.SetActive(!canvas.activeSelf);
    }


    public IEnumerator FadeIn(Canvas canvas, float duration)
    {
        float startTime = Time.time;
        var canvasGroup = canvas.GetComponent<CanvasGroup>();
        while (Time.time < startTime + duration)
        {
            canvasGroup.alpha += 0.1f;
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }
    public IEnumerator FadeOut(Canvas canvas, float duration)
    {
        float startTime = Time.time;
        var canvasGroup = canvas.GetComponent<CanvasGroup>();
        while (Time.time < startTime + duration)
        {
            canvasGroup.alpha -= 0.1f;
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }
    public IEnumerator ScaleIn(Canvas canvas, float duration, float frequency)
    {
        float startTime = Time.deltaTime;

        var k = duration / frequency;
        var stepdelay = duration*frequency;

        var rectTransform = canvas.gameObject.GetComponent<RectTransform>();
        while (Time.fixedDeltaTime < startTime + duration && rectTransform.localScale.x>0)
        {
            rectTransform.localScale = Vector3.Lerp(new Vector3(0,0,0),new Vector3(rectTransform.localScale.x-frequency, rectTransform.localScale.y-frequency, rectTransform.localScale.z-frequency),frequency);
            yield return null;//<--- Bad Code, do this because i dont understand why animation lasts 2 times longer
        }
        rectTransform.localScale = new Vector3(0, 0, 0);
       
    }
    public IEnumerator ScaleOut(Canvas canvas, float duration, float frequency)
    {
        float startTime = Time.fixedDeltaTime;

        var k = duration / frequency;
        var stepdelay = duration * frequency;

        var rectTransform = canvas.gameObject.GetComponent<RectTransform>();
        while (Time.fixedDeltaTime < startTime + duration && rectTransform.localScale.x < 1)
        {
            rectTransform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(rectTransform.localScale.x + frequency, rectTransform.localScale.y + frequency, rectTransform.localScale.z + frequency), frequency);
            yield return null;//<--- Bad Code, do this because i dont understand why animation lasts 2 times longer
        }
        rectTransform.localScale = new Vector3(1, 1, 1);
    }
}
