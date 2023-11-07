using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class taptoReset : MonoBehaviour
{
    public RawImage AGImage;                // RAWイメージ
    private Texture2D AGTexture;            // テクスチャ２Ｄ
    Color bgColor;                          // 背景色
    int rectWidth, rectHeight;              // 描画領域のサイズ

    // Start is called before the first frame update
    void Start()
    {
        // 背景の色を取得
        ColorUtility.TryParseHtmlString(dt.backgroundColorSample[dt.backgorundColor], out bgColor);

        // 描画領域の確保
        var rect = AGImage.gameObject.GetComponent<RectTransform>().rect;
        rectWidth = (int)rect.width;
        rectHeight = (int)rect.height;
        AGTexture = new Texture2D(rectWidth, rectHeight, TextureFormat.RGBA32, false);
        AGImage.texture = AGTexture;
    }

    // タップしたら
    public void onClick()
    {
        for(int w = 0; w < rectWidth; w++) {
            for (int h = 0; h < rectHeight; h++) {
                AGTexture.SetPixel(w, h, bgColor);
            }
        }
        AGTexture.Apply();
    }
}
