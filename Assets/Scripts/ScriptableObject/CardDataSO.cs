using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardDataSO", menuName = "Card Data SO", order = 10)]
public class CardDataSO : ScriptableObject
{
    [SerializeField] private CardData[] _cardData;

    public CardData[] CardData => _cardData;
}

