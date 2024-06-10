using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSentence : MonoBehaviour
{
    public string[] sentences;

    private void OnMouseDown() 
    {
        if(DialogueManager.instance.dialogueGruop.alpha == 0) DialogueManager.instance.Ondialogue(sentences);    
    }
}
