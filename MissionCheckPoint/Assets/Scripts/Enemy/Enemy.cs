using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour //ABSTRACTION
{
    public int _health;
    public float _speed;
    public int _score;

    protected abstract void EnemyMovement(float speed); //ABSTRACTION

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            _health--;
        }
    }

    public virtual void KillEnemyAtZeroHealth()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
            GameManager._aliveEnemy--;
            UIManager._score += _score;
        }
    }
    private void PlusSpeed()
    {
        _speed += 3;
    }
    public IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(15);
        InvokeRepeating("PlusSpeed", 1, 15);
    }
}
