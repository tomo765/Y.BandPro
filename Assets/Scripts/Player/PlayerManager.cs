using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public readonly PlayerIndex Index;
    public readonly PlayerInputObserver Observer;
}

public enum PlayerIndex
{
    P1 = 1, 
    P2 = 2, 
    P3 = 3, 
    P4 = 4
}

