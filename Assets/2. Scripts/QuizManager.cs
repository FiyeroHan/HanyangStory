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

    void Start() {
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
            Debug.Log("문제를 다 풀었습니다");
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
                options[i].GetComponent<Answer>().isCorrect = true;
            }    
        }
    }

    public void correct()
    {
        qna.RemoveAt(currentQuestion);

        makeQuestion();
    }
}