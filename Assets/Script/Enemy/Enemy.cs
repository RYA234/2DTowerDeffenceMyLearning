using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Waypoint waypoint;
    public Vector3 CurrentPointPosition => waypoint.GetWaypointPosition(_currentWaypointIndex);
    private int _currentWaypointIndex;

    private void Start()
    {
        _currentWaypointIndex = 0;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 currentPosition = waypoint.GetWaypointPosition(_currentWaypointIndex);
        transform.position = Vector3.MoveTowards(transform.position, currentPosition, moveSpeed * Time.deltaTime);
    }
}