using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public Stats stats;

    public int peopleKilled = 0;

    public void Initialise()
    {
        stats = new Stats();

        stats.Initialise();
    }

    public int CalculateDamage()
    {
        int damage = stats.damage.value;

        if(Random.Range(0,101) < stats.luck.value)
        {
            damage = Mathf.RoundToInt((float)(damage) * 2.5f);
        }

        return damage;
    }

    public bool TakeDamage(int damage)
    {
        stats.health.value -= damage;

        return stats.health.value <= 0;
    }

}
