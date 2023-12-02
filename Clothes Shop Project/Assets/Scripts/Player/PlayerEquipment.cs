using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public static PlayerEquipment _Instance;
    [SerializeField] private List<Equipment> equipment = new List<Equipment>();
    [SerializeField] private List<int> equipmentIDs = new List<int>();

    PlayerInventory playerInventory;
    private void Awake() 
    { 
        if(_Instance == null)
        {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start() {

        playerInventory = PlayerInventory._Instance;
        LoadEquipment();
    }

    public List<int> GetEquipmentIDs()
    {
        return equipmentIDs;
    }
    public void EquipItem(InventoryItem item)
    {
        if(!equipmentIDs.Contains(item.id))
        {
            equipmentIDs.Add(item.id);
            //save playerprefs equipment item
            SaveEquipment();
            //equip
            EquipItemFromData(item.id);
        }
    }

    public void EquipItemFromData(int id)
    {

        foreach (Equipment newItem in equipment)
        {
            if (id == newItem.id)
            {
                newItem.itemObj.SetActive(true);
            }
        }

        playerInventory.UpdateInventoryUI();
        
    }

    public void UnequipItem(InventoryItem item)
    {
        foreach (Equipment newItem in equipment)
        {
            if (item.id == newItem.id)
            {
                newItem.itemObj.SetActive(false);
            }
        }

        if(equipmentIDs.Contains(item.id))
        {
            equipmentIDs.Remove(item.id);
            SaveEquipment();
            playerInventory.UpdateInventoryUI();
        }

        
    }

    public void LoadEquipment()
    {
        string json = PlayerPrefs.GetString("EquipmentIDs", "{}");
        EquipmentData data = JsonUtility.FromJson<EquipmentData>(json);
        equipmentIDs = data.ids ?? new List<int>();

        foreach (int item in equipmentIDs)
        {
            EquipItemFromData(item);
        }
    }

    public void SaveEquipment()
    {
        EquipmentData data = new EquipmentData(equipmentIDs);
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("EquipmentIDs", json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    public class EquipmentData
    {
        public List<int> ids;

        public EquipmentData(List<int> ids)
        {
            this.ids = ids;
        }
    }

}


