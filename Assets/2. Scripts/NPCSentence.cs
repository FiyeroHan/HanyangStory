using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSentence : MonoBehaviour
{
    public string[] sentences;
    public GameObject panel;
    private void OnMouseDown() 
    {
        //if(DialogueManager.instance.dialogueGruop.alpha == 0) DialogueManager.instance.Ondialogue(sentences);    
        panel.SetActive(true);
    }
}
