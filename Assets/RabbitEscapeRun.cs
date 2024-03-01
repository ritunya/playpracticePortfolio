using System.Collections;
using System.Collections.Generic;
using OVR;
using UnityEngine;

public class RabbitEscapeRun : MonoBehaviour
{
    private Animator anim;  //Animatorをanimという変数で定義する

    // Start is called before the first frame update
    void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
        // 座標を取得
        Vector3 pos = myTransform.position;
        Quaternion myRotation = transform.rotation;

        // "rabbit_escape"パラメータがtrueの場合に処理を実行
        if (anim.GetBool("rabbit_escape"))
        {
            // ここにrabbit_escapeがtrueの場合に実行したい処理を書く
            Debug.Log("rabbit_escape is true!");



            //pos.x += 0.01f;    // x座標へ0.01加算
            //pos.y += 0.01f;    // y座標へ0.01加算
            pos.z += 0.01f;    // z座標へ0.01加算

            myTransform.position = pos;  // 座標を設定
        }
    }

    //// 当たった時に呼ばれる関数　衝突開始
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Look")
        {

            if (Time.timeSinceLevelLoad > 10.0f)
            {
                Debug.Log("pyon"); // ログを表示する

                transform.Rotate(0f, 150f, 0f);  // y軸を100°回転

                //Bool型のパラメーターをTrueにする
                anim.SetBool("rabbit_escape", true);
            }
        }
    }
    //// 他のオブジェクトとのすり抜け中
    //void OnCollitionStay(Collider other)
    //{
    //    // 処理
    //    Debug.Log("pyon"); // ログを表示する

    //    //Bool型のパラメーターをTrueにする
    //    anim.SetBool("rab_running", true);
    //}
}
