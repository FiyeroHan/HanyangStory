using System;
using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public string questName; // 퀘스트이름
    public int[] npcId; // 그 퀘스트와 연관된 npc의 id

    public QuestData(string name, int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}
