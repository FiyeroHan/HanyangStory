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
    public TMP_Text Text;
    int chatId;
    int questCharId;
    public Button NextButton;
    public Button YesButton;
    public GameObject questIcon;
    // public Button STEMhanyang, LiberalArtshanyang, ArtSportHanyang;

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
        

    }

    public void ClickNextButton()
    {
        gameManager.talkIndex++;
        Text.text = talkManager.GetTalk(chatId, gameManager.talkIndex);
        if(gameManager.talkIndex == talkManager.talkData[chatId].Length-1){
            NextButton.gameObject.SetActive(false);
            YesButton.gameObject.SetActive(true);
        }
    }
    public void ClickYesButton()
    {
        gameManager.talkIndex = 0;
        Debug.Log(questManager.CheckQuest(gameManager.nowObjId)); //questActionIndex 1추가 혹은 QuestLevel 증가.
        this.gameObject.SetActive(false);
        YesButton.gameObject.SetActive(false);
        // if(chatId == 1110)
        // {
        //     STEMhanyang.gameObject.SetActive(true);
        //     LiberalArtshanyang.gameObject.SetActive(true);
        //     ArtSportHanyang.gameObject.SetActive(true);
            
        // }
        // else if(false)
        // {

        // }
        // else{
        //     questIcon.SetActive(true);
        // }
        questIcon.SetActive(true);
        
    }

    // public void ClickSTEMHanyang()
    // {
    //     STEMhanyang.gameObject.SetActive(false);
    //     LiberalArtshanyang.gameObject.SetActive(false);
    //     ArtSportHanyang.gameObject.SetActive(false);        
    //     this.gameObject.SetActive(true);
    // }


}
