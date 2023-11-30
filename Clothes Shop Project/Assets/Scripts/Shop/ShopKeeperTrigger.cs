using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperTrigger : MonoBehaviour
{
    [SerializeField] ShopKeeper shopKeeper;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            shopKeeper.DisplayShopKeeperOptions();
        }
    }

        private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            shopKeeper.HideDialogueOptions();
        }
    }
}
