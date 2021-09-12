using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : Enemy // INHERITENCE
{
    private bool _goRight = false;
    private void Start()
    {
        StartCoroutine(SpeedUp());
    }
    private void Update()
    {
        if (!GameManager._isPaused && !GameManager._isEnd)
        {
            EnemyMovement(_speed);
        }
        KillEnemyAtZeroHealth();
    }
    protected override void EnemyMovement(float speed) // POLMORPHISM
    {
        if(!_goRight)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else if(_goRight)
            transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            if (!_goRight)
                _goRight = true;
            else
                _goRight = false;
        }
    }
}
