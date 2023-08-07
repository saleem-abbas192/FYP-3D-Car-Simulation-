using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if(isCorrect == true)
        {
            Debug.Log("Correct");
            quizManager.AnsweredQuestionCorrectly();
        }
        else
        {
            Debug.Log("Wrong");
            quizManager.WronAnswered();
        }
    }


}
