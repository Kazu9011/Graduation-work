using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "AssetData/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    int _hp;
    [SerializeField]
    int _exp;
    [SerializeField]
    int _level;

    public int Hp => _hp;
    public int Exp => _exp;
    public int Level => _level;
}
