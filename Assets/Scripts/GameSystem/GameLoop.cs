using System.Collections;
using System.Collections.Generic;


public class GameLoop
{
    /// <summary> プレイヤーの操作する順番 </summary>
    private PlayerIndex[] m_PlayerTurn;
    /// <summary> 現在操作可能なプレイヤーのインデックス </summary>
    private int m_TurnCount = 0;

    private LinkedList<YokaiInfo> m_Rarity1Pool = new LinkedList<YokaiInfo>();
    private LinkedList<YokaiInfo> m_Rarity2Pool = new LinkedList<YokaiInfo>();
    private LinkedList<YokaiInfo> m_Rarity3Pool = new LinkedList<YokaiInfo>();

    private int m_CurrentWeek = 1;

    public PlayerIndex CullentTurnPlayerIndex => m_PlayerTurn[m_TurnCount];
    public int TurnCount => m_TurnCount;

    public LinkedList<YokaiInfo> Rarity1Pool => m_Rarity1Pool;
    public LinkedList<YokaiInfo> Rarity2Pool => m_Rarity2Pool;
    public LinkedList<YokaiInfo> Rarity3Pool => m_Rarity3Pool;
    public int CurrentWeek => m_CurrentWeek;


    private void UpdateTurn()
    {
        m_TurnCount++;
        if(m_TurnCount >= m_PlayerTurn.Length)
        {
            m_TurnCount = 0;
            m_CurrentWeek++;
        }
    }

    /// <summary> 順番決め + 星1の手札を順番事に決める </summary>
    public void Initialize(PlayerIndex[] playerTurn)
    {
        m_PlayerTurn = playerTurn;
    }

    public void PlayPrepare(PlayerManager player)
    {


        //m_CurrentWeek++;
    }

    /// <summary> 中間講演 </summary>
    public void PlayInterimPerformance(PlayerManager player)
    {

    }

    /// <summary> 最終講演 </summary>
    public void PlayLastPerformance(PlayerManager player)
    {

    }

    public void FinishPlayerTurn()
    {
        UpdateTurn();
    }
}
