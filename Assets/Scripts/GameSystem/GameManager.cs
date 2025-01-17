using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameManager
{
    private static PlayerManager[] m_Players;
    private static GameLoop m_GameLoop;

    public static void InitializeGame()
    {
        m_GameLoop = new GameLoop();
        m_GameLoop.Initialize(m_Players.Select(player => player.Index).ToArray());
    }

    public static void UpdateCullentTurnPlayer()
    {
        m_GameLoop.FinishPlayerTurn();
        UISelector.Instance.SetSelectPlayer(m_Players.Where(player => player.Index == m_GameLoop.CullentTurnPlayerIndex).First().Observer);
    }

    public static void SetPlayers(PlayerManager[] players) => m_Players = players;
}
