using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public float waitBeforeRespawning;

    [HideInInspector]
    public bool respawning;

    private PlayerMovement player;

    [HideInInspector]
    public Vector3 respawnPoint;

    //private CameraController gameCamera;

    public int currentApples;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        respawnPoint = player.transform.position;
        //gameCamera = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Respawn()
    {
        if(!respawning)
        {
            respawning = true;
            StartCoroutine(RespownCoroutine());

        }
    }

    public IEnumerator RespownCoroutine()
    {
        UIController.instance.FadeToBlack();
        IguanaCharacter.instance.Death();
        yield return new WaitForSeconds(3);


        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitBeforeRespawning);

        player.transform.position = respawnPoint;

        //gameCamera.SnapToTarget();

        player.gameObject.SetActive(true);

        respawning = false;
        UIController.instance.FadeToTransparent();
    }

    public void GetApple()
    {
        currentApples++;
        UIController.instance.appleText.text = currentApples.ToString();
    }
}
