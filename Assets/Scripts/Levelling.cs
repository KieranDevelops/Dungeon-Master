using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelling : MonoBehaviour
{
    //Create variables for Player and enemy
    //These variables should be attack, defense and luck
    //Create a health, level, Xp and Xp threhold
    //
    
    public string characterName = "Paladin Raphael";//create a player name
    public int currentLevel = 1;//create a current lvl
    public float currentHealth = 15f;//create health
    public int attack = 0; //create an attack int
    public int defense = 0;//create a deffense int
    public int luck = 0;//create a luck int
    public int currentPlayerXp = 0;//player current exp
    public int xpthreshold = 50;//exp threshold
    public int statpool = 15;//create a stat pool
    public int playerPowerLevel = 0; // Players overall power 

    public float skeletonHealth = 10f;//create Skeleton hp
    public int skeletonAttack = 0;
    public int skeletonDefense = 0;
    public int skeletonLuck = 0;
    public int enemyLevelLow = 0;// Levelling for enemy entity
    public int enemyPowerLevel = 0;
    //Potential for higher levelling enemies

    public float attackMultiplier = 125.25f;//A value used to multiply the characters attack value on level up

    // Start is called before the first frame update
    void Start()
    {
        
        #region Welcome line
        
        Debug.Log("WELCOME TO THE DUGEONS TRAVELER, WHAT AWAITS YOU INSIDE IS EXPERIENCE AND LOOT BEYOND YOUR DREAMS." +
            " HOWEVER BE WEARY WITH GREAT GREED COMES GREAT DEMISE, " +
            "THE FURHTER YOU TRAVEL THE DARK YOUR NIGHTMARES WILL BECOME" + "PRESS TAB TO CONTINUE");//Debug you have entered the dungeons message

        #endregion
        
        #region Character Stat generator
        //calculate random number generated for each stat from statpool
        attack = Random.Range(0, statpool + 1);
        statpool -= attack;

        defense = Random.Range(0, statpool);
        statpool -= defense;

        luck = Random.Range(0, statpool);
        statpool -= luck;

        //Create a power level for player
        //This should be attack + def + luck 
        //Then divding the total by 3 for each catagory
        playerPowerLevel = (attack + defense + luck) / 3; // Value of player over power

        #endregion

        #region Skeleton Stat Generator

        //create skeleton statpool and assign stats to skeleton
        // these should consist of attack, strength and luck
        //Generate a random level for the skeleton between 1-5

        enemyLevelLow = Random.Range(0, 6);//Skelton level
        int skeletonStats = 15;

        skeletonAttack = Random.Range(0, skeletonStats + 1);
        skeletonStats -= skeletonAttack;

        skeletonDefense = Random.Range(0, skeletonStats);
        skeletonStats -= skeletonDefense;

        skeletonLuck = Random.Range(0, skeletonStats);
        skeletonStats -= skeletonLuck;

        //Create a power level for enemy 
        //This should be skeletonAttack + skeletonDef + skeletonLuck 
        //Then divding the total by 3 for each catagory
        enemyPowerLevel = (skeletonAttack + skeletonDefense + skeletonLuck) / 3; // add all stat together than / by 3 
        #endregion

        
    }

    // Update is called once per frame
    void Update()
    {
        #region Deciding attack
        // compare damage from both entities to work out who hits and who misses
        int deciderPower = (playerPowerLevel / enemyPowerLevel) * 100;

        //Has a skeleton spawned
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("A clattering sound approachs from the shadows, you face a skeleton." + "Press E to attack");//Debug an enemy has spawned (what entity) and its health value.
        }
         
        bool isDead = false;

        if(skeletonHealth <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("The Skeleton has been defeated, Spawn New Skeleton");
            
        }
        else if(currentHealth <=0 && !isDead)
        {
            isDead = true;
            Debug.Log("You were not mighty enough restart dungeon");
        }

        

        //has the player pressed space bar
        if (Input.GetKeyDown(KeyCode.E) && skeletonHealth >= 0)
        {

            //yes they have
            //compare two levels
            //print which player has won, how muchg damage they took
            int maxPower = 10;
            playerPowerLevel = Random.Range(playerPowerLevel, maxPower);
            enemyPowerLevel = Random.Range(enemyPowerLevel,maxPower);

            if (playerPowerLevel > enemyPowerLevel)
            {
                Debug.Log("You have hit the skeleton for: " + playerPowerLevel + "DMG");
                skeletonHealth -= playerPowerLevel;
                Debug.Log("Skeleton Health is: " + skeletonHealth);
            }
            else if (enemyPowerLevel > playerPowerLevel)
            {
                Debug.Log("You have been slashed by the cold lifeless hand of the skeleton you have taken: " + enemyPowerLevel + "DMG");
                currentHealth -= enemyPowerLevel;
                Debug.Log("Your health is now: " + currentHealth);
            }
            else //if(playerPowerLevel < 1  && enemyPowerLevel < 1)
            {  
                Debug.Log("You both have missed each other completely");
            }
            

        
        }
        #endregion



    }
}