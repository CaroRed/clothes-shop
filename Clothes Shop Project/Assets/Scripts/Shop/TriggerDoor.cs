using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{

    [SerializeField] ShopDialogue shopDialogue;
    [SerializeField] ShopKeeper shopKeeper;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
                 Debug.Log("Welcome the shop");
                 shopDialogue.SetDialogue(0);
                 shopKeeper.SetPlayerInShop(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
                 Debug.Log("goodbye the shop");
                 shopDialogue.SetDialogue(1);
                 shopKeeper.SetPlayerInShop(false);
        }
    }
}
