using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioSource appleEatSFX;

    public GameObject effect;
    public Transform effectPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            appleEatSFX.Play();
            LevelManager.instance.GetApple();
            Destroy(gameObject);
            if (effect != null)
            {
                Instantiate(effect, effectPoint.position, Quaternion.identity);
            }

        }
    }
}
