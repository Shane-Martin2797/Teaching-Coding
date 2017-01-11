using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour
{

    public List<Character> characters = new List<Character>();

    public List<Character> blueTeam;
    public List<Character> redTeam;

    public int teamSize = 25;

    bool init = false;

    // Use this for initialization
    void Start()
    {
        //Create Teams
        blueTeam = new List<Character>();
        redTeam = new List<Character>();

        //Populate Teams with Characters
        for (int i = 0; i < teamSize; i++)
        {
            Character blueDude = new Character();
            Character redDude = new Character();

            blueDude.Initialise();
            redDude.Initialise();

            blueTeam.Add(blueDude);
            redTeam.Add(redDude);

            characters.Add(blueDude);
            characters.Add(redDude);
        }


        //Order Teams
        redTeam.OrderBy(r => r.stats.damage);
        blueTeam.OrderBy(b => b.stats.damage);
        characters.OrderBy(character => character.stats.speed);

        //Initialisation Finished
        init = true;
    }

    private int numOfRounds = 0;

    void PlayRound()
    {
        Debug.Log("Round " + (numOfRounds + 1).ToString());

        int charNumber = 0;

        while (charNumber < characters.Count)
        {
            Debug.Log("Char " + charNumber);

            if(redTeam.Count == 0 || blueTeam.Count == 0)
            {
                EndGame();
                break;
            }

            Character attacker = characters[charNumber];

            bool attackerIsRed = redTeam.Contains(attacker);

            Character defender;

            if (attackerIsRed)
            {
                defender = blueTeam[0];
            }
            else
            {
                defender = redTeam[0];
            }

            if (defender.TakeDamage(attacker.CalculateDamage()))
            {
                attacker.peopleKilled++;

                if(characters.IndexOf(defender) < charNumber)
                {
                    charNumber--;
                }

                characters.Remove(defender);

                if (attackerIsRed)
                {
                    Debug.Log("Blue Team has lost a member");
                    blueTeam.Remove(defender);
                }
                else
                {
                    Debug.Log("Red Team has lost a member");
                    redTeam.Remove(defender);
                }

                if (redTeam.Count == 0 || blueTeam.Count == 0)
                {
                    EndGame();
                    break;
                }
            }

            charNumber++;
        }

        numOfRounds++;
    }


    void EndGame()
    {
        if (redTeam.Count == 0)
        {
            Debug.Log("Blue Team Wins!");
            Debug.Log("With " + blueTeam.Count + " Members Left.");
        }
        else
        {
            Debug.Log("Red Team Wins!");
            Debug.Log("With " + redTeam.Count + " Members Left.");
        }
    }

    void Update()
    {
        if(!init)
        {
            return;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            PlayRound();
        }
    }
	
}
