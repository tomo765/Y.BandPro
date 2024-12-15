
[System.Serializable]
public struct PerformanceStatus  //FixMe : 変数名を適切なものにする
{
    [UnityEngine.SerializeField] private int m_Dice1;
    [UnityEngine.SerializeField] private int m_Dice2;
    [UnityEngine.SerializeField] private int m_Dice3;
    [UnityEngine.SerializeField] private int m_Dice4;

    public int Dice1 => m_Dice1;
    public int Dice2 => m_Dice2;
    public int Dice3 => m_Dice3;
    public int Dice4 => m_Dice4;

    public PerformanceStatus(int dice1, int dice2, int dice3, int dice4)
    {
        m_Dice1 = dice1;
        m_Dice2 = dice2;
        m_Dice3 = dice3;
        m_Dice4 = dice4;
    }

    public static PerformanceStatus operator +(PerformanceStatus a, PerformanceStatus b)
        => new PerformanceStatus(a.m_Dice1+b.m_Dice1, a.m_Dice2+b.m_Dice2, a.m_Dice3+b.Dice3, a.m_Dice4+b.Dice4);

    public static PerformanceStatus Empty => new PerformanceStatus(0, 0, 0, 0);

    public override string ToString() => "Dice1 : " + m_Dice1.ToString() + ", " +
                                         "Dice2 : " + m_Dice2.ToString() + ", " +
                                         "Dice3 : " + m_Dice3.ToString() + ", " + 
                                         "Dice4 : " + m_Dice4.ToString();
}
