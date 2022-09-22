using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    Animator birdAnimator;
    public AudioSource birdKillSFX;

    public void Start()
    {
        birdAnimator = GetComponent<Animator>();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    birdAnimator.SetBool("isDead", true);
    //    PlayerHealthController.instance.FillHealth();
    //    Destroy(this);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            birdAnimator.SetTrigger("Leave");
            birdKillSFX.Play();
            PlayerHealthController.instance.DamagePlayer();
        }
    }

}
