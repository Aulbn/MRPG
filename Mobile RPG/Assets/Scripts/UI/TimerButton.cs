using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class TimerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image timerImage;
    [SerializeField] [Min(0)] private float cooldown;
    public UnityEvent onButtonClick;
    public UnityEvent onTimerEnd;

    [Header("")]
    public float fadeTime = 0.2f;
    private float fadeTimeStamp;

    private bool isAvailable = true;
    private bool isDown = false;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (Time.time < fadeTimeStamp)
            canvasGroup.alpha = Mathf.Lerp(0, 1, fadeTime - (fadeTimeStamp - Time.time));
        else
            canvasGroup.alpha = 1f;
    }

    public void SetCooldown(float time)
    {
        cooldown = Mathf.Clamp(time, 0, Mathf.Infinity);
    }

    public void StartTimer()
    {
        if (cooldown == 0) return;

        StopAllCoroutines();
        StartCoroutine(Timer(cooldown));
    }

    private IEnumerator Timer(float time)
    {
        isAvailable = false;
        timerImage.fillAmount = 0;
        float timeLeft = time;

        do
        {
            yield return new WaitForEndOfFrame();
            timeLeft -= Time.deltaTime;
            timerImage.fillAmount = 1 - (timeLeft / time);

        } while (timeLeft > 0);

        isAvailable = true;
        onTimerEnd.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    private void StartColorFade()
    {
        fadeTimeStamp = Time.time + fadeTime;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDown)
        {
            if (isAvailable)
            {
                onButtonClick.Invoke();
                StartTimer();
                StartColorFade();
            }
            isDown = false;
        }
    }
}
