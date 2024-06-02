using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizStart : MonoBehaviour
{

    public GameObject quizPanel;
    private void OnMouseDown() 
    {
        if(quizPanel) quizPanel.transform.gameObject.SetActive(true);    
    }
}
