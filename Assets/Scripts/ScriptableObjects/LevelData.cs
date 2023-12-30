using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Create Level Data")]
public class LevelData : ScriptableObject
{
    public Level[] Level;
}

[System.Serializable]
public class Level
{
    public string LevelName;
    public int StarEarnings;
    public int CoinEarnings;
}
