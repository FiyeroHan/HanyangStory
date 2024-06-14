using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection;
//using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour, IPointerDownHandler
{
    public TMP_Text dialogueText;
    public GameObject takeButton;
    public CanvasGroup dialogueGruop;
    public Queue<string> sentences;

    private string currentSentence;

    public float typingSpeed = 0.1f;
    private bool isTyping;

    public static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();    
    }

    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach(string line in lines)
        {
            sentences.Enqueue(line);
        }
        dialogueGruop.alpha = 1;
        dialogueGruop.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();
            isTyping = true;
            takeButton.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else
        {
            dialogueGruop.alpha = 0;
            dialogueGruop.blocksRaycasts = false;            
        }
    }

    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach(char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueText.text.Equals(currentSentence))
        {
            if(sentences.Count == 0) takeButton.SetActive(true);
            isTyping=false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isTyping)
        {
            NextSentence();
        }
        
    }
}
