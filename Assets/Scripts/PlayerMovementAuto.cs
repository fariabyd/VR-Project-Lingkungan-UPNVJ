using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAuto : MonoBehaviour
{
    // public CharacterController controller;
    public float speed = 2f;
    public float gravity = -125f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    // Vector3 velocity;
    bool isGrounded;

    public GameObject obj;
    public GameObject[] pathPoints;
    public int numberOfPoints;

    Vector3 velocity;
    private int x;

    void Start()
    {
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        // float x = Input.GetAxis("Horizontal");
        // float z = Input.GetAxis("Vertical");

        // Vector3 move = transform.right*x + transform.forward*z;

        // controller.Move(move*speed*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*gravity);
        }

        velocity.y += gravity*Time.deltaTime;
        // controller.Move(velocity*Time.deltaTime/2);

        velocity = obj.transform.position;
        obj.transform.position = Vector3.MoveTowards(velocity, pathPoints[x].transform.position, speed * Time.deltaTime);

        if(velocity == pathPoints[x].transform.position && x != numberOfPoints - 1)
        {
            x++;
        }
        
    }
}
