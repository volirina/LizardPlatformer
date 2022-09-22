using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public AudioSource checkpointSFX;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LevelManager.instance.respawnPoint = transform.position;
            checkpointSFX.Play();
        }
    }
}
