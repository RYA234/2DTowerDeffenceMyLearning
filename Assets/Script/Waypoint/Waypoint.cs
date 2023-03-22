
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// 座標を定義しているクラス、オブジェクトにアタッチする
public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3[] points;
    public Vector3[] Points => points;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}