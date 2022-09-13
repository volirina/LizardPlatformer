using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public Vector3 forceAdded = new Vector3(0, 5, 0);
    public bool isOnGround = true;
    public float sprintMultiplier;
    public float turnSpeed = 45f;

    private bool sprint;
    private float horizontal, vertical;
    Animator iguanaAnimator; //new added be Iryna


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        iguanaAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        sprint = Input.GetKey(KeyCode.LeftShift);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (sprint)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical * sprintMultiplier);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
        }
        transform.Rotate(Vector3.up, turnSpeed * horizontal * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            iguanaAnimator.SetTrigger("Hit"); //new added by Iryna
            rb.AddForce(forceAdded, ForceMode.Impulse); //applies instant force
            isOnGround = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
