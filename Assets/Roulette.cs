using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    float rouletteSpeed = 0;
    bool isRouletteStop = true;
    bool isDecelerating = false;
    public GameObject textElement1;
    public GameObject textElement2;
    public GameObject textElement3;

    
    public float zrotation;
 

    // Start is called before the first frame update
    void Start()
    {

        // ①フレームレートの設定　どのくらいの速さで動くか
        Application.targetFrameRate = 30;
        textElement1.SetActive(false);
        textElement2.SetActive(false);
        textElement3.SetActive(false);


    }

    // Update is called once per 毎秒frame FrameRateの数だけ実行
    void Update()
    {
        //floatのZrotationを宣言して、Z軸の値を取得
        //transform.localEulerAngles.zにて取得可能であり、0~360度の角度に自動補正してくれる
        zrotation = transform.localEulerAngles.z;

        if (Input.GetMouseButtonDown(0))
        {
            // ルーレットが止まっていれば
            if (isRouletteStop == true)
            {
                rouletteSpeed = 10;
                isRouletteStop = false;
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

                // 関数にした方が見やすいかも
                if (0 <= zrotation && zrotation <= 49.13f)
                {
                    // 当たりのテキスト表示
                    textElement1.SetActive(true);
                    // 点数カウント
                    //score += 10;
                    //count += 1;
                }

                else if (308.78 <= zrotation && zrotation <= 360.0f)

                {
                    textElement1.SetActive(true);
                    //score += 10;
                    //count += 1;

                }

                else if (168.34f <= zrotation && zrotation <= 188.52f)
                {
                    textElement3.SetActive(true);
                    //score += 50;
                    //count += 1;

                }

                else if (188.52f < zrotation && zrotation < 308.78f)
                {
                    textElement2.SetActive(true);
                    //score -= 10;
                    //count += 1;

                }
                else if (49.13f < zrotation && zrotation < 168.34f)
                {
                    textElement2.SetActive(true);
                    //score -= 10;
                    //count += 1;


                }
            }
        }


    }



}
