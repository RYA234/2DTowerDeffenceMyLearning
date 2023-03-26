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
        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }

    private void Move()
    {
        Vector3 currentPosition = waypoint.GetWaypointPosition(_currentWaypointIndex);
        transform.position = Vector3.MoveTowards(transform.position, currentPosition, moveSpeed * Time.deltaTime);
    }
    
    private bool CurrentPointPositionReached()
    {
        return Vector3.Distance(transform.position, CurrentPointPosition) < 0.1f;
    }

    private void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = waypoint.Points.Length - 1;
        if (_currentWaypointIndex < lastWaypointIndex)
        {
            _currentWaypointIndex++;
        }
        else
        {
            ReturnEnemyToPool();
            
        }
    }
    private void ReturnEnemyToPool()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}