using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioSource appleSound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            LevelManager.instance.GetApple();
            appleSound.Play();
            //yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
            
        }
    }
}
