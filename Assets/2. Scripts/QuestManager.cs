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
    public int questActionIndex; //����Ʈ ��ȭ ���� ����
    public GameObject questObject;//����Ʈ ������Ʈ�� ������ ����
    public int objectCount; // ������Ʈ ����
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
        //����Ʈ ID, ����Ʈ ������(����Ʈ�̸�, ���� NPC)
        questList.Add(10,new QuestData("���� �ϳ��� ã�ư���", new int[]{1000, 1000, 2000}));
        questList.Add(20,new QuestData("����� �ϳ��� ã�ư���", new int[]{3000, 3000}));
        questList.Add(30,new QuestData("���� �ϳ��� ã�ư���", new int[]{4000, 4000}));
        questList.Add(40,new QuestData("��� �ϳ��� ã�ư���", new int[]{5000, 5000}));
        questList.Add(50,new QuestData("������ �ϳ��� ã�ư���", new int[]{6000, 6000}));
        questList.Add(60,new QuestData("���� �����ַ�����", new int[]{1000}));
        /*
        1000- �����ϳ���
        2000- �̰��� �ϳ���
        3000- ����� �ϳ���
        4000- ���� �ϳ���
        5000- ��� �ϳ���
        6000- ������ �ϳ���
        */
        
    }


    public int GetQuestTalkIndex()
    {
        //����Ʈ ID + ����Ʈ ��ȭ ���� ex) 1100, 1101 ...
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        //��ȭ�� ������ ���� ��ȭ. 1�� NPC ���� 2�� NPC.
        if(id == questList[questId].npcId[questActionIndex]) questActionIndex++;
        
//        ControlObject();

        //��ȭ �Ϸ�, ���� ����Ʈ ����
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

// ���谰�� ����Ʈ ������Ʈ ���� 
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

//  �������Ұ�: ��������, �� ��ġ��, ����Ʈ �̸� �߰� �ϱ�, ���� �׽�Ʈ, ���� �Կ� 