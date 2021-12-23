using System;
using UnityEngine;

[Serializable]
public class CardData
{
    [SerializeField] private string _indentifier;
    [SerializeField] private Sprite _sprite;

    public string Indentifier => _indentifier;
    public Sprite Sprite => _sprite;
}

