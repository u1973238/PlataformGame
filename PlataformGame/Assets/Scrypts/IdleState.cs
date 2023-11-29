using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState Chase;
    public bool canSeePLAYER;
    public override State RunCurrentState()
    {
        if(canSeePLAYER)
        {
            return Chase;
        }
        else
        {
            return this;
        }
    }
}
