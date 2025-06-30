using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormatNumbers : MonoBehaviour
{
    #region format coins DOUBLE
    public static string FormatPoints(double gold)
    {
        return gold switch
        {
            >= 1E+90 => (gold / 1E+72).ToString("0.##") + "nvt",
            >= 1E+87 => (gold / 1E+72).ToString("0.##") + "ovt",
            >= 1E+84 => (gold / 1E+72).ToString("0.##") + "stt",
            >= 1E+81 => (gold / 1E+72).ToString("0.##") + "svt",
            >= 1E+78 => (gold / 1E+72).ToString("0.##") + "qvt",
            >= 1E+75 => (gold / 1E+72).ToString("0.##") + "qtv",
            >= 1E+72 => (gold / 1E+72).ToString("0.##") + "tt",
            >= 1E+69 => (gold / 1E+69).ToString("0.##") + "dt",
            >= 1E+66 => (gold / 1E+66).ToString("0.##") + "ut",
            >= 1E+63 => (gold / 1E+63).ToString("0.##") + "vt",
            >= 1E+60 => (gold / 1E+60).ToString("0.##") + "nd",
            >= 1E+57 => (gold / 1E+57).ToString("0.##") + "od",
            >= 1E+54 => (gold / 1E+54).ToString("0.##") + "sp",
            >= 1E+51 => (gold / 1E+51).ToString("0.##") + "sc",
            >= 1E+48 => (gold / 1E+48).ToString("0.##") + "qd",
            >= 1E+45 => (gold / 1E+45).ToString("0.##") + "qtc",
            >= 1E+42 => (gold / 1E+42).ToString("0.##") + "td",
            >= 1E+39 => (gold / 1E+39).ToString("0.##") + "dd",
            >= 1E+36 => (gold / 1E+36).ToString("0.##") + "ud",
            >= 1E+33 => (gold / 1E+33).ToString("0.##") + "d",
            >= 1E+30 => (gold / 1E+30).ToString("0.##") + "n",
            >= 1E+27 => (gold / 1E+27).ToString("0.##") + "o",
            >= 1E+24 => (gold / 1E+24).ToString("0.##") + "sp",
            >= 1E+21 => (gold / 1E+21).ToString("0.##") + "sx",
            >= 1E+18 => (gold / 1E+18).ToString("0.##") + "qt",
            >= 1E+15 => (gold / 1E+15).ToString("0.##") + "qd",
            >= 1E+12 => (gold / 1E+12).ToString("0.##") + "t",
            >= 1E+09 => (gold / 1E+09).ToString("0.##") + "b",
            >= 1E+06 => (gold / 1E+06).ToString("0.##") + "m",
            _ => gold.ToString("0")
        };
    }
    #endregion
}
