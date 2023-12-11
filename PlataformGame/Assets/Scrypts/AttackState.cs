using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public ChaseState Chase;
    public override State RunCurrentState()
    {
        
        return Chase;
    }
}
