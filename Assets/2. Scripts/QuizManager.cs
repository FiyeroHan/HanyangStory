using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class QuizManager : MonoBehaviour
{
    public List<QuizAndAnswer> qna;
    public GameObject[] options;
    public int currentQuestion = 0;

    public TMP_Text Questiontext;

    public int answerCount;

    public GameObject quizUI;

    public QuestManager questManager;


    // public static QuizManager instance;

    // private void Awake()
    // {
    //     instance = this;
    // }

    void Start() {
        qna = new List<QuizAndAnswer>();
        answerCount = 0;
        
    }


    public void GenerateQuiz(int level)
    {
        if(level == 3020){
        qna.Add(new QuizAndAnswer("2024년도 기준으로 과학기술융합대학 소속의 응용물리학과는 2025년도에 어떤 학과로 명칭이 변경될까요?", 
        new string[]{ "국방지능정보융합학부", "융합시스템공학과", "LION자율전공학부", "로봇공학과"},
        1));
        qna.Add(new QuizAndAnswer("과학기술융합대학 소속의 의약생명과학과는 2025년도 기준 어느 단과대학 소속으로 바뀔까요?",
        new string[]{ "공학대학", "커뮤니케이션 대학", "첨단융합대학", "LIONS칼리지"},
        3));
        qna.Add(new QuizAndAnswer("2024년도 기준 6개의 학과들 중 학제개편에 따라 가장 많은 학과가 소속되게 되는 단과대학은 어디일까요?",
        new string[]{ "소프트웨어융합대학", "첨단융합대학", "글로벌문화통상대학", "공학대학"},
        2));    
        }

        else if (level == 4030)
        {
        qna.Add(new QuizAndAnswer("다음 중 학제개편 이전과 이후에도 공학대학 소속의 학과 명칭이 그대로 유지되는 학과는 어디일까?", 
        new string[]{ "융합시스템공학과", "기계공학과", "해양융합공학과", "배터리소재화학공학과"},
        2));
        qna.Add(new QuizAndAnswer("공학대학 소속의 생명나노공학과는 2025년도에 다른 단과대학 소속으로 변경되면서 큰 변환점을 맞게 돼. 다음 중 관련이 없는 것은 무엇일까?", 
        new string[]{ "바이오나노공학과", "바이오신약융합학부", "분자의약전공", "첨단융합대학"},
        1));
        qna.Add(new QuizAndAnswer("과학기술융합대학 소속의 화학분자공학과는 2025년도에 공학대학 소속의 학과로 소속을 이전하게 돼. 그러면서 학과 명칭도 바뀌게 되는데, 다음 중 옳은 것은 무엇일까?", 
        new string[]{ "배터리소재화학공학과", "융합시스템공학과", "산업경영공학과", "에너지바이오학과"},
        4));
        }

        else if (level == 5040)
        {
        qna.Add(new QuizAndAnswer("약학대학 소속 교수님들이 일부 학과에 가서 J/A 형식으로 수업을 진행하게 돼요. 어느 학과일까요?", 
        new string[]{ "에너지바이오학과", "스마트융합공학부", "바이오신약융합학부", "LION자율전공학부"},
        2));
        qna.Add(new QuizAndAnswer("약대생들은 전국의 모든 약학대 학생들이 1박 2일로 MT를 가려고 모이는 자체 행사가 있죠? 그 이름이 뭘까요?", 
        new string[]{ "전국약대교류행사", "전국약대정모", "남부지부", "전약제"},
        4));
        qna.Add(new QuizAndAnswer("약학대학은 다른 단과대학들과 달리, 유일하게 건물 내에 이것이 존재해요. 이것은 뭘까요?", 
        new string[]{ "학생회실", "편의점", "동아리방", "무인 매점"},
        4));
        }
        else if (level == 6050)
        {
        qna.Add(new QuizAndAnswer("2025년도에 과학기술융합대학에서 소프트웨어융합대학으로 단과대학 소속을 옮기게 된 학과가 하나 있어요? 무엇일까요?", 
        new string[]{ "융합시스템공학과", "인공지능학과", "수리데이터사이언스학과", "에너지바이오학과"},
        3));
        qna.Add(new QuizAndAnswer("ICT융합학부는 2학년으로 진급함에 따라 전공을 배정받아요. 기존 3개의 전공에서 2개의 전공으로 통합 및 축소됩니다. 디자인컨버전스 전공과 다른 하나는 뭘까?", 
        new string[]{ "데이터인텔리전스 전공", "컬쳐테크놀로지 전공", "스마트헬스케어 전공", "미디어테크놀로지 전공"},
        1));
        qna.Add(new QuizAndAnswer("소프트웨어융합대학 학생들은 자체 건물이 없어서 여기저기 돌아다니며 수업을 듣게돼. 5층과 6층을 8년째 빌리고 있으며, 가장 수업이 많이 열리는 이 건물의 이름은 무엇일까?", 
        new string[]{ "퓨전기술응용연구센터", "창업보육센터", "학연산클러스터지원센터", "제4공학관"},
        3));
        }
    }

    
    public void makeQuestion()
    { 
        if(qna.Count >0)
        {
            Questiontext.text = qna[currentQuestion].Question;
            setAnswer();
        }
            
        else
        {
            
            if(EndQuiz())
            {
                Questiontext.text = "문제 3개 중" +answerCount +"개를 맞췄습니다. 3초후 퀴즈창이 종료됩니다.";
                questManager.questActionIndex++;
            }
            else
            {
                Questiontext.text = "문제 3개 중" +answerCount +"개를 맞췄습니다. 다시 도전해보세요. 3초후 퀴즈창이 종료됩니다.";
                
            }
            Invoke("QuizUIDisable", 3f);
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

    public bool EndQuiz()
    {
        if(answerCount == 3) return true;
        else return false;
    }
    void QuizUIDisable()
    {
        quizUI.SetActive(false);
    }
}