using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils.Datums;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
//        questList.Add(10,new QuestData("�̰��� �ϳ��� ã�ư���", new int[]{}));
    }
}