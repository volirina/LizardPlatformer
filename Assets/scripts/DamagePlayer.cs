using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    Animator birdAnimator;
    public void Start()
    {
        birdAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            birdAnimator.SetTrigger("Leave");
            PlayerHealthController.instance.DamagePlayer();
        }
    }
}
