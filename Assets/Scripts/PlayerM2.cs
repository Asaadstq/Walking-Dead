using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerM2 : MonoBehaviour
{
    public Animator anim;
    public float speed = 5f;           // Player movement speed
    public float rotationSpeed = 200f; // Player rotation speed
    public float mouseSensitivity = 2f; // Mouse sensitivity
    public float jumpForce = 10f;
    public Slider slider;
    public GameObject player;   // Jump force

    private Rigidbody rb;
    private Camera playerCamera;
    private float rotationX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main; // Assuming your camera is the main camera
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        anim.SetFloat("Vertical", vertical);

        Vector3 movement = new Vector3(0f, 0f, vertical) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        // Player rotation with arrow keys
        RotateWithArrowKeys();

        // Player jumping
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Jump", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        // Rotate the player and camera based on mouse input
        RotateWithMouse();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            slider.value -= 0.3f;
            if (slider.value == 0)
            {
                SceneManager.LoadScene("LastScene");
                Destroy(player);
            }
        }
    }

    void RotateWithArrowKeys()
    {
        float horizontalRotation = Input.GetAxis("Horizontal");
        Vector3 rotation = new Vector3(0f, horizontalRotation, 0f) * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * mouseSensitivity * Time.deltaTime;

        // Rotate the player around the Y-axis (horizontal movement)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera around the X-axis (vertical movement)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limit vertical rotation to avoid flipping the camera
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    public void rotat()
    {
        // If you need to rotate the player through other means, you can implement it here
    }
}
