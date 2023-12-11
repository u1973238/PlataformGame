using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    public GameObject pointA,pointB,player;
    public Enemy Body;
    GameObject Point;
    public ChaseState Chase;
    bool canSeePLAYER;
    public float speed = 2.5f;
    private float distance;

    private bool dir=true;
    public override State RunCurrentState()
    {
        if(canSeePLAYER)
        {
            return Chase;
        }
        else
        {
            if (dir)
            {
                Point = pointA;
                if(Vector2.Distance(Body.transform.position, pointA.transform.position) < 0.01f)
                {
                    dir = false;
                }
            }
            else
            {
                Point = pointB;
                if (Vector2.Distance(Body.transform.position, pointB.transform.position) < 0.01f)
                {
                    dir = true;
                }
            }

            if(Vector2.Distance(Body.transform.position, player.transform.position) < 4f)
            {
                canSeePLAYER=true;
            }

            //Move of the enemy
            distance = Vector2.Distance(Body.transform.position, Point.transform.position);
            Vector2 direction = Point.transform.position - Body.transform.position;
            Body.transform.position = Vector2.MoveTowards(this.transform.position, Point.transform.position, speed * Time.deltaTime);

            return this;
        }
    }
}
