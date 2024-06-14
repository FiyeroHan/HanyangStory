using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quizePanel : MonoBehaviour
{
    public QuestManager questManager;
    public GameManager gameManager;
    public TalkManager talkManager;
    public QuizManager quizManager;
    public GameObject[] questIconList;
    int chatId;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable() {
        quizManager.answerCount= 0;
        chatId = gameManager.nowObjId+ questManager.GetQuestTalkIndex();
        quizManager.GenerateQuiz(gameManager.nowObjId+ questManager.GetQuestTalkIndex());
        quizManager.makeQuestion();
    }

    // private void OnDisable() {
    //     quizManager.qna.Clear();
    //     if(chatId == 3020)
    //     {
    //         questIconList[0].SetActive(true);
    //     }
    //     else if(chatId == 4030)
    //     {
    //         questIconList[1].SetActive(true);
    //     }
    //     else if(chatId == 5040)
    //     {
    //         questIconList[2].SetActive(true);
    //     }
    //     else if(chatId == 6050)
    //     {
    //         questIconList[3].SetActive(true);
    //     }
    // }
}
