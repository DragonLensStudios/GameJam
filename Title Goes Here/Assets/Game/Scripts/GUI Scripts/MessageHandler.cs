using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageHandler : MonoBehaviour
{
    public Text notificationText;
    public Text dialogueText;
    private CanvasGroup canvas;
    private bool messageFade;
    public float fadeTime = 2;

    private void Awake()
    {
        if (canvas == null)
        {
            canvas = GetComponent<CanvasGroup>();
        }
    }

    private void Update()
    {
        if (messageFade == false && canvas.alpha >= 0)
        {
            FadeOut(fadeTime);
        }

        if (messageFade && canvas.alpha <= 1)
        {
            FadeIn(fadeTime);
        }
    }

    public void ShowMessage(string _Message, float _fadetime = 2)
    {
        notificationText.text = _Message;
        FadeFull(_fadetime);
    }

    public void ShowMessage(string _Message)
    {
        notificationText.text = _Message;
        FadeFull(fadeTime);
    }

    public void FadeFull(float _fadetime)
    {
        if (messageFade)
        {
            messageFade = false;
            StopAllCoroutines();
        }
        if (fadeTime != _fadetime)
        {
            fadeTime = _fadetime;
        }
        StartCoroutine(IE_FadeWait(fadeTime));

    }

    public void FadeIn(float _time)
    {
        canvas.alpha = canvas.alpha += Time.deltaTime * _time;
    }

    public void FadeOut(float _time)
    {
        canvas.alpha = canvas.alpha - Time.deltaTime * _time;
    }

    private IEnumerator IE_FadeWait(float _time)
    {
        messageFade = true;
        yield return new WaitForSeconds(_time);
        messageFade = false;
    }


}
