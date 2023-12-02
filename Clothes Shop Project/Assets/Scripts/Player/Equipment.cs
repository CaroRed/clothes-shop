using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum EquipmentType {Hat, Pant, Shirt, Shoes};

    [System.Serializable]
    public class Equipment
    {
        public int id;
        public string name;
        public GameObject itemObj;
        public EquipmentType equipmentType;

        public Equipment(int id, string name, EquipmentType type)
        {
            this.id = id;
            this.name = name;
            Type = type;
        }

        public EquipmentType Type { get; }
    }
