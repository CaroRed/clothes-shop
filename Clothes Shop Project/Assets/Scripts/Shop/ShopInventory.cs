using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ShopInventory : MonoBehaviour
{
    public ShopItemData[] itemsToSell;
    [SerializeField] GameObject itemsContainer;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject optionsPanel;

    [SerializeField] PlayerInventory playerInventory;
    void Start()
    {
        //Debug.Log("Shop Inventory Start");

        playerInventory.onSellItem += CheckItems;

        LoadItems();
        CheckItems();
    }

    private void CheckItems()
    {
        //Debug.Log("Player sell something");

        foreach (Transform child in itemsContainer.transform)
        {
            GameObject Button = child.transform.GetChild(3).gameObject;
            Button buyBtn = Button.GetComponent<Button>();
            string btnName = buyBtn.name;
            
            string[] parts = btnName.Split('_'); 
            int itemId = int.Parse(parts[1]);

            if(playerInventory.IsItemOnPlayerInventory(itemId))
            {
                buyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "BUYED";
                buyBtn.interactable = false;
            }else{
                buyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "BUY";
                buyBtn.interactable = true;    
            }
        }

    }

    public void DisplayOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }

    public void DisplayPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }

    void LoadItems()
    {
        foreach(ShopItemData item in itemsToSell)
        {
            GameObject newItem = Instantiate(itemPrefab, itemsContainer.transform);
            GameObject Image = newItem.transform.GetChild(0).gameObject;
            GameObject itemImage = Image.transform.GetChild(0).gameObject;
            itemImage.GetComponent<Image>().sprite = item.image;

            GameObject Title = newItem.transform.GetChild(1).gameObject;
            Title.GetComponent<TextMeshProUGUI>().text = item.itemName;

            GameObject Price = newItem.transform.GetChild(2).gameObject;
            Price.GetComponent<TextMeshProUGUI>().text = "$"+item.price.ToString();
            
            GameObject Button = newItem.transform.GetChild(3).gameObject;
            Button buyBtn = Button.GetComponent<Button>();

            buyBtn.name = "buyBtn_"+item.id;
            
            buyBtn.onClick.AddListener(() => BuyClick(item, buyBtn));
        }

        
    }

    private void BuyClick(ShopItemData item, Button buyBtn)
    {
       playerInventory.AddItemToInventory(item, buyBtn);
    }

    private void OnDisable() {
        playerInventory.onSellItem -= CheckItems;
    }


    public Sprite SpriteItemById(int idItem)
{
    foreach (ShopItemData item in itemsToSell)
    {
        if (item.id == idItem)
        {
            return item.image; // Return the item if the ID matches
        }
    }

    return null; // Return null if no item with the specified ID is found
}
    
  
}
