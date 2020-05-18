using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralProjectile : Projectile, ITrackable
{
    public float radius;

    private float sequence = 0;
    private Vector2 startPos = Vector2.zero;

    private float c;
    private float s;

    private void Start()
    {
        startPos = transform.position;
        c = Mathf.Cos(theta * Mathf.Deg2Rad);
        s = Mathf.Sin(theta * Mathf.Deg2Rad);
    }

    void Update()
    {

        sequence -= Time.deltaTime;
        Vector2 spiral = new Vector2(sequence * speed * Mathf.Sin(sequence), sequence * speed * Mathf.Cos(sequence));
        transform.position = new Vector2(spiral.x * c - spiral.y * s, spiral.x * s + spiral.y * c) + startPos;
    }
}
