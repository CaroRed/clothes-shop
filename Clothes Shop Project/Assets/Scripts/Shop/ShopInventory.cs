using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ShopInventory : MonoBehaviour
{
    [SerializeField] ShopItemData[] itemsToSell;
    [SerializeField] GameObject itemsContainer;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject optionsPanel;

    [SerializeField] PlayerInventory playerInventory;
    void Start()
    {
        Debug.Log("count items_ " + itemsToSell.Length);

        LoadItems();
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
            Button.GetComponent<Button>().onClick.AddListener(() => BuyClick(item));
        }
    }

    private void BuyClick(ShopItemData item)
    {
       playerInventory.AddItemToInventory(item);
    }

  
}
