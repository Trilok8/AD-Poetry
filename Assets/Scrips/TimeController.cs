using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TimeController : MonoBehaviour
{
    public Image timerImage;
    public RoundsController roundsScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {

    }

    public void startTimer()
    {
        Debug.Log("Start Timer");
        timerImage.fillAmount = 1;
        timerImage.DOFillAmount(0, 10);
        Invoke("resetTimer", 10f);
    }

    public void cancelTimer()
    {
        CancelInvoke("resetTimer");
    }

    public void resetTimer()
    {
        timerImage.DOFillAmount(1, 0.01f);
        Invoke("setNewQuestion", 0.015f);
    }

    public void setNewQuestion()
    {
        CancelInvoke("setNewQuestion");
        CancelInvoke("resetTimer");
        roundsScript.setRound();
    }

    private void OnDisable()
    {
        timerImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
