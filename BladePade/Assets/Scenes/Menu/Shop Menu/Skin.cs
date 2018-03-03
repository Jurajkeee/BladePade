using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin
{
    public Sprite SkinPrev;
    public int gold;
    public int diamonds;
    public Skin(Sprite SkinPrev,int gold,int diamonds)
    {
        this.SkinPrev = SkinPrev;
        this.gold = gold;
        this.diamonds = diamonds;
    }
}
