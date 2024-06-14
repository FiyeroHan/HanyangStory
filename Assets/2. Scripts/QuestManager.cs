using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils.Datums;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;
using System.Security.Cryptography.X509Certificates;



#if UNITY_EDITOR
using UnityEditor.VersionControl;
#endif


public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex; //퀘스트 대화 순서 변수
    public GameObject questObject;//퀘스트 오브젝트를 저장할 변수
    public int objectCount; // 오브젝트 개수
    public TMP_Text objectCountText;

    
    Dictionary<int, QuestData> questList;

    void Awake()
    {
        objectCount = 0;
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        //퀘스트 ID, 퀘스트 데이터(퀘스트이름, 관련 NPC)
        questList.Add(10,new QuestData("본관 하냥이 찾아가기", new int[]{1000, 1000, 2000}));
        questList.Add(20,new QuestData("과기대 하냥이 찾아가기", new int[]{3000, 3000}));
        questList.Add(30,new QuestData("공대 하냥이 찾아가기", new int[]{4000, 4000}));
        questList.Add(40,new QuestData("약대 하냥이 찾아가기", new int[]{5000, 5000}));
        questList.Add(50,new QuestData("소융대 하냥이 찾아가기", new int[]{6000, 6000}));
        questList.Add(60,new QuestData("구슬 전해주러가기", new int[]{1000}));
        /*
        1000- 시작하냥이
        2000- 이공계 하냥이
        3000- 과기대 하냥이
        4000- 공대 하냥이
        5000- 약대 하냥이
        6000- 소융대 하냥이
        */
        
    }


    public int GetQuestTalkIndex()
    {
        //퀘스트 ID + 퀘스트 대화 순서 ex) 1100, 1101 ...
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        //대화가 끝나면 다음 대화. 1번 NPC 다음 2번 NPC.
        if(id == questList[questId].npcId[questActionIndex]) questActionIndex++;
        
//        ControlObject();

        //대화 완료, 다음 퀘스트 진행
        if(questActionIndex == questList[questId].npcId.Length) NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
//        Debug.Log(questId);
//        Debug.Log(questList[questId].questName);
        return questList[questId].questName;
    }

    void NextQuest()
    {
        if (questId == 10){
            questObject.SetActive(true);
        }
        
        else if(questId >= 20 && questId <= 50)
        {
            objectCount++;
            objectCountText.text = string.Format( "X {0}", objectCount);    
        }

        else if (questId == 60)
        {
            questObject.SetActive(false);
            return;
        }


        questId += 10;
        questActionIndex = 0;
        Debug.Log(CheckQuest());
        return;
        

    }

// 열쇠같은 퀘스트 오브젝트 관리 
    // void ControlObject()
    // {
    //     switch (questId)
    //     {
    //         case 10:
    //             if(questActionIndex == 2) questObject.SetActive(true);
    //             break;
    //         case 20:
    //             if(questActionIndex == 1) questObject[0].SetActive(false);
    //             break;
    //     }
    // }


}

//  앞으로할거: 유리구슬, 맵 합치기, 퀘스트 이름 뜨게 하기, 빌드 테스트, 영상 촬영 