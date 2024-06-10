using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public string[] sentencesSTEM;
    public string[] sentencesOther;
    public int status = 0;

    public GameObject ChoicePanel;
    public void takeButton()
    {
        if(status == 0)
        {
            DialogueManager.instance.dialogueGruop.alpha = 0;
            DialogueManager.instance.dialogueGruop.blocksRaycasts = false;        
            ChoicePanel.SetActive(true);
        }
        else if (status == 1)
        {
            ChoicePanel.SetActive(true);
        }
        else if (status == 2)
        {
            SceneManager.LoadScene("QuizStart");
        }
    }

    public void ChoiceSTEM()
    {
        ChoicePanel.SetActive(false);
        if(DialogueManager.instance.dialogueGruop.alpha == 0) DialogueManager.instance.Ondialogue(sentencesSTEM);
        status = 2;
    }
    public void ChoiceLiberalArts()
    {
        ChoicePanel.SetActive(false);
        if(DialogueManager.instance.dialogueGruop.alpha == 0) DialogueManager.instance.Ondialogue(sentencesOther);
        status = 1;
    }
    public void ChoiceSportsAndArts()
    {
        ChoicePanel.SetActive(false);
        if(DialogueManager.instance.dialogueGruop.alpha == 0) DialogueManager.instance.Ondialogue(sentencesOther);
        status = 1;
    }
}
