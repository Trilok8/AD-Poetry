using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsModel
{
    public List<Question> AppData;
}

public class Question
{
    public string question_path { get; set; }
    public string choice1_path { get; set; }
    public string choice2_path { get; set; }
    public string choice3_path { get; set; }
    public string choice4_path {get; set;}
    public string correct_ans { get; set; }
}
