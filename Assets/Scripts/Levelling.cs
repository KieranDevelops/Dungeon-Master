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
    public int currentLevel = 0;//create a current lvl
    public float currentHealth = 15f;//create health
    public int attack = 0; //create an attack int
    public int defense = 0;//create a deffense int
    public int luck = 0;//create a luck int
    public int currentPlayerXp = 0;//player current exp
    public int xpThreshold = 25;//exp threshold
    public int statpool = 15;//create a stat pool
    public int playerPowerLevel = 0; // Players overall power 

    public float skeletonHealth = 0f;//create Skeleton hp
    public int skeletonAttack = 0;
    public int skeletonDefense = 0;
    public int skeletonLuck = 0;
    public int skeletonLevel = 0;// Levelling for enemy entity
    public int enemyPowerLevel = 0;
    //Potential for higher levelling enemies

    public float attackMultiplier = 125.25f;//A value used to multiply the characters attack value on level up
    bool isDead = true;// asking if the enemy or the player is dead
    int xpGain = 0;

    public int reRoll = 10;
    // Start is called before the first frame update
    void Start()
    {
        
        #region Welcome line
        
        Debug.Log("WELCOME TO THE DUGEONS TRAVELER, WHAT AWAITS YOU INSIDE IS EXPERIENCE AND LOOT BEYOND YOUR DREAMS." +
            " HOWEVER BE WEARY WITH GREAT GREED COMES GREAT DEMISE, " +
            "THE FURHTER YOU TRAVEL THE DARK YOUR NIGHTMARES WILL BECOME" + "PRESS TAB TO CONTINUE");//Debug you have entered the dungeons message

        #endregion

        #region Character Stat generator
        currentLevel += 1;
        

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
        playerPowerLevel = (attack + defense + luck); // add all stat together

        #endregion

        #region Skeleton Stat Generator

        //create skeleton statpool and assign stats to skeleton
        // these should consist of attack, strength and luck
        //Generate a random level for the skeleton between 1-3
        //Ask what level the skeleton is and calculate the health according to its level

        skeletonLevel = Random.Range(1, 4);//Skelton level
        if(skeletonLevel == 1 )
        {
            skeletonHealth = skeletonLevel * 10;
        }
        else if(skeletonLevel == 2)
        {
            skeletonHealth = skeletonLevel * (float)7.5;
        }
        else
        {
            skeletonHealth = 20;
        }


        int skeletonStats = 10;

        skeletonAttack = Random.Range(0, skeletonStats + 1);
        skeletonStats -= skeletonAttack;

        skeletonDefense = Random.Range(0, skeletonStats);
        skeletonStats -= skeletonDefense;

        skeletonLuck = Random.Range(0, skeletonStats);
        skeletonStats -= skeletonLuck;

        //Create a power level for enemy 
        //This should be skeletonAttack + skeletonDef + skeletonLuck 
        //Then divding the total by 3 for each catagory
        enemyPowerLevel = (skeletonAttack + skeletonDefense + skeletonLuck); // add all stat together   
        #endregion


    }

    // Update is called once per frame
    void Update()
    {
        #region Deciding attack
        // compare damage from both entities to work out who hits and who misses
        // this will be used in the random range for each entity for attacking each other
        // this will be rolled when E is pressed
        float deciderPower = (playerPowerLevel * enemyPowerLevel) / 100;

        //Has a skeleton spawned
        //Ask what the skeletons level is and how much health it has and log it out to the console.
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("A clattering sound approachs from the shadows, you face a skeleton." + "Press E to attack");//Debug an enemy has spawned (what entity) and its health value.
            if(skeletonLevel == 1)//We are asking if the skeleton is level 1 and if so log out it is level 1 and has the assigned health value.
            {
                Debug.Log("Skeletonlvl: " + "1" + " Health: 10");
                
            }
            else if(skeletonLevel == 2)//We are asking if the skeleton is level 2 and if so log out it is level 2 and has the assigned health value.
            {
                Debug.Log("Skeleton lvl: " + "2" + " Health: 15");
               
            }
            else//We are asking if the skeleton is level 3 and if so log out it is level 3 and has the assigned health value.
            {
                Debug.Log("Skeletonlvl: " + "3" + " Health: 20");
            }
        }

        //has the skeleton or player died
        //yes they have
        //print out a death message and recieve a bonus on enemy death
        // xp recievd will be randomised between 5 and 50

        xpGain = Random.Range(5, 50);
        if(skeletonHealth <= 0 && isDead == true)
        {
            skeletonHealth = skeletonLevel;
            currentPlayerXp += xpGain;
            currentHealth = 15f;
            reRoll = 10;
            Debug.Log("The Skeleton has been defeated, you have recieved: " + xpGain + "XP");
            Debug.Log("To continue press 'TAB'");
            
            
        }
        else if(currentHealth <=0 && isDead == true)
        {
            currentHealth = 15f;
            reRoll = 10;
            Debug.Log("You were not mighty enough restart dungeon");
            
        }
        
        
        //has the player pressed space bar
        if (Input.GetKeyDown(KeyCode.E) && skeletonHealth >= 0)
        {

            //yes they have
            //compare two levels
            //print which player has won, how muchg damage they took

            playerPowerLevel = Random.Range(playerPowerLevel, (int)deciderPower + 1);
            enemyPowerLevel = Random.Range(enemyPowerLevel, (int)deciderPower + 1);


           
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
            else
            {  
                playerPowerLevel = Random.Range((int)1f, reRoll + 1);
                enemyPowerLevel = Random.Range((int)1f, reRoll + 1);
                Debug.Log("You both have missed each other completely");
                
            }

            

        }
        #endregion

        //can player level up? check Xp threshold
        //yes they can
        //press L to level up this will check if the Xp threshold is has been met and decide if you can level up or not.  
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (currentPlayerXp > xpThreshold)
            {
                currentLevel += 1;
                statpool *= currentLevel;

                playerPowerLevel = (playerPowerLevel * (int)(attackMultiplier / 100));
                Debug.Log("New Power recieved: " + playerPowerLevel);
                xpThreshold *= currentLevel;
                Debug.Log("You have Levelled up to: " + currentLevel);
            }
            else
            {
                Debug.Log("You do not have enough Xp for this!");
            }

        }


        if(currentLevel == 5)
        {
            Debug.Log("YOU MAY RETURN TO THE HEAVENS PALADIN RAPHAEL, AS YOU HAVE FOUND YOUR PURPOSE AND ATONED FOR YOUR SINS!, YOU HAVE BEEN AWARDED THE DUNGEON MASTERS TITLE");
            Debug.Log("Thank you for playing Dungeon master, it may be a bit broken however it can alwasy get better with time.");
        }


    }
    

}