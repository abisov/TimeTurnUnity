using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass : MonoBehaviour
{
    //General Info
    private string className;
    

    //Character stats
   
    public string ClassName { get; set; }
    

    public int Health { get; set; }

    public int Strenght { get; set; }

    public int Range { get; set; }

    public int Stamina { get; set; }

    public int Speed { get; set; }

    public int Intellect { get; set; }

    public int Wisdom { get; set; }



}
