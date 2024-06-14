using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARInteractableObject : MonoBehaviour
{
    //public int maxInteractionStep;
    //public int currentInteractionStep;
    //public DialogData dialogData;
    public GameManager gameManager;
    public GameObject chatPanel;

    void Start()
    {
        //maxInteractionStep = dialogData.SoftWareDialog.Length;
        //currentInteractionStep = 0;
        //UpdateObject();
    }

    // Update is called once per frame
    public void UpdateObject()
    {
        //Debug.Log("LeanToooouch");
        if(this.gameObject.tag == "questIcon")
        {
            //Debug.Log("Queeeeeestion");
            gameManager.nowObjId = this.gameObject.GetComponent<ObjData>().id;
            chatPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }

//        Debug.Log("UpdateObject");
        // gameManager.Action(this.gameObject);
        // this.GetComponentInChildren<TextMeshProUGUI>().text = dialogData.SoftWareDialog[currentInteractionStep];
        // if(currentInteractionStep == maxInteractionStep) currentInteractionStep = 0;
        // else currentInteractionStep++;

    }
}
