using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDirector : MonoBehaviour
{
    // ゲームオブジェクト
    GameObject[] stylus = new GameObject[8];          // カラーチップポインタ

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

        // 余計なポインタを消しておく
        for(int i=1; i<8; i++) {
            stylus[i].SetActive(false);
        }

        // 名前を初期化
        dt.textAGName = "";

    }

    // インプットフィールドに入力された名前を格納
    public void GetAGName()
    {
        dt.textAGName = inputfieldAGName.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
