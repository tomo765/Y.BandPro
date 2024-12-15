using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumExtension
{
    public static string ToJapanese(this PlayerIndex index)
    {
        return (index) switch
        {
            PlayerIndex.P1 => "プレイヤー1",
            PlayerIndex.P2 => "プレイヤー2",
            PlayerIndex.P3 => "プレイヤー3",
            PlayerIndex.P4 => "プレイヤー4",
            _ => ""
        };
    }

    public static string ToJapanese(this GenreType type)
    {
        return (type) switch
        {
            GenreType.Punk => "パンク",
            GenreType.Metal => "メタル",
            GenreType.Gothic => "ゴシック",
            GenreType.Disco => "ディスコ",
            GenreType.Western => "ウェスタン",
            GenreType.Jazz => "ジャズ",
            GenreType.Classic => "クラシック",
            _ => ""
        };
    }

    public static string ToJapanese(this InstrumentType type)
    {
        return type switch
        {
            InstrumentType.Wind => "管楽器",
            InstrumentType.Percussion => "打楽器",
            InstrumentType.Strings => "弦楽器",
            InstrumentType.Keyboard => "鍵盤楽器",
            InstrumentType.Gold => "金",
            _ => ""
        }; ;
    }
}
