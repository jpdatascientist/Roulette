using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RouletteController : MonoBehaviour
{
    float rouletteSpeed = 0;
    bool isRouletteStop = true;
    bool isDecelerating = false;
    public GameObject textElement1;
    public GameObject textElement2;
    public GameObject textElement3;

    // ScoreManagerクラスをを参照する
    public ScoreManager scoreManager ;

    // Start is called before the first frame update
    void Start()
    {

        // ①フレームレートの設定をする
        Application.targetFrameRate = 30;
        textElement1.SetActive(false);
        textElement2.SetActive(false);
        textElement3.SetActive(false);

     }

    // Update is called once per 毎秒frame FrameRateの数だけ実行
    void Update()
    {

        //　floatのZrotationを宣言して、Z軸の値を取得
        //  transform.localEulerAngles.zにて取得可能であり、0~360度の角度に自動補正してくれる
        float zrotation = transform.localEulerAngles.z;

        if (Input.GetMouseButtonDown(0))
        {
            // ルーレットが止まっていれば
            if (isRouletteStop == true)
            {
                rouletteSpeed = 10;
                isRouletteStop = false;
                // scoreManagaerクラスのテキストを非表示
                scoreManager.scoreText.gameObject.SetActive(false);
                textElement1.SetActive(false);
                textElement2.SetActive(false);
                textElement3.SetActive(false);
            }

            // ルーレットが止まっていなければ
            else if (isRouletteStop == false)
            {
                isDecelerating = true;
            }
        }
        // rouletteSppedの値でルーレットを回転させる　毎秒６０回実行
        transform.Rotate(0, 0, rouletteSpeed);

        // スピード落とす
        if (isDecelerating == true)
        {
            rouletteSpeed *= 0.95f;

            // スピードがこれ以下になれば、ルーレットを止める
            if (rouletteSpeed <= 0.01)
            {
                rouletteSpeed = 0;
            }
            if (rouletteSpeed == 0)
            {
                isRouletteStop = true;
                isDecelerating = false;

                // ルーレットの角度を取得して、得点を決定
                int addScore = GetScoreFromRotation(zrotation);
                // スコアマネージャーにスコアを渡す
                scoreManager.UpdateScore(addScore);
            }
        }


    }

    // 引数をこのクラスzrotationにしているのでこのクラスに記入する・・・？
    private int GetScoreFromRotation(float rotation)
    {
        if (0 <= rotation && rotation <= 48.69f)
        {
            textElement1.SetActive(true);
            return 10;
        }
        else if (308.78f <= rotation && rotation <= 360.0f)
        {
            textElement1.SetActive(true);
            return 10;
        }

        else if (169.30f <= rotation && rotation <= 188.73f)
        {
            textElement3.SetActive(true);
            return 50;
        }

        else if (188.73f < rotation && rotation < 308.78f)
        {
            textElement2.SetActive(true);
            return -10;

        }
        else if (48.69f < rotation && rotation < 169.30f)
        {
            textElement2.SetActive(true);
            return -10;
        }
        else
        {
            return 0;
        }
    }



}










