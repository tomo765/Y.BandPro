using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static PlayerManager[] m_Players;


    public static void SetPlayers(PlayerManager[] players) => m_Players = players;
}
