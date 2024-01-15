using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public Enemy Body;
    public ChaseState Chase;
    private float cooldownTime = 1f, nextCooldown;
    private bool HasAttacked = false;
    public override State RunCurrentState()
    {
        if (!HasAttacked)
        {
            nextCooldown = Time.time + cooldownTime;
            HasAttacked = true;
        }
        else
        {
            if(nextCooldown < Time.time)
            {
                Body.SetAtack(false);
                HasAttacked = false;
                return Chase;
            }
        }
        return this;
    }
}
