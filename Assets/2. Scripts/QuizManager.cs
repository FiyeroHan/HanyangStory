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
        qna.Add(new QuizAndAnswer("2024�⵵ �������� ���б�����մ��� �Ҽ��� ���빰���а��� 2025�⵵�� � �а��� ��Ī�� ����ɱ��?", 
        new string[]{ "�����������������к�", "���սý��۰��а�", "LION���������к�", "�κ����а�"},
        1));
        qna.Add(new QuizAndAnswer("���б�����մ��� �Ҽ��� �Ǿ������а��� 2025�⵵ ���� ��� �ܰ����� �Ҽ����� �ٲ���?",
        new string[]{ "���д���", "Ŀ�´����̼� ����", "÷�����մ���", "LIONSĮ����"},
        3));
        qna.Add(new QuizAndAnswer("2024�⵵ ���� 6���� �а��� �� �������� ���� ���� ���� �а��� �Ҽӵǰ� �Ǵ� �ܰ������� ����ϱ��?",
        new string[]{ "����Ʈ�������մ���", "÷�����մ���", "�۷ι���ȭ������", "���д���"},
        2));    
        }

        else if (level == 4030)
        {
        qna.Add(new QuizAndAnswer("���� �� �������� ������ ���Ŀ��� ���д��� �Ҽ��� �а� ��Ī�� �״�� �����Ǵ� �а��� ����ϱ�?", 
        new string[]{ "���սý��۰��а�", "�����а�", "�ؾ����հ��а�", "���͸�����ȭ�а��а�"},
        2));
        qna.Add(new QuizAndAnswer("���д��� �Ҽ��� ��������а��� 2025�⵵�� �ٸ� �ܰ����� �Ҽ����� ����Ǹ鼭 ū ��ȯ���� �°� ��. ���� �� ������ ���� ���� �����ϱ�?", 
        new string[]{ "���̿�������а�", "���̿��ž������к�", "�����Ǿ�����", "÷�����մ���"},
        1));
        qna.Add(new QuizAndAnswer("���б�����մ��� �Ҽ��� ȭ�к��ڰ��а��� 2025�⵵�� ���д��� �Ҽ��� �а��� �Ҽ��� �����ϰ� ��. �׷��鼭 �а� ��Ī�� �ٲ�� �Ǵµ�, ���� �� ���� ���� �����ϱ�?", 
        new string[]{ "���͸�����ȭ�а��а�", "���սý��۰��а�", "����濵���а�", "���������̿��а�"},
        4));
        }

        else if (level == 5040)
        {
        qna.Add(new QuizAndAnswer("���д��� �Ҽ� �����Ե��� �Ϻ� �а��� ���� J/A �������� ������ �����ϰ� �ſ�. ��� �а��ϱ��?", 
        new string[]{ "���������̿��а�", "����Ʈ���հ��к�", "���̿��ž������к�", "LION���������к�"},
        2));
        qna.Add(new QuizAndAnswer("�������� ������ ��� ���д� �л����� 1�� 2�Ϸ� MT�� ������ ���̴� ��ü ��簡 ����? �� �̸��� �����?", 
        new string[]{ "������뱳�����", "�����������", "��������", "������"},
        4));
        qna.Add(new QuizAndAnswer("���д����� �ٸ� �ܰ����е�� �޸�, �����ϰ� �ǹ� ���� �̰��� �����ؿ�. �̰��� �����?", 
        new string[]{ "�л�ȸ��", "������", "���Ƹ���", "���� ����"},
        4));
        }
        else if (level == 6050)
        {
        qna.Add(new QuizAndAnswer("2025�⵵�� ���б�����մ��п��� ����Ʈ�������մ������� �ܰ����� �Ҽ��� �ű�� �� �а��� �ϳ� �־��? �����ϱ��?", 
        new string[]{ "���սý��۰��а�", "�ΰ������а�", "���������ͻ��̾��а�", "���������̿��а�"},
        3));
        qna.Add(new QuizAndAnswer("ICT�����кδ� 2�г����� �����Կ� ���� ������ �����޾ƿ�. ���� 3���� �������� 2���� �������� ���� �� ��ҵ˴ϴ�. �������������� ������ �ٸ� �ϳ��� ����?", 
        new string[]{ "���������ڸ����� ����", "������ũ����� ����", "����Ʈ�ｺ�ɾ� ����", "�̵����ũ����� ����"},
        1));
        qna.Add(new QuizAndAnswer("����Ʈ�������մ��� �л����� ��ü �ǹ��� ��� �������� ���ƴٴϸ� ������ ��Ե�. 5���� 6���� 8��° ������ ������, ���� ������ ���� ������ �� �ǹ��� �̸��� �����ϱ�?", 
        new string[]{ "ǻ��������뿬������", "â����������", "�п���Ŭ��������������", "��4���а�"},
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
                Questiontext.text = "���� 3�� ��" +answerCount +"���� ������ϴ�. 3���� ����â�� ����˴ϴ�.";
                questManager.questActionIndex++;
            }
            else
            {
                Questiontext.text = "���� 3�� ��" +answerCount +"���� ������ϴ�. �ٽ� �����غ�����. 3���� ����â�� ����˴ϴ�.";
                
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
                Debug.Log(i+1 + "������ ���似��");
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