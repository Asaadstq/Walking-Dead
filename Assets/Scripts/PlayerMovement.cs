using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public Animator anim;
    public float speed = 5f;           // Player movement speed
    public float rotationSpeed = 200f; // Player rotation speed
    public float jumpForce = 10f;      // Jump force

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        anim.SetFloat("Vertical", vertical);
        //anim.SetFloat("Horizontal", horizontal);
        Vector3 movement = new Vector3(0f, 0f, vertical) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        // Player rotation with arrow keys
        RotateWithArrowKeys();

        // Player jumping
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Jump",true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else{
             anim.SetBool("Jump",false);
        }
    }

    void RotateWithArrowKeys()
    {
        float horizontalRotation = Input.GetAxis("Horizontal");
        //float verticalRotation = Input.GetAxis("Vertical");

        Vector3 rotation = new Vector3(0f, horizontalRotation, 0f) * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void rotat(){

        
       // rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

    }
}
