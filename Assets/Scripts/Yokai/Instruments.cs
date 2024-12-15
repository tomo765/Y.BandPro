
using UnityEngine;

/// <summary> 楽器系のステータス </summary>
[System.Serializable]
public struct Instruments
{
    /// <summary> 弦楽器 </summary>
    public int Strings
    {
        get => m_Strings;
        set 
        { 
            if(value <= 0) { m_Strings = 0; }
            else { m_Strings = value; }
        }
    }
    [SerializeField] private int m_Strings;

    /// <summary> 打楽器 </summary>
    public int Percussion
    {
        get => m_Percussion;
        set
        {
            if (value <= 0) { m_Percussion = 0; }
            else { m_Percussion = value; }
        }
    }
    [SerializeField] private int m_Percussion;

    /// <summary> 管楽器 </summary>
    public int Wind
    {
        get => m_Wind;
        set
        {
            if (value <= 0) { m_Wind = 0; }
            else { m_Wind = value; }
        }
    }
    [SerializeField] private int m_Wind;

    /// <summary> 鍵盤楽器 </summary>
    public int Keyboard
    {
        get => m_Keyboard;
        set
        {
            if (value <= 0) { m_Keyboard = 0; }
            else { m_Keyboard = value; }
        }
    }
    [SerializeField] private int m_Keyboard;


    public void SetStatus(int strings, int percussion, int wind, int keyboard)
    {
        m_Strings = strings;
        m_Percussion = percussion;
        m_Wind = wind;
        m_Keyboard = keyboard;
    }

    public void AddStatus(int strings, int percussion, int wind, int keyboard)
    {
        m_Strings += strings;
        m_Percussion += percussion;
        m_Wind += wind;
        m_Keyboard += keyboard;
    }
    public void AddStatus(in Instruments status)  // in でインスタンス参照、読み取り専用にしてパフォーマンス向上、不正な数値を代入できないようにしたい。
    {
        m_Strings += status.m_Strings;
        m_Percussion += status.m_Percussion;
        m_Wind += status.m_Wind;
        m_Keyboard += status.m_Keyboard;
    }

    public Instruments(int strings, int percussion, int wind, int keyboard)
    {
        m_Strings = strings;
        m_Percussion = percussion;
        m_Wind = wind;
        m_Keyboard = keyboard;
    }



    public override string ToString()
        => "Strings : "     + m_Strings     + ", " +
           "Percussion : " + m_Percussion + ", " +
           "Wind : "       + m_Wind       + ", " +
           "Keyboard : "   + m_Keyboard   ;
}