
using System;
using System.Collections.Generic;

public class YokaiMember
{
    private YokaiInfo m_YokaiRare1;
    private YokaiInfo m_YokaiRare2;
    private YokaiInfo m_YokaiRare3;

    delegate ref YokaiInfo YokaiInfoDelegate(int val);
    private YokaiInfoDelegate GetYokaiInfoRef => (int val) =>
    {
        if(val == 1) { return ref m_YokaiRare1; }
        else if (val == 2) {  return ref m_YokaiRare2; }
        else  {  return ref m_YokaiRare3; }
    };

    public YokaiInfo YokaiRare1 => m_YokaiRare1;
    public YokaiInfo YokaiRare2 => m_YokaiRare2;
    public YokaiInfo YokaiRare3 => m_YokaiRare3;


    public InstrumentType InstrumentType => YokaiRare1.InstrumentType;
    public int Rarity => m_YokaiRare3?.Rarity ??
                         m_YokaiRare2?.Rarity ??
                         m_YokaiRare1.Rarity;
    public GenreType? GenreType => m_YokaiRare2?.GenreType;
    public Instruments Cost => m_YokaiRare3?.Cost ??   //m_YokaiRare3 が null の時は次
                               m_YokaiRare2?.Cost ??   //m_YokaiRare2 が null の時は次
                               m_YokaiRare1. Cost ;
    public Instruments Discount => m_YokaiRare3?.Discount ??  //m_YokaiRare3 が null の時は次
                                   m_YokaiRare2?.Discount ??  //m_YokaiRare2 が null の時は次
                                   m_YokaiRare1. Discount ;

    //m_YokaiRare2, m_YokaiRare3 がnull のときはそれぞれ右の値を使用する。
    public PerformanceStatus PerformanceStatus => 
                    m_YokaiRare1.PerformanceStatus +
                   (m_YokaiRare2?.PerformanceStatus ?? PerformanceStatus.Empty) +
                   (m_YokaiRare3?.PerformanceStatus ?? PerformanceStatus.Empty);

    public void AddYokaiInfo(YokaiInfo info) => GetYokaiInfoRef(info.Rarity) ??= info;
}