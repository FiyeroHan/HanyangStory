using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeButton : MonoBehaviour
{   
    public void LoadFisrtScene()
    {
        SceneManager.LoadScene("AR UI");
    }
    public void LoadQuizScene()
    {
        SceneManager.LoadScene("New");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
