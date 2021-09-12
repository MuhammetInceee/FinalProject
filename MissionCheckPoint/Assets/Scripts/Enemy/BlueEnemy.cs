using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : Enemy
{
    private void Update()
    {
        KillEnemyAtZeroHealth();
    }
    protected override void EnemyMovement(float speed)
    {
        throw new System.NotImplementedException();
    }
}
