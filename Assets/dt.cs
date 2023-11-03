using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dt : MonoBehaviour
{
    
    public static int stylusColor;          // 選択したペンの色
    public static int backgorundColor;      // 選択した背景の色    
    public static string textAGName;        // サインの名前

    // ペンの色
    public static readonly string[] stylusColorSample =
    {
        "#000000", 
        "#7F7F7F", 
        "#FFAEC9", 
        "#ED1C24", 
        "#FF7F27", 
        "#FFF200", 
        "#22B14C", 
        "#FFFFFF"
    };

    // 背景の色
    public static readonly string[] backgroundColorSample =
    {
        "#FFFFFF", 
        "#013400", 
        "#000000"
    };
}
