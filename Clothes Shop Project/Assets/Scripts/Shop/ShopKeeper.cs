using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] ShopInventory shopInventory;
    ShopDialogue shopDialogue;

    [SerializeField] bool isPlayerInShop = false;
    private void Start() {
        shopDialogue = GetComponent<ShopDialogue>();
    }
    
    public void DisplayShopKeeperOptions()
    {
        Debug.Log("has trigger on me!");
        //shopInventory.DisplayPanel();
        if(isPlayerInShop) 
        {
            shopDialogue.SetDialogue(2);
            shopInventory.DisplayOptionsPanel();
            //Invoke("HideDialogueOptions", 3.0f);
        }
        
    }

    public void HideDialogueOptions()
    {
        shopDialogue.HideBox();
        shopInventory.HideOptionsPanel();
    }

    public void SetPlayerInShop(bool value)
    {
        isPlayerInShop = value;
    }

    /*
    private void OnMouseUp() {
        shopDialogue.HideBox();
        shopInventory.HideOptionsPanel();
    }*/
}
