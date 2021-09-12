using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _bulletRb;
    [SerializeField] float _speed;
    void Start()
    {
        _bulletRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _bulletRb.velocity = transform.TransformDirection(new Vector3(0, 0, 20));
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
