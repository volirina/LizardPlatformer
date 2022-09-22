using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFallPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float killFallDistance;
    public Rigidbody playerRigidbody;
    public float FallingThreshold = -10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player is falling
        if (playerRigidbody.velocity.y < FallingThreshold)
        {
            Fall();
        }

    }

    void Fall()
    {
        //if the player is falling for a distance bigger than killFallDistance
            PlayerHealthController.instance.DamagePlayer();
    }

}
