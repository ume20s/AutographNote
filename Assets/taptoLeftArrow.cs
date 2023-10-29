using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class taptoLeftArrow : MonoBehaviour
{
    // ゲームオブジェクト
    GameObject background;                          // 背景パネル

    // 背景パネルのスプライトレンダラーコンポーネント
    SpriteRenderer spriteRenderer;

    // 背景スプライト
    public Sprite[] backgroundSprite = new Sprite[3];

    // Start is called before the first frame update
    void Start()
    {
        // ゲームオブジェクトの取得
        background = GameObject.Find("background");
        
    }

    // タップしたら
    public void onClick()
    {
        // 背景番号を１減
        dt.backgorundColor--;
        if(dt.backgorundColor < 0) dt.backgorundColor = 2;

        // 背景の更新
        spriteRenderer = background.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = backgroundSprite[dt.backgorundColor];
    }
}
