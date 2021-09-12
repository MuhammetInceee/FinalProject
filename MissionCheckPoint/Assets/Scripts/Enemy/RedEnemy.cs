using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy // INHERITENCE
{
    private bool _goUp;
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
    protected override void EnemyMovement(float speed)
    {
        if(_goUp)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        else if(!_goUp)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            if (_goUp)
                _goUp = false;
            else
                _goUp = true;
        }
    }
}
