using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShopDialogue : MonoBehaviour
{
    [SerializeField] TextMeshPro textDialogue;
    [SerializeField] GameObject dialogueBox;
    
    [SerializeField] string[] dialogues;

    public void SetDialogue(int index)
    {
        textDialogue.text = dialogues[index];
        DisplayBox();

        if(index <= 1)
        {
            Invoke("HideBox", 2.0f);
        }
    }

    public void HideBox()
    {
        dialogueBox.SetActive(false);
    }

    public void DisplayBox()
    {
        dialogueBox.SetActive(true);
    }
}
