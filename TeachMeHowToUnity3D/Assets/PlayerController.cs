using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GunController))]
public class PlayerController : MonoBehaviour
{
    GunController gun;
    float nextShootTime;
    public float shootDelay = 1f;

    void Start()
    {
        gun = GetComponent<GunController>();
        nextShootTime = shootDelay + Time.time;
    }

    void FixedUpdate()
    {
        if (Time.time > nextShootTime) Shoot();
    }

    void Shoot()
    {
        Debug.Log("Shooting gun!");
        gun.MoveIntoPosition(transform.position);
        
        nextShootTime = shootDelay + Time.time;
    }
}
