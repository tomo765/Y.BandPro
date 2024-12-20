using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static PlayerManager[] m_Players;
    private static BandGroup[] m_BandGroups;
    private static GameLoop m_GameLoop;


    private static void CreateBandGroups()
    {
        m_BandGroups = new BandGroup[m_Players.Length];
        for(int i = 0; i < m_Players.Length; i++)
        {
            m_BandGroups[i] = new BandGroup();
        }
    }
    private static void CreateGameLoop() => m_GameLoop = new GameLoop();

    public static void InitializeData()
    {
        CreateBandGroups();
        CreateGameLoop();
        m_GameLoop.Initialize(m_Players.Length);
    }
    public static void SetPlayers(PlayerManager[] players) => m_Players = players;

    public static PlayerManager GetPlayer(int i) => m_Players[i];
    public static BandGroup GetBandGroup(int i) => m_BandGroups[i];
}
