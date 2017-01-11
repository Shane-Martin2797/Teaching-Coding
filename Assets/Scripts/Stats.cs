using UnityEngine;
using System.Collections;

[System.Serializable]
public class Stat
{
	public int value;
}

[System.Serializable]
public class Stats
{
	public Stat damage;
	public Stat health;
	public Stat speed;
    public Stat luck;

    public void Initialise()
    {
        damage = new Stat();
        health = new Stat();
        speed = new Stat();
        luck = new Stat();


        damage.value = Random.Range(2, 11);

        health.value = Random.Range(5, 21);

        speed.value = Random.Range(0, 101);

        luck.value = Random.Range(0, 51);
    }
}
