using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawingDirector : MonoBehaviour
{
    [SerializeField]
    private RawImage AGImage = null;        // RAWイメージ
    private Texture2D AGTexture = null;     // テクスチャ２Ｄ
    InputField inputfieldAGName;            // インプットフィールド


    // Start is called before the first frame update
    void Start()
    {
        // 描画領域の確保
        var rect = AGImage.gameObject.GetComponent<RectTransform>().rect;
        AGTexture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGBA32, false);
        SetBackgroundColor((int)rect.width, (int)rect.height);

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

    void SetBackgroundColor(int width, int height)
    {
        // カラーコードをColor型変数に変換
        Color backgroundcolor;
        ColorUtility.TryParseHtmlString(dt.backgroundColorSample[dt.backgorundColor], out backgroundcolor);

        for(int w = 0; w < width; w++) {
            for (int h = 0; h < height; h++) {
                AGTexture.SetPixel(w, h, backgroundcolor);
            }
        }
        AGImage.color = backgroundcolor;
        AGTexture.Apply();
    }
}
