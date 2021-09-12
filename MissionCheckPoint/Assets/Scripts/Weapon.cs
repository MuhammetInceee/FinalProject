using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private GameObject _bulletPrefab;

    public static int _bulletCount = 150;

    void Start()
    {
        _bulletCount = 150;
    }

    void Update()
    {
        if (!GameManager._isPaused && !GameManager._isEnd)
        {
            Shoot();
            Movement();
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _bulletCount != 0)
        {
            Instantiate(_bulletPrefab, _shootPoint.transform.position, _shootPoint.transform.rotation);
            _bulletCount--;
        }
    }
    void Movement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * _horizontalInput * _speed * Time.deltaTime);
        transform.Rotate(Vector3.left * _verticalInput * _speed * Time.deltaTime);
    }
}
