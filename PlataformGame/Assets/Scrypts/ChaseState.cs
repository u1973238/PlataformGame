using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public Enemy Body;
    public AttackState Attack;
    bool isInAttackRange;

    public float speed = 2.5f;
    //public float attackRange = 3f;

    public GameObject player;
    private float distance;
    public override State RunCurrentState()
    {
        Body.LookAtPlayer();
        if (isInAttackRange)
        {
            isInAttackRange = false;
            return Attack;
        }
        else
        {
            distance = Vector2.Distance(Body.transform.position, player.transform.position);
            Vector2 direction = player.transform.position - Body.transform.position;

            Body.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            if(Vector2.Distance(Body.transform.position, player.transform.position) < 0.01f )
            {
                isInAttackRange = true;
            }
            
            return this;
        }
    }
}
