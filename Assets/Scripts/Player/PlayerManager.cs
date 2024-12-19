using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public readonly PlayerIndex Index;
    public readonly PlayerInputObserver Observer;

    private PlayerManager() { }
    public PlayerManager(PlayerIndex index, PlayerInputObserver observer)
    {
        Index = index;
        Observer = observer;
    }

    public PlayerManager(int index, PlayerInputObserver observer)
    {
        Index = (PlayerIndex)index+1;
        Observer = observer;
    }
}

public enum PlayerIndex
{
    P1 = 1, 
    P2 = 2, 
    P3 = 3, 
    P4 = 4
}

