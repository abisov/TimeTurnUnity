using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArcherClass : BaseCharacterClass
{
    public BaseArcherClass()
    {
        ClassName = "Archer";
        Health = Random.Range(12, 16);
        Strenght = Random.Range(6, 8);
        Range = Random.Range(6, 8);
        Stamina = Random.Range(3, 5);
        Speed = Random.Range(6, 10);
        Intellect = Random.Range(6, 10);
        Wisdom = Random.Range(6, 8);
    }
}
