using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public GameObject Body;

    public bool isFlipped = false;

    public void LookAtPlayer()
    {
        Vector3 flipped = Body.transform.localScale;
        flipped.z *= -1f;

        if (Body.transform.position.x > player.position.x && isFlipped)
        {
            Body.transform.localScale = flipped;
            Body.transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (Body.transform.position.x < player.position.x && !isFlipped)
        {
            Body.transform.localScale = flipped;
            Body.transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
