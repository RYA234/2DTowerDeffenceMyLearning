using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    private Waypoint Waypoint => target as Waypoint;
    private void OnSceneGUI()
    {
        
        Handles.color = Color.red;
        for (int i = 0; i < Waypoint.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();
            
            // シーンのGUI上の座標
            // 例えば、Waypoint.Point[i]= new Vector3(0,0,0)だとすると、点が原点に密集し変更できない
            Vector3 currentWaypointPoint = Waypoint.Points[i];
            Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypointPoint,
                Quaternion.identity, 0.7f,new Vector3(0.3f,0.3f, 0.3f), Handles.SphereHandleCap);
            
            if (EditorGUI.EndChangeCheck())
            {
                // インスペクター上のベクトルの座標
                Waypoint.Points[i] = newWaypointPoint;
            }
        }
    }
}
