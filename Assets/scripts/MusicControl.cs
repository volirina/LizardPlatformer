using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public static MusicControl instance; //creates a static variable for the Music Control instance

    private void Awake() //runs before Start()
    {
        DontDestroyOnLoad(this.gameObject); //prevents from destroying Game Object in diff scenes

        if(instance == null) //If the Music Control instance variable is null
        {
            instance = this; //set this object as the instance
        }
        else //if there is already a Music Control instance active
        {
            Destroy(gameObject);
        }
    }
}
