using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int maxHP = 100;
    private int hp;
    private bool cardkey;
    private int bulletCount;

    public void SetInitialValues(int hp, int bulletCount)
    {
        this.hp = hp;
        this.bulletCount = bulletCount;
    }
}
