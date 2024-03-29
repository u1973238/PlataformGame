using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ChaseState : State
{
    public Enemy Body;
    public AttackState Attack;
    bool isInAttackRange;
    //public Animator animator;

    public float speed = 2.5f;
    float attackRange = 3.5f;
    private float distance;

    public override State RunCurrentState()
    {
        Body.LookAtPlayer();
        if (isInAttackRange)
        {
            isInAttackRange = false;
            Body.SetAtack(true);
            return Attack;
        }
        else
        {
            /*
            distance = Vector2.Distance(Body.transform.position, player.transform.position);
            Vector2 direction = player.transform.position - Body.transform.position;

            Body.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            */

            float directionX = Mathf.Sign(Body.player.position.x - Body.transform.position.x);

            float newX = Mathf.MoveTowards(Body.transform.position.x, Body.player.position.x, speed * Time.deltaTime);
            Body.transform.position = new Vector2(newX, Body.transform.position.y);

            if (Body.transform.position.x - Body.player.position.x < attackRange)
            {
                isInAttackRange = true;
            }
            
            return this;
        }
    }
}
