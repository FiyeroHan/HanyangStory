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


    //�÷��̾ 
    public void Action(GameObject scanObj)
    {

        Debug.Log("Action");
        //���� ������ ������Ʈ���� Id�� npc���� ���� ��������
        scanObject = scanObj;
        ObjData objData = scanObj.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        //��ȭâ ���̱�
        talkPanel[objData.id/1000-1].SetActive(isAction);
    }


    void Talk(int id, bool isNpc)
    {

        Debug.Log("Talk");
        //��ȭ ������ ����
        int questTalkIndex = questManager.GetQuestTalkIndex();
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        // Debug.Log(talkData);
        //��ȭ ��������
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id)); //questActionIndex 1�߰�
            return;
        }

        //��ȭ ����ϱ�
        // if(isNpc)
        // {
            // |���� ���������� �պκ� = ���� ���
        talkText.text = talkData;


            //NPC�̹��� ���̱�


//            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split('|')[1]));

//            portraitImg.color = new Color(1,1,1,1);
        // }

//         else
//         {
//             talkText.text = talkData;

//             //NPC�� �ƴҶ� ���� 0
// //            portraitImg.color = new Color(1,1,1,0);
//         }

        isAction = true;
        talkIndex++;
        return; // ���� ������ �������� �ε��� 1 ����
    }

}
