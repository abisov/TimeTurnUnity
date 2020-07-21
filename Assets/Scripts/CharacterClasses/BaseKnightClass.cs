using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKnightClass : BaseCharacterClass
{
    public BaseKnightClass()
    {
        ClassName = "Knight";
        Health = Random.Range(20, 30);
        Strenght = Random.Range(8, 15);
        Range = 1;
        Stamina = Random.Range(5, 10);
        Speed = Random.Range(4, 8);
        Intellect = Random.Range(3, 8);
        Wisdom = Random.Range(2, 5);
    }
}
