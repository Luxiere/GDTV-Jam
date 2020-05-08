using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkills : MonoBehaviour
{
    public GameObject projectile;
    public float defaultSpeed = 5f;
    public float defaultProjectileSpawnDistance = 1f;

    private IEnumerator Barrage(int projectileAmount, float fireRate)
    {
        for(int i = 0; i < projectileAmount; i++)
        {
            SpawnBullet(new Vector2(0, -1), defaultSpeed);
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void CircularShot(int projectileAmount)
    {
        for(int i = 0; i < projectileAmount; i++)
        {
            SpawnBullet(i * 360 / projectileAmount);
        }
    }

    private void SpawnBullet(float degree)
    {
        SpawnBullet(degree, defaultSpeed, defaultProjectileSpawnDistance);
    }

    private void SpawnBullet(float degree, float speed, float radius)
    {
        var instance = CircularSpawn(projectile, transform.position, degree, radius);
        instance.GetComponent<Projectile>().speed = speed;
        RewindObjectTracker.instance.AddRewindObject(instance.GetComponent<Projectile>());
    }

    private void SpawnBullet(Vector2 origin, float speed)
    {
        var instance = Instantiate(projectile, origin, Quaternion.Euler(0f, 0f, Mathf.Acos(Vector2.Dot(origin - (Vector2) transform.position, Vector2.right) / (origin - (Vector2) transform.position).magnitude)));
        instance.transform.up = origin - (Vector2)transform.position;
        instance.GetComponent<Projectile>().speed = speed;
        RewindObjectTracker.instance.AddRewindObject(instance.GetComponent<Projectile>());
    }

    private GameObject CircularSpawn(GameObject obj, Vector2 origin, float degree, float radius)
    {
        return Instantiate(obj, new Vector2(origin.x + radius * Mathf.Cos(degree * Mathf.Deg2Rad), origin.y + radius * Mathf.Sin(degree * Mathf.Deg2Rad)), Quaternion.Euler(0f, 0f, degree));
    }
}
