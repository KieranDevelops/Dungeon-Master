using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelling : MonoBehaviour
{
    //create a player name
    public string characterName = "Paladin Raphael";
    //create a current lvl
    public int currentLevel = 0;
    //create health
    public float currentHealth = 15f;
    //create Skeleton hp
    public float skeletonHealth = 10f;
    // Levelling for enemy entity
    public int enemyLevelLow = 0;
    //Potential for higher levelling enemies

    //create an attack int
    public int attack = 0;
    //create a deffense int
    public int defense = 0;
    //create a luck int
    public int luck = 0;
    //player current exp
    public float currentPlayerXp = 0;
    //exp threshold
    public float xpthreshold = 50;
    //create a stat pool
    public int statpool = 15;
    // Players overall power
    public float playerPower = 0;
    // Enemy power
    public float enemyPower = 0;
    //A value used to multiply the characters attack value on level up
    public float attackMultiplier = 125.25f;
    //create a Keycode to roll random stat arrangment

    //public KeyCode rollInputKey; (keep for possible use later

    // Start is called before the first frame update
    void Start()
    {
        int tempstatpool = 15;
        
        #region text line
        //Debug you have entered the dungeons message
        Debug.Log("WELCOME TO THE DUGEONS TRAVELER, WHAT AWAITS YOU INSIDE IS EXPERIENCE AND LOOT BEYOND YOUR DREAMS." +
            " HOWEVER BE WEARY WITH GREAT GREED COMES GREAT DEMISE, " +
            "THE FURHTER YOU TRAVEL THE DARK YOUR NIGHTMARES WILL BECOME");
        //Debug out current player lvl
        Debug.Log("Current lvl: " + currentLevel);
        //Debug out player health
        Debug.Log("Health: " + currentHealth);
        //Debug out player xp
        Debug.Log("XP: " + currentPlayerXp);
        //Debug an enemy has spawned (what entity) and its health value.
        Debug.Log("A clattering sound approachs from the shadows, you face a withered skeleton.");
        //Skelton level
        enemyLevelLow = Random.Range(0, 6);
        Debug.Log("Skeleton LvL: " + enemyLevelLow);
        // Debug out skeleton health
        Debug.Log("Withered skeleton health: " + skeletonHealth);
        #endregion
        
        #region Character Stat generator
        //calculate random number generated for each stat from statpool
        attack = Random.Range(0, statpool + 1);
        statpool -= attack;

        defense = Random.Range(0, statpool);
        statpool -= defense;

        luck = Random.Range(0, statpool);
        statpool -= luck;

        Debug.Log("Your Attack lvl is: " + attack + ", your Defense lvl is: " + defense + ", Your Luck lvl is: " + luck); //Debug out players stats
        
        // Value of player over power
        playerPower = (attack + defense + luck) / 3;

        Debug.Log("The power within you is: " + playerPower);

        #endregion

        #region Skeleton Stat Generator
        //create skeleton statpool and assign stats to skeleton
        int skeletonStats = 15;

        int skeletonAttack = Random.Range(0, skeletonStats + 1);
        skeletonStats -= skeletonAttack;

        int skeletonDefense = Random.Range(0, skeletonStats);
        skeletonStats -= skeletonDefense;

        int skeletonLuck = Random.Range(0, skeletonStats);
        skeletonStats -= skeletonLuck;

        // Debug Skeleton stats
        Debug.Log("Skeleton stats are attack:" + skeletonAttack + ", Defense: " + skeletonDefense + ", Luck: " + skeletonLuck);

        // add all stat together than / by 3 to workout damage for both player and enemy
        enemyPower = (skeletonAttack + skeletonDefense + skeletonLuck) / 3;
        Debug.Log("Skeletons power level is: " + enemyPower);
        #endregion

        #region Deciding attack
        // compare damage from both entities to work out who hits and who misses
        float deciderPower = 0;
        deciderPower = (playerPower/enemyPower) * 100;

        if (deciderPower > 50)
        {
            Debug.Log("You have hit the enemy with a mighty swing, you have damaged the skeleton: " + playerPower + "DMG");
        }
        else if (deciderPower < 49)
        {
            Debug.Log("You have been slashed by the skeletons decaying hand, you have taken: " + enemyPower + "DMG");
        }
        else
        {
            Debug.Log("You both missed");
        }
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
       

    }
}