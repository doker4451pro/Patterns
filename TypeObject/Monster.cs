using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private List<MonsterType> _monsterTypes;
    private int _health;

    private void Start()
    {
        foreach (var item in _monsterTypes)
        {
            _health += item.GetHealth();
        }
    }

    public int GetHeath() =>
        _health;

    public void TakeDamageFrom(MonsterType monster, int damage) 
    {
        if (HasWeaknessAgains(monster))
            _health -= damage * 2;
        else
            _health -= damage;
    }

    private bool HasWeaknessAgains(MonsterType monster) 
    {
        foreach (var item in _monsterTypes)
        {
            if (item.HasWeaknessAgainst(monster))
                return true;
        }
        return false;
    }
}
