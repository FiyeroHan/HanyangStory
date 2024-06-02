using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARInteractableObject : MonoBehaviour
{
    public int maxInteractionStep;
    public int currentInteractionStep;
    public DialogData dialogData;

    void Start()
    {
        maxInteractionStep = dialogData.SoftWareDialog.Length;
        currentInteractionStep = 0;
        UpdateObject();
    }

    // Update is called once per frame
    public void UpdateObject()
    {
        this.GetComponentInChildren<TextMeshProUGUI>().text = dialogData.SoftWareDialog[currentInteractionStep];
        if(currentInteractionStep == maxInteractionStep) currentInteractionStep = 0;
        else currentInteractionStep++;

    }
}
