using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMageClass : BaseCharacterClass
{
   public BaseMageClass()
    {
        ClassName = "Mage";
        Health = Random.Range(12, 18);
        Strenght = Random.Range(4, 8);
        Range = Random.Range(3,5);
        Stamina = Random.Range(4, 6);
        Speed = Random.Range(4, 8);
        Intellect = Random.Range(6, 10);
        Wisdom = Random.Range(8, 12);
    }
}
