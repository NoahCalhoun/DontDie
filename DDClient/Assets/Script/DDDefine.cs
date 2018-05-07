using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum DDMoveDirection
{
    Neutral = -1,
    Up = 0,
    UpRight = 45,
    Right = 90,
    DownRight = 135,
    Down = 180,
    DownLeft = 225,
    Left = 270,
    UpLeft = 325,
}

public enum DDUnitType
{
    None = -1,
    Player,
    NPC,
    Monster,
    Boss
}

public static class DDDefine
{
    const float Root2 = 1.414213562373095f;
}
