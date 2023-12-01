using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public enum EquipmentType {Hat, Pant, Shirt, Shoes};

    [SerializeField] private List<Equipment> equipment = new List<Equipment>();

    [System.Serializable]
    public class Equipment
    {
        public int id;
        public string name;
        public EquipmentType equipmentType;
    }

}


