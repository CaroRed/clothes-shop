using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject itemsContainer;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject panelItemExists;
    [SerializeField] private List<InventoryItem> inventory = new List<InventoryItem>();

    private void Start() {
        LoadInventory();
    }
    public void DisplayPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(!panel.activeSelf)
            {
                DisplayPanel();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearInventory();
        }
    }

     public void UpdateInventoryUI()
    {
        foreach (Transform child in itemsContainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (InventoryItem item in inventory)
        {
            GameObject newItem = Instantiate(itemPrefab, itemsContainer.transform);
            GameObject Image = newItem.transform.GetChild(0).gameObject;
            GameObject itemImage = Image.transform.GetChild(0).gameObject;
            //itemImage.GetComponent<Image>().sprite = item.image;

            GameObject Title = newItem.transform.GetChild(1).gameObject;
            Title.GetComponent<TextMeshProUGUI>().text = item.name;

            GameObject Button = newItem.transform.GetChild(3).gameObject;
            Button.GetComponent<Button>().onClick.AddListener(() => Equip(item));

            GameObject Button1 = newItem.transform.GetChild(4).gameObject;
            Button1.GetComponent<Button>().onClick.AddListener(() => Sell(item));
        }
    }

    private void Sell(InventoryItem item)
    {
        Debug.Log("Sell Item " + item.name);
        float price = item.price;
        //chek if i'm equiped that item unequiped

        //sell
        CoinsManager._Instance.AddCoins((int)price);

        //remove from inventory
        RemoveItemToInventory(item);
    }

    private void Equip(InventoryItem item)
    {
        Debug.Log("Equip Item " + item.name);
    }

    public void RemoveItemToInventory(InventoryItem item){
        inventory.Remove(item);
        SaveInventory();
        UpdateInventoryUI();
    }

    public void AddItemToInventory(ShopItemData item, Button button){
        Debug.Log("Buy: " + item.name);
        InventoryItem newItem = new InventoryItem(item.id, item.itemName, item.price); 

        //check if i have enough money to buy item
        int ballance = CoinsManager._Instance.GetBallance();

        if(ballance < (int)item.price)
        {
            CoinsManager._Instance.DisplayAlertPanel();
            return;
        }

        if (!inventory.Any(item => item.id == newItem.id))
        {
            inventory.Add(newItem);
            CoinsManager._Instance.RemoveCoins((int)item.price);
            button.GetComponentInChildren<TextMeshProUGUI>().text = "BUYED";
            button.interactable = false;
        }
        else
        {
            Debug.Log("Item already exists in the inventory.");
            panelItemExists.SetActive(true);
            return;
        }


        SaveInventory();
        UpdateInventoryUI();
    }

    public void SaveInventory()
    {
        string json = JsonUtility.ToJson(new InventoryWrapper(inventory));
        PlayerPrefs.SetString("playerInventory", json);
        PlayerPrefs.Save();
    }

    public void LoadInventory()
    {
        string json = PlayerPrefs.GetString("playerInventory", "{}");
        InventoryWrapper wrapper = JsonUtility.FromJson<InventoryWrapper>(json);
        inventory = wrapper.items ?? new List<InventoryItem>();

        UpdateInventoryUI();
    }

    public void ClearInventory()
    {
        inventory.Clear();
        ClearInventoryData();
    }

    void ClearInventoryData()
    {
        PlayerPrefs.DeleteKey("playerInventory");
        PlayerPrefs.Save();
        UpdateInventoryUI();
    }

    [System.Serializable]
    class InventoryWrapper
    {
        public List<InventoryItem> items;
        public InventoryWrapper(List<InventoryItem> items)
        {
            this.items = items;
        }
    }
}

[System.Serializable]
public class InventoryItem
{
    public int id;
    public string name;
    public float price;

    public InventoryItem(int id, string name, float price)
    {
        this.id = id;
        this.name = name;
        this.price = price;
    }
}