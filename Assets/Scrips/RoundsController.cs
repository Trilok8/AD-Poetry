using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundsController : MonoBehaviour
{
    public int round = 0;
    public static RoundsController INSTANCE;
    public Text roundsText;
    public GameObject page5;
    public GameObject page4;
    public TimeController timeController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        INSTANCE = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRound()
    {
        if(round < 8)
        {
            round++;
            roundsText.text = "0" + round.ToString();
            QuestionsController.INSTANCE.setQuestion();
        } else
        {
            page4.SetActive(false);
            page5.SetActive(true);
        }
    }

    public void resetRounds()
    {
        round = 0;
    }
}
