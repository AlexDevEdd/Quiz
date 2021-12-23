using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    [SerializeField] private string _indentifier;
    [SerializeField] private int _capacityLvl;

    public string Indentifier => _indentifier;
    public int CapacityLvl => _capacityLvl;
}

