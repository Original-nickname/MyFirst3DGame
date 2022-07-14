using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float force = 100f;

    public Camera fpsCamera;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, 
                            fpsCamera.transform.forward,
                            out hit,
                            range
                            ))
        {
            Debug.Log(hit.transform.name);
            ExplosiveBarrelScript barel = hit.transform.GetComponent<ExplosiveBarrelScript>();
            if(barel != null)
            {
                barel.explode = true;
            }

            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
