using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SinProjectile : Projectile
{
    public float stepDistance = 0.5f;

    private float sequence;
    private Vector2 startPos = Vector2.zero;

    private float c;
    private float s;

    private void Start()
    {
        startPos = transform.position;
        c = Mathf.Cos(theta * Mathf.Deg2Rad);
        s = Mathf.Sin(theta * Mathf.Deg2Rad);
    }

    private void Update()
    {
        sequence += Time.deltaTime * speed;
        Vector2 sin = new Vector2(sequence, sequence * Mathf.Sin(sequence / stepDistance));
        transform.position =  new Vector2(sin.x * c - sin.y * s, sin.x * s + sin.y * c) + startPos;
    }
}
