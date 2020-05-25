using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オキュラスクエスト用 transform.TranslateによるPlayerの移動方法
// カクツク原因はtime.deltaTimeであった！！
// 解決方法見つけるぞ

public class PlayerControllerSecond : MonoBehaviour
{
    Rigidbody rb;
    Transform tf;
    private float angleSpeed = 45.0f;
    private float moveSpeed = 2.25f;
    [SerializeField] GameObject moveTarget;
    // オキュラスクエストの入力値変数

    // float x, y;
    Vector3 move = Vector3.zero;


    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }
    void Update()
    {
    // 右スティック入力・操作 方向
        Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        // x = rightStick.x;
        // y = rightStick.y;
        // x と z 軸のみの変更
        // Vector3 direction = new Vector3( x , 0, y);
        Vector3 direction = new Vector3( rightStick.x , 0, rightStick.y);
        // move = moveSpeed * Time.deltaTime * (direction.x * moveTarget.transform.right.normalized + direction.y * moveTarget.transform.up.normalized + direction.z * moveTarget.transform.forward.normalized);
        move = (direction.x * moveTarget.transform.right.normalized + direction.y * moveTarget.transform.up.normalized + direction.z * moveTarget.transform.forward.normalized) / 10;
        // tf.Translate(move, Space.World);
        tf.Translate(move, Space.World);

        // 左スティック操作 角度
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3( 0, leftStick.x, 0);
        // transform.Rotate(angle * angleSpeed * Time.deltaTime);
        transform.Rotate(angle  / 10);
    }

    void FixedUpdate()
    {
        
    }
}
