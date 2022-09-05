using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public Vector3 forceAdded = new Vector3(0, 5, 0);
    public bool isOnGround = true;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);

        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(forceAdded, ForceMode.Impulse); //applies instant force
            isOnGround = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
