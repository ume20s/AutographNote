using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawingDirector : MonoBehaviour
{
    // インプットフィールド
    InputField inputfieldAGName;

    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        inputfieldAGName = GameObject.Find("inputfieldAGName").GetComponent<InputField>();

        // 名前を初期化
        if(dt.textAGName == "") {
            dt.textAGName = makeAGName();
        }
        inputfieldAGName.text = dt.textAGName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string makeAGName()
    {
        string newAGName;
        newAGName = DateTime.Now.Year.ToString();
        newAGName += DateTime.Now.Month.ToString("D2");
        newAGName += DateTime.Now.Day.ToString("D2");
        newAGName += "_";
        newAGName += DateTime.Now.Hour.ToString("D2");
        newAGName += DateTime.Now.Minute.ToString("D2");
        newAGName += DateTime.Now.Second.ToString("D2");

        return newAGName;
    }

}
