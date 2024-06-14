using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager; 
    public QuestManager questManager;
    public GameObject[] talkPanel;
//    public Image portraitImg;
    public TMP_Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public int nowObjId;
    

    // Start is called before the first frame update

    // public static GameManager _instance;

    // void Awake()
    // {
    //     _instance = this;
    // }

    void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }


    //플레이어가 
    public void Action(GameObject scanObj)
    {

        Debug.Log("Action");
        //현재 접근한 오브젝트에서 Id와 npc여부 정보 가져오기
        scanObject = scanObj;
        ObjData objData = scanObj.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        //대화창 보이기
        talkPanel[objData.id/1000-1].SetActive(isAction);
    }


    void Talk(int id, bool isNpc)
    {

        Debug.Log("Talk");
        //대화 데이터 세팅
        int questTalkIndex = questManager.GetQuestTalkIndex();
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        // Debug.Log(talkData);
        //대화 끝났을때
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id)); //questActionIndex 1추가
            return;
        }

        //대화 계속하기
        // if(isNpc)
        // {
            // |으로 나누었을때 앞부분 = 원래 대사
        talkText.text = talkData;


            //NPC이미지 보이기


//            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split('|')[1]));

//            portraitImg.color = new Color(1,1,1,1);
        // }

//         else
//         {
//             talkText.text = talkData;

//             //NPC가 아닐땐 투명도 0
// //            portraitImg.color = new Color(1,1,1,0);
//         }

        isAction = true;
        talkIndex++;
        return; // 다음 문장이 나오도록 인덱스 1 증가
    }

}
