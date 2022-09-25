using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFallPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody playerRigidbody;
    public float ActivateFallingSpeed = -10f;
    public float FatalFallingDistance = 1f;
    public AudioSource birdKill;
    //public PlayerHealthController script; //changed by Iryna

    public float fallDistance = 0f;
    private float initialFallHeight;
    public bool isDead = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player is falling
        if (playerRigidbody.velocity.y < ActivateFallingSpeed)
        {
            initialFallHeight = transform.position.y;
            Fall();
        }

    }

    void Fall()
    {   
        fallDistance += Mathf.Abs(transform.position.y);
        //if the player is falling for a distance bigger than killFallDistance
        if(fallDistance > FatalFallingDistance && isDead == false)
            {
                isDead = true;
                birdKill.Play();
            //script.currentHealth = 0; //changed by Iryna
            //script.DamagePlayer(); //changed by Iryna
            PlayerHealthController.instance.FallPlayer(); //created the function to handle the death in PlayerHealthController Instance
        }
    }

}
