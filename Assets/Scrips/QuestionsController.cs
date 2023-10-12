using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class QuestionsController : MonoBehaviour
{
    public int index = -1;
    public QuestionsModel questionsData;
    private string fileName = "missingwords.json";

    public Image question;
    public Image choice1;
    public Image choice2;
    public Image choice3;
    public Image choice4;
    public static QuestionsController INSTANCE;

    public List<optionsController> options = new List<optionsController>();
    public ScoreController scoreScript;
    private bool isAnswered = false;
    public RoundsController roundsScript;
    public TimeController timerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        INSTANCE = this;
        string completeFilePath = Application.streamingAssetsPath + "/" + fileName;
        if (File.Exists(completeFilePath)){
            string fileData = File.ReadAllText(completeFilePath);
            questionsData = JsonConvert.DeserializeObject<QuestionsModel>(fileData);
        }
        //setQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseIndex()
    {
        if(index < questionsData.AppData.Count)
        {
            index++;
        } else
        {
            index = 0;
        }
    }

    public void setQuestion()
    {
        increaseIndex();
        
        Question currentQuestion = questionsData.AppData[index];
        question.sprite = getSprite(currentQuestion.question_path);
        choice1.sprite = getSprite(currentQuestion.choice1_path);
        choice2.sprite = getSprite(currentQuestion.choice2_path);
        choice3.sprite = getSprite(currentQuestion.choice3_path);
        choice4.sprite = getSprite(currentQuestion.choice4_path);
        
        isAnswered = false;
        timerScript.startTimer();
        resetGame();
    }

    public void checkAnswer(GameObject objc)
    {
        isAnswered = true;
        Question currentQuestion = questionsData.AppData[index];
        int correctNumber;
        int.TryParse(currentQuestion.correct_ans, out correctNumber);
        for(int i = 0; i < options.Count; i++)
        {
            if(objc.name == options[i].gameObject.name)
            {
                if (objc.name.Contains(currentQuestion.correct_ans))
                {
                    options[i].setCorrect();
                    scoreScript.increasecore();
                } else
                {
                    options[i].setWrong();
                    options[correctNumber - 1].GetComponent<optionsController>().setCorrect();
                }
            } else
            {
                objc.GetComponent<optionsController>().setWrong();
            }
            options[i].GetComponent<Button>().interactable = false;
        }
        timerScript.cancelTimer();
    }

    public void resetGame()
    {
        for (int i = 0; i < options.Count; i++)
        {
            options[i].resetOptions();
            options[i].GetComponent<Button>().interactable = true;
        }
    }

    public Sprite getSprite(string path)
    {
        string basePath = Application.streamingAssetsPath;
        byte[] bytes = File.ReadAllBytes(basePath + path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),new Vector2(0,0),100,0,SpriteMeshType.Tight);
    }
}
