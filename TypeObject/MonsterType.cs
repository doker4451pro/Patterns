using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MonsterType", menuName = "Monster Type", order = 51)]
public class MonsterType : ScriptableObject
{

    [SerializeField] private List<MonsterType> _weakness;
    [SerializeField] private int _startHealt;

    public bool HasWeaknessAgainst(MonsterType monster) 
    {
        return _weakness.Contains(monster);
    } 
    public int GetHealth()=>
        _startHealt;
}
