using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, ITrackable
{
    public Transform[] waypoints = null;
    public float theta;
    public float speed;

    private int currentWaypoint = 0;

    private void Update()
    {
        if (RewindObjectTracker.isRewinding) return;
        if (waypoints.Length > 0)
        {
            if(Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.5)
            {
                currentWaypoint += 1;
                if (currentWaypoint >= waypoints.Length) Destroy(gameObject);
            }
            transform.up = transform.position - waypoints[currentWaypoint].position;
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);   
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
