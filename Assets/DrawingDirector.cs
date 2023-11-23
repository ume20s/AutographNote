using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawingDirector : MonoBehaviour
{
    public RawImage AGImage;                // RAWイメージ
    public static Texture2D AGTexture;      // テクスチャ２Ｄ
    InputField inputfieldAGName;            // インプットフィールド
    Color penColor;                         // ペン色
    Color bgColor;                          // 背景色
    int rectWidth, rectHeight;              // 描画領域のサイズ
    Vector2 prePos;                         // 以前のタップ位置
    Vector2 nowPos;                         // 現在触っている位置

    // Start is called before the first frame update
    void Start()
    {
        // ペンと背景の色を取得
        ColorUtility.TryParseHtmlString(dt.stylusColorSample[dt.stylusColor], out penColor);
        ColorUtility.TryParseHtmlString(dt.backgroundColorSample[dt.backgorundColor], out bgColor);

        // 描画領域の確保
        var rect = AGImage.gameObject.GetComponent<RectTransform>().rect;
        rectWidth = (int)rect.width;
        rectHeight = (int)rect.height;
        AGTexture = new Texture2D(rectWidth, rectHeight, TextureFormat.RGBA32, false);
        AGImage.texture = AGTexture;

        SetBackgroundColor();

        //InputFieldコンポーネントを取得
        inputfieldAGName = GameObject.Find("inputfieldAGName").GetComponent<InputField>();

        // 名前を初期化
        if(dt.textAGName == "") {
            dt.textAGName = makeAGName();
        }
        inputfieldAGName.text = dt.textAGName;
    }

    // デフォルトサイン名の生成
    private string makeAGName()
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

    // ドラッグして描画
    public void OnDrag(BaseEventData e)
    {
        // ペンサイズ
        int r = 16;

        // タッチデータの取得
        PointerEventData _event = e as PointerEventData;

        // ドラッグ座標をテクスチャのローカル座標に変換
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            AGImage.gameObject.GetComponent<RectTransform>(), 
            _event.position, 
            Camera.main, 
            out nowPos);
        
        // 範囲内だったら描画
        int geta = r / 2;
        if(nowPos.x>-425+geta && nowPos.x<425-geta && nowPos.y>-600+geta && nowPos.y<600-geta) {
            var dir  = prePos - nowPos;
            var dist = (int)dir.magnitude;
            dir = dir.normalized;
            for(int d=0; d<dist; d++) {
                var p_pos = nowPos + dir * d;
                for (int h=0; h<r; h++) {
                    int y = (int)(p_pos.y + h - 600 - geta);
                    for(int w=0; w<r; ++w) {
                        int x = (int)(p_pos.x + w - 425 - geta);
                        AGTexture.SetPixel(x, y, penColor);
                    }
                }
            }
        }
        AGTexture.Apply();

        // 現在の座標をとっとく
        prePos = nowPos;
    }

    // タップして点を描画
    public void OnTap(BaseEventData e)
    {
        // ペンサイズ
        int r = 20;

        // タッチデータの取得
        PointerEventData _event = e as PointerEventData;

        // ドラッグ座標をテクスチャのローカル座標に変換
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            AGImage.gameObject.GetComponent<RectTransform>(), 
            _event.position, 
            Camera.main, 
            out nowPos);
        
        // 範囲内だったら描画
        int geta = r / 2;
        if(nowPos.x>-425+geta && nowPos.x<425-geta && nowPos.y>-600+geta && nowPos.y<600-geta) {
            for (int h=0; h<r; h++) {
                int y = (int)(nowPos.y + h - 600 - geta);
                for(int w=0; w<r; ++w) {
                    int x = (int)(nowPos.x + w - 425 - geta);
                    AGTexture.SetPixel(x, y, penColor);
                }
            }
        }
        AGTexture.Apply();

        // 現在の座標をとっとく
        prePos = nowPos;
    }

    // 背景色で全面を塗りつぶす
    public void SetBackgroundColor()
    {
        for(int w = 0; w < rectWidth; w++) {
            for (int h = 0; h < rectHeight; h++) {
                AGTexture.SetPixel(w, h, bgColor);
            }
        }
        AGTexture.Apply();
    }

    // インプットフィールドに入力された名前を格納
    public void GetAGName()
    {
        dt.textAGName = inputfieldAGName.text;
    }
}
