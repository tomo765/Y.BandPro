using System.Collections;
using System.Collections.Generic;


public class GameLoop
{
    private LinkedList<PlayerManager> m_PlayerContainer = new LinkedList<PlayerManager>();

    private LinkedList<YokaiInfo> m_Rarity1Pool = new LinkedList<YokaiInfo>();
    private LinkedList<YokaiInfo> m_Rarity2Pool = new LinkedList<YokaiInfo>();
    private LinkedList<YokaiInfo> m_Rarity3Pool = new LinkedList<YokaiInfo>();

    private int m_CurrentWeek = 1;

    public LinkedList<PlayerManager> PlayerContainer => m_PlayerContainer;
    public LinkedList<YokaiInfo> Rarity1Pool => m_Rarity1Pool;
    public LinkedList<YokaiInfo> Rarity2Pool => m_Rarity2Pool;
    public LinkedList<YokaiInfo> Rarity3Pool => m_Rarity3Pool;
    public int CurrentWeek => m_CurrentWeek;


    public void PlayPrepare(PlayerManager player)
    {



        m_CurrentWeek++;
    }

    /// <summary> 中間講演 </summary>
    public void PlayInterimPerformance(PlayerManager player)
    {

    }

    /// <summary> 最終講演 </summary>
    public void PlayLastPerformance(PlayerManager player)
    {

    }
}
