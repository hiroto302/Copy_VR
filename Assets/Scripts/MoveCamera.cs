using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    Transform Player = null;
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        transform.position = Player.position;
        transform.rotation = Player.rotation;
    }
}
