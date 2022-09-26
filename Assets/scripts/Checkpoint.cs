using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject effect;
    public Transform effectPoint;
    public AudioSource checkpointSFX;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LevelManager.instance.respawnPoint = transform.position;
            if(effect != null)
            {
                Instantiate(effect, effectPoint.position, Quaternion.identity);
            }
            checkpointSFX.Play();
            Destroy(gameObject);
        }
    }
}
