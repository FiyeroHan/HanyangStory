using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public GameManager gameManager;

    //대화 데이터를 저장할 Dictionary 변수 생성
    public Dictionary<int, string[]> talkData;
//    Dictionary<int, Sprite> portraitData;

    public Sprite[] portaitArr;


    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        // portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {

        /* Talk Data
        대화 데이터 입력 추가. 표정을 바꾸는 구분자는 |로 지정.
        구분자와 함께 
        NPC ID를 입력해 기본 대사를 지정.
*/
        talkData.Add(1000, new string[]{"야옹?"});
        talkData.Add(2000, new string[]{"나는 이공계를 주름잡는 이공계하냥이다냥"});
        talkData.Add(3000, new string[]{"대학원 납치를 조심해."});
        talkData.Add(4000, new string[]{"에리카는 공대빼면 시체지! 암!"});
        talkData.Add(5000, new string[]{"약사로 가는 길은 험난하도다.."});
        talkData.Add(6000, new string[]{"소융대 건물 언제 지어짐? (진짜 모름)"});  

        /*
        1000- 시작하냥이
        2000- 이공계 하냥이
        3000- 과기대 하냥이
        4000- 공대 하냥이
        5000- 약대 하냥이
        6000- 소융대 하냥이
        */

        /* Quest Talk Data
        퀘스트 번호 + NPC id통해 해당 퀘스트에 해당 NPC가 할 대사를 작성
        */
        talkData.Add(10+1000, new string[]{ "안녕, 난 한양대학교의 마스코트 하냥이야.", 
                                        "요즘 고민이 하나 있어.. 내가 아끼던 빛구슬이 있는데, 이 구슬이 날라갔는데 깨지는 소리와 함께 잃어버렸어..",
                                        "아, 빛구슬이 뭐냐면, 주변 빛을 흡수해서 빛을 내는 구슬이야.",
                                        "이 구슬을 찾으려고 캠퍼스 여기저기를 조사하려는데 캠퍼스가 너무 커서 나 혼자는 무리인거 있지?",
                                        "그래서 캠퍼스를 나눠서 조사를 해보는거야! ... 물론 너의 의견이 있어야하지만.",
                                        "그럼 혹시 나를 위해 구슬을 찾으러 조사를 가줄 수 있니??"});

        talkData.Add(11+1000, new string[]{"고마워! 내 전략은 우리 학교 캠퍼스가 워낙 크니까 전공계열별로 나눠서 탐색해보는거야.",
                                        "나는 문과계열과 예체계열을 탐색해볼게. 너가 이공계열을 맡아서 탐색하면 될거같아",
                                        "아, 본관 앞에 있는 하냥이한테 가봐. 본관에 하냥이가 이공계열을 잘 알고 있거든. 구슬이 어딨는지 알 수도 있어!"});

        talkData.Add(12+1000, new string[]{ "아직 출발 안했어? 본관 앞에 있는 하냥이에게 가보렴!"});

        talkData.Add(12+2000, new string[]{ "그래. 너가 올줄 알았어. 내가 발명한 첨단동적위치계산기를 통해 너를 계속 봐왔거든!",
                                        "흠흠.. 암튼 반가워. 근데 나한테 어떤 일로 찾아 온거야?",
                                        "(처음 본 하냥이와 있었던 일을 설명한다.)",
                                        "아하! 하여간 칠칠맞긴! 며칠전에 그 광경을 보긴했지.",
                                        "구슬이 바닥에 떨어져서 4 조각으로 깨졌지. 그걸 다른 하냥이들이 빠르게 가져가더라고!",
                                        "어떤 하냥이가 가져갔냐고? 음... 기억이 안나는데...",
                                        "아! 그 중 하나가 과기대 하냥이였어. 걔한테 찾아가서 달라고 해봐.",
                                        "과기대 하냥이는 제1 과학기술관 1층에서 서식하고있어. 그럼 고고씽~"});



        talkData.Add(20+2000, new string[]{ "과기대 하냥이는 제1 과학기술관 1층에 있어. 아마 4조각을 다 모으면 저절로 구슬이 완성이 될거야!"});   

        talkData.Add(20+3000, new string[]{ "으앙ㅠㅠㅠㅠㅠㅠ",
                                            "내년에 저희 과학기술대학이 없어진다고요...",
                                            "근데 누구세요..? 연구실에 관심있어서 찾아오셨나요?",
                                            "네? 대학원 안간다고요? 근데 과기대엔 무슨일로...?",
                                            "아 빛구슬조각이요? 산책하다가 은은하게 빛나는게 신기하더라고요. 그래서 구성원소랑 강도 등을 분석하려고 줏어왔어요.",
                                            "이걸 그냥 드릴 수는 없어요. 저희도 아직 연구시작도 못한걸요",
                                            "하지만, 내년에 저희 과기대가 어떻게 바뀌는지에 대해 퀴즈를 맞추면 선물로 드릴게요.",
                                            "퀴즈 시작 전에 간단하게 알려드릴게요.",
                                            "응용물리학과, 의약생명학과, 나노광전자학과는 첨단융합대학 소속으로 바뀌어요. 각각 국방지능정보융합학부, 바이오신약융합학부, 차세대반도체융합공학부로 소속 및 명칭이 바뀌죠.",
                                            "화학분자공학과와 해양융합공학과는 공학대학 소속의 에너지바이오학과, 해양융합공학과로 변경돼요.",
                                            "마지막으로 수리데이터사이언스학과는 소프트웨어융합대학 소속으로 변경돼요.",
                                            "어때요. 쉽지 않겠죠? 생각 정리를 하고 다시 말을 걸어주세요. 그럼 바로 퀴즈를 시작할게요."});

        talkData.Add(21+3000, new string[]{"오 대단하신걸요? 저희 과기대에 관심을 가져주셔서 감사해요.",
                                            "약속은 약속이니까 구슬 조각을 드릴게요.",
                                            "다른 조각은 어디에 있냐고요?",
                                            "저는 매일 연구실에 있어서 잘 모르겠네요. 아, 그때 산책하던 공대 하냥이를 보긴 했어요. 공대 하냥이를 찾아가보실래요?",
                                            "공대 하냥이는 1공학관 3층에 자주 출몰하더라구요."});

        talkData.Add(30 + 3000, new string[] { "매일이 실험과 논문 리딩의 반복이구나.... 아! 혹시 저희 연구실 들어오실래요?" });

        talkData.Add(30 + 4000, new string[] {  "오, 찾아오다니.. 생각보다 쓸만한 놈인걸?" });
        talkData.Add(30 + 1000, new string[] {  "왜? 무슨일 있어?" });
        talkData.Add(30 + 2000, new string[] {  "더 이상은 귀찮으니까 말 걸지 말아줄래?" });
 
    }


    //지정된 대화 문장을 반환하는 함수. 대화 예외처리.
    public string GetTalk(int id, int talkIndex) // id값과, 몇번째 문장을 들고올지.
    {
        if(!talkData.ContainsKey(id)) //talkData에 id가 없으면
        {
            if(!talkData.ContainsKey(id-id%10))  // 해당 퀘스트 기본 대사가 없을때
                return GetTalk(id-id%100, talkIndex); // 디폴트 대사
            else //기본 대사는 있으면
                return GetTalk(id-id%10, talkIndex); // 퀘스트 처음 대사
        }

        if(talkIndex == talkData[id].Length) 
            return null;
        else
            // Debug.Log(talkData[id][0]);
            // Debug.Log(talkIndex); 
            // Debug.Log(talkData[id][talkIndex]);
            return talkData[id][talkIndex];
        
        /*
        if(!talkData.ContainsKey(id)) //id가 포함되어 있지 않다면.
        {
            if(!talkData.ContainsKey(id-id%10))
            {
                if(talkIndex == talkData[id-id%100].Length)
                    return null;
                else
                    return talkData[id -id%100][talkIndex];
            }
            else
            {
                if(talkIndex == talkData[id - id%10].Length)
                    return null;
                else
                    return talkData[id - id%10][talkIndex];
            }

        } */
        

        
    }

    // public Sprite GetPortrait(int id, int portraitIndex)
    // {
    //     return portraitData[id + portraitIndex];
    // }
}
