using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;


    public void Answers()
    {
        if(isCorrect)
        {
            Debug.Log("정답입니다.");
            quizManager.answerCount++;
            quizManager.NextQuestion();

        }
        else
        {
            Debug.Log("틀렸습니다.");
            quizManager.NextQuestion();
        }

    }
}
