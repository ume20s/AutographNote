using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDirector : MonoBehaviour
{
    // ゲームオブジェクト
    GameObject[] stylus = new GameObject[8];            // カラーチップポインタ
    GameObject textFilename;                            // ファイルネーム

    // インプットフィールド
    InputField inputfieldAGName;

    // Start is called before the first frame update
    void Start()
    {
        // ゲームオブジェクトの取得
        stylus[0] = GameObject.Find("stylus00");
        stylus[1] = GameObject.Find("stylus01");
        stylus[2] = GameObject.Find("stylus02");
        stylus[3] = GameObject.Find("stylus03");
        stylus[4] = GameObject.Find("stylus04");
        stylus[5] = GameObject.Find("stylus05");
        stylus[6] = GameObject.Find("stylus06");
        stylus[7] = GameObject.Find("stylus07");
    
        //InputFieldコンポーネントを取得
        inputfieldAGName = GameObject.Find("inputfieldAGName").GetComponent<InputField>();

        // 名前を初期化
        dt.textAGName = makeAGName();
        inputfieldAGName.text = dt.textAGName;

        // ペンの色を初期化
        dt.stylusColor = 0;

        // 背景番号の初期化
        dt.backgorundColor = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // カラーチップポインタの再描画
        for(int i=0; i<8; i++) {
            stylus[i].SetActive(false);
        }
        stylus[dt.stylusColor].SetActive(true);
    }


    // インプットフィールドに入力された名前を格納
    public void GetAGName()
    {
        dt.textAGName = inputfieldAGName.text;
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
