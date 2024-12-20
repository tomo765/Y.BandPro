using System.Collections;
using System.Collections.Generic;


//GameLoop 内の処理は外側で UniTask を使う場合を想定して行動に関する処理ごとに分ける。
public class GameLoop
{
    private PlayerIndex[] m_TurnList;

    private LinkedList<YokaiInfo> m_Rarity1Pool = new LinkedList<YokaiInfo>();
    private LinkedList<YokaiInfo> m_Rarity2Pool = new LinkedList<YokaiInfo>();
    private LinkedList<YokaiInfo> m_Rarity3Pool = new LinkedList<YokaiInfo>();

    private int m_CurrentWeek = 1;
    private int m_CurrentPlayer = 0;

    public LinkedList<YokaiInfo> Rarity1Pool => m_Rarity1Pool;
    public LinkedList<YokaiInfo> Rarity2Pool => m_Rarity2Pool;
    public LinkedList<YokaiInfo> Rarity3Pool => m_Rarity3Pool;
    public int CurrentWeek => m_CurrentWeek;

    /// <summary> カードの山札を初期化する </summary>
    private void SetCardPools()
    {

    }
    // すべてのプレイヤーがサイコロを振る場合はこの中で初期化せず引数から順番を取得する
    private void SetPlayerTurn(int playerCount)
    {
        m_TurnList = new PlayerIndex[playerCount];

    }


    /// <summary> 順番決め + 星1の手札を順番事に決める </summary>
    public void Initialize(int playerCount)
    {
        SetCardPools();
        SetPlayerTurn(playerCount);
    }

    /// <summary> 通常ターン開始 </summary>
    public void PlayPrepare(PlayerManager player)
    {

    }

    /// <summary> 中間公演 </summary>
    public void PlayInterimPerformance(PlayerManager player)
    {

    }

    /// <summary> 最終公演 </summary>
    public void PlayLastPerformance(PlayerManager player)
    {

    }

    /// <summary> プレイヤーの行動終了後にするターンの更新処理 </summary>
    public void UpdateTurn()
    {
        if (m_CurrentPlayer < m_TurnList.Length) { m_CurrentPlayer++; }
        else { m_CurrentWeek++; }
    }
}
