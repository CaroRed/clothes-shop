using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerEquipment;

[CreateAssetMenu (fileName = "Item", menuName = "Item Shop")]
public class ShopItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public string despcrition;
    public float price;
    public Sprite image;
    public EquipmentType equipmentType;
}
