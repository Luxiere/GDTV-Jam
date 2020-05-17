using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralProjectile : Projectile, ITrackable
{
    public float radius;

    private float sequence = 0;
    private Vector2 startPos = Vector2.zero;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        sequence -= Time.deltaTime;
        Vector2 spiral = new Vector2(sequence * speed * Mathf.Sin(sequence), sequence * speed * Mathf.Cos(sequence));
        transform.position = new Vector2(spiral.x * Mathf.Cos(theta * Mathf.Deg2Rad) + spiral.y * Mathf.Sin(theta * Mathf.Deg2Rad),
            -spiral.x * Mathf.Sin(theta * Mathf.Deg2Rad) + spiral.y * Mathf.Cos(theta * Mathf.Deg2Rad)) + startPos;
    }
}
