using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatPanel : MonoBehaviour
{
    public GameManager gameManager;
    public QuestManager questManager;
    public TalkManager talkManager;
    public QuizManager quizManager;
    public TMP_Text Text;
    int chatId;
    int questCharId;
    public Button NextButton;
    public Button YesButton;
    public Button StopButton;
    public GameObject questIcon;
    public GameObject quizUI;
    public GameObject selectPanel;
    // public Button STEMhanyang, LiberalArtshanyang, ArtSportHanyang;

    private void Start() {
        this.gameObject.SetActive(false);
        if(selectPanel){
            selectPanel.SetActive(false);
        }
    }
    private void OnEnable() {
        chatId = gameManager.nowObjId+ questManager.GetQuestTalkIndex();
        questCharId = gameManager.nowObjId + questManager.questId;
        Text.text = talkManager.GetTalk(chatId, gameManager.talkIndex);
//        Debug.Log("talkIndex: "+ gameManager.talkIndex+", talkData[questCharId].Length: "+ talkManager.talkData[questCharId].Length );
        if(gameManager.talkIndex == talkManager.talkData[chatId].Length-1){
            YesButton.gameObject.SetActive(true);
        }
        else
        {
            NextButton.gameObject.SetActive(true);
        }
        StopButton.gameObject.SetActive(true);
        

    }

    public void ClickNextButton()
    {
        gameManager.talkIndex++;
        Text.text = talkManager.GetTalk(chatId, gameManager.talkIndex);
        if(gameManager.talkIndex == talkManager.talkData[chatId].Length-1){
            NextButton.gameObject.SetActive(false);
            YesButton.gameObject.SetActive(true);
            //Debug.Log(string.Format("{0}, {1}",chatId, gameManager.talkIndex));
            if(chatId == 1011 && gameManager.talkIndex == 2)
            {
                selectPanel.SetActive(true);
            }
        }
    }
    public void ClickYesButton()
    {
        gameManager.talkIndex = 0;
        this.gameObject.SetActive(false);
        YesButton.gameObject.SetActive(false);
        if(chatId == 3020 || chatId == 4030 || chatId == 5040 || chatId == 6050)
        {
            quizUI.gameObject.SetActive(true);
            // if(true) //퀴즈정답
            // {
            //     Debug.Log(questManager.CheckQuest(gameManager.nowObjId)); //questActionIndex 1추가 혹은 QuestLevel 증가.    
            // }
        }
        else
        {
            Debug.Log(questManager.CheckQuest(gameManager.nowObjId)); //questActionIndex 1추가 혹은 QuestLevel 증가.
            //questIcon.SetActive(true);
        }
        
        
    }

    public void ClickStopButton()
    {
        gameManager.talkIndex = 0;

        StopButton.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        YesButton.gameObject.SetActive(false);

    }

    // public void ClickSTEMHanyang()
    // {
    //     STEMhanyang.gameObject.SetActive(false);
    //     LiberalArtshanyang.gameObject.SetActive(false);
    //     ArtSportHanyang.gameObject.SetActive(false);        
    //     this.gameObject.SetActive(true);
    // }


}
