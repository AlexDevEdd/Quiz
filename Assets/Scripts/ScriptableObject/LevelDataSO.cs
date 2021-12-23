using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelDataSO", menuName = "Level Data SO", order = 10)]

public class LevelDataSO : ScriptableObject
{
    [SerializeField] private LevelData _levelData;

    public LevelData LevelData => _levelData;
}

