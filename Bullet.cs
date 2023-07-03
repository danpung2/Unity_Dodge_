using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody _bulletRigidBody;
    void Start()
    {
        _bulletRigidBody = GetComponent<Rigidbody>();
        _bulletRigidBody.velocity = transform.forward * speed;
        
        Destroy(gameObject, 3f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
