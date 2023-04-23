using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class WaypointPatrol : MonoBehaviour
{
    private NavMeshAgent _ghost;
    public List<Transform> waypoints;
    private int currentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        _ghost = GetComponent<NavMeshAgent>();

        _ghost.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
      if (_ghost.remainingDistance < _ghost.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex +1) % waypoints.Count;
            _ghost.SetDestination(waypoints[currentWaypointIndex].position);

        }   
    }
}
