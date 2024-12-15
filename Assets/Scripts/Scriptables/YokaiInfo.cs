using UnityEngine;

[CreateAssetMenu(fileName = "YokaiInfo", menuName = "Scriptables/Create Yokai Infomation")]
public class YokaiInfo : ScriptableObject
{
    [Header("絵")]
#if UNITY_EDITOR
    [SpritePreview]
#endif
    [SerializeField] private Sprite m_StandingSprite;

#if UNITY_EDITOR
    [SpritePreview]
#endif
    [SerializeField] private Sprite m_PixelSprite;


    [Header("設定値")]
    [SerializeField, Range(1, 3)] private int m_Rarity;
    [SerializeField] private GenreType m_GenreType;
    [SerializeField] private InstrumentType m_InstrumentType;
    [SerializeField] private Instruments m_Cost;
    [SerializeField] private Instruments m_Discount;
    [SerializeField] private PerformanceStatus m_PerformanceStatus;

    /// <summary> キャラの立ち絵 </summary>
    public Sprite StandingSprite => m_StandingSprite;
    /// <summary> キャラのドット絵 </summary>
    public Sprite PixelSprite => m_PixelSprite;


    /// <summary> レア度 </summary>
    public int Rarity => m_Rarity;
    /// <summary> 演奏のジャンル </summary>
    public GenreType GenreType => m_GenreType;
    /// <summary> 演奏楽器の種類 </summary>
    public InstrumentType InstrumentType => m_InstrumentType;
    /// <summary> 採用に必要なコスト </summary>
    public Instruments Cost => m_Cost;
    /// <summary> 新たに採用をするときの割引の量 </summary>
    public Instruments Discount => m_Discount;
    /// <summary> 演奏ステータス </summary>
    public PerformanceStatus PerformanceStatus => m_PerformanceStatus;

#if UNITY_EDITOR
    /// <summary> デバッグ用 </summary>
    public YokaiInfo(int rarity, GenreType musicType, InstrumentType instrumentType, Instruments cost, Instruments discount, PerformanceStatus status)
    {
        m_Rarity = rarity;
        m_GenreType = musicType;
        m_InstrumentType = instrumentType;
        m_Cost = cost;
        m_Discount = discount;
        m_PerformanceStatus = status;
    }
#endif
}