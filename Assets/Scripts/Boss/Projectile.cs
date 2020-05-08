using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, ITrackable
{
    public Transform[] waypoints = null;
    public float speed;

    private void Update()
    {
        if(!RewindObjectTracker.isRewinding)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
