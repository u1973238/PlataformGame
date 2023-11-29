using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState Attack;
    public bool isInAttackRange;
    public override State RunCurrentState()
    {
        if(isInAttackRange)
        {
            return Attack;
        }
        else
        {
            return this;
        }
    }
}
