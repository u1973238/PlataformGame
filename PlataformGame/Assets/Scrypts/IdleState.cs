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
    public float speed = 1f;
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
                if(Mathf.Abs(Body.transform.position.x - pointA.transform.position.x) < 0.01f)
                {
                    dir = false;
                    Body.Flip();
                }
            }
            else
            {
                Point = pointB;
                if (Mathf.Abs(Body.transform.position.x - pointB.transform.position.x) < 0.01f)
                {
                    dir = true;
                    Body.Flip();
                }
            }

            if(Vector2.Distance(Body.transform.position, player.transform.position) < 4f)
            {
                canSeePLAYER=true;
            }

            //Move of the enemy
            /*
            distance = Vector2.Distance(Body.transform.position, Point.transform.position);
            Vector2 direction = Point.transform.position - Body.transform.position;
            Body.transform.position = Vector2.MoveTowards(this.transform.position, Point.transform.position, speed * Time.deltaTime);
            */

            //Move enemy in plane
            // Calculate the direction along the x-axis from Body to Point
            float directionX = Mathf.Sign(Point.transform.position.x - Body.transform.position.x);

            // Move the Body towards the Point along the x-axis
            float newX = Mathf.MoveTowards(Body.transform.position.x, Point.transform.position.x, speed * Time.deltaTime);
            Body.transform.position = new Vector2(newX, Body.transform.position.y);

            return this;
        }
    }
}
