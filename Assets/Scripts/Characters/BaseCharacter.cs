using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseCharacter
{
    public string Name { get; set; }

    private CharacterAges characterAge;

    public CharacterAges CharacterAge 
    {
        get { return this.characterAge; }
        set
        {
            this.characterAge = value;

            //Change Stats when Age is changed

        }
    }

    private int level;

    //Get and set level
    public int Level 
    {
        get { return this.level;}
        set 
        { 
            this.level = value; 

            //Change Stats when leveling up
        
        }
    }
    public BaseCharacterClass CharacterClass { get; set; }


    //Stats

    private int health;
    public int Health
    {
        get { return this.health; }
        set
        {
            this.health = value;

            if (health <= 0)
            {
                //Die();
                health = 0;
            }

        }
    }

    public int Strenght { get; set; }

    public int Range { get; set; }

    public int Stamina { get; set; }

    public int Speed { get; set; }

    public int Intellect { get; set; }

    public int Wisdom { get; set; }
}
