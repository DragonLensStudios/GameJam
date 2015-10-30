using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MessageHandler : MonoBehaviour
{
    public Text notificationText;
    public List<string> notificationQueue; 
    public Text dialogueText;
    private CanvasGroup canvas;
    private bool messageFade;
    public float fadeTime = 2;
    private bool queuerunning;
    public float timewait;

    private void Awake()
    {
        if (canvas == null)
        {
            canvas = GetComponent<CanvasGroup>();
        }
    }

    private void Update()
    {
//        if (timewait >= 3)
//        {
//            Debug.Log("Message worked");
//            timewait = 0;
//        }
//        else
//        {
//            timewait = Time.time;
//        }


//        if (notificationQueue.Count > 0)
//        {
//            if (DateTime.Now.Second >= 3)
//            {
//                
//            }
//
//            StartCoroutine(IE_MessageQueue());
//        }

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

    public void AddMessageToQueue(string _message)
    {
        notificationQueue.Add(_message);
    }

    private IEnumerator IE_FadeWait(float _time)
    {
        messageFade = true;
        yield return new WaitForSeconds(_time);
        messageFade = false;
    }

    private IEnumerator IE_MessageQueue()
    {
        queuerunning = true;
//        if (notificationQueue.Count > 0)
//        {
//            for (int i = 0; i < notificationQueue.Count; i++)
//            {
        foreach (var message in notificationQueue)
        {
            notificationText.text = message;
            messageFade = true;
            yield return new WaitForSeconds(fadeTime);
            messageFade = false;
//            notificationQueue.Remove(message);
            yield return new WaitForSeconds(1);
        }
        notificationQueue.Clear();
        queuerunning = false;

//            }
//        }

    }


}
