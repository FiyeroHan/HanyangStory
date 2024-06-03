using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuizAndAnswer> qna;
    public GameObject[] options;
    public int currentQuestion = 0;

    public TMP_Text Questiontext;

    public int answerCount;

    public static QuizManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start() {
        answerCount = 0;
        makeQuestion();
    }

    
    void makeQuestion()
    { 
        if(qna.Count >0)
        {
            Questiontext.text = qna[currentQuestion].Question;
            setAnswer();
        }
        
        else
        {
            Questiontext.text = "문제" +answerCount +" 개를 맞췄습니다.";
        }

    }

    void setAnswer()
    {
        for(int i=0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = qna[currentQuestion].Answer[i];

            if(qna[currentQuestion].CorrectAnswer == i + 1)
            {
                Debug.Log(i+1 + "번으로 정답세팅");
                options[i].GetComponent<Answer>().isCorrect = true;
            }    
        }
    }

    public void NextQuestion()
    {
        qna.RemoveAt(currentQuestion);

        makeQuestion();
    }
}