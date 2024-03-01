using UnityEngine;
using UnityEngine.XR;

public class HeadObject : MonoBehaviour
{
    public GameObject targetObject; // 連動させたい3Dオブジェクト
    public Animator animator;
    Quaternion headRotation;

    //HMDの位置座標格納用
    private Vector3 HMDPosition;
    //HMDの回転座標格納用（クォータニオン）
    private Quaternion HMDRotationQ;
    //HMDの回転座標格納用（オイラー角）
    private Vector3 HMDRotation;

    void Start()
    {
        animator = GetComponent<Animator>();
        targetObject = GetComponent<GameObject>();

    }

    void Update()
    {
        // Unityちゃんの頭の回転情報を取得
        //headRotation = animator.GetBoneTransform(HumanBodyBones.Head).rotation;

        // 目標の3Dオブジェクトのトランスフォームに頭の回転情報を適用
        //targetObject.transform.rotation = headRotation;

        //Head（ヘッドマウンドディスプレイ）の情報を一時保管-----------
        //位置座標を取得
        HMDPosition = InputTracking.GetLocalPosition(XRNode.Head);
        //回転座標をクォータニオンで値を受け取る
        HMDRotationQ = InputTracking.GetLocalRotation(XRNode.Head);
        //取得した値をクォータニオン → オイラー角に変換
        HMDRotation = HMDRotationQ.eulerAngles;

        Debug.Log("HMDP:" + HMDPosition.x + ", " + HMDPosition.y + ", " + HMDPosition.z + "\n" +
                    "HMDR:" + HMDRotation.x + ", " + HMDRotation.y + ", " + HMDRotation.z);

    }
}
