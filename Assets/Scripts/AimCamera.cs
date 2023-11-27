using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{ 
    //public Transform firePoint;     // Point where bullets are spawned
    //public GameObject bulletPrefab;  // Prefab of the bullet
    //public float bulletForce = 10f; // Force applied to the bullet
   // public float fireRate = 0.5f;    // Rate of fire (bullets per second)
    public Camera playerCamera;
    public float zoomFOV = 40f;
    private float defaultFOV;
    public Animator anim;
    public float rotationSpeed = 200f;


    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main; // Assuming the camera is tagged as MainCamera
        }

        if (playerCamera != null)
        {
            defaultFOV = playerCamera.fieldOfView;
        }
        else
        {
            Debug.LogError("Player camera not assigned and no MainCamera found!");
        }
    }

    void Update()
    {
        HandleShooting();
       // Check if the right mouse button is being held down
        if (Input.GetMouseButton(1)) // 1 corresponds to the right mouse button
        {
           
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    void HandleShooting()
    {
        // Check for fire input
        if (Input.GetButtonDown("Fire1")) // Assuming "Fire1" is left mouse button
        {
           // Shoot();
        }
    }

   /* void Shoot()
    {
        // Create a bullet and set its position and rotation to match the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the bullet and apply force forward
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }*/

   
    

    void ZoomIn()
    {
        if (playerCamera != null && playerCamera.fieldOfView != zoomFOV)
        {
         //bool getmouse=Input.GetMouseButton(1);
          
           anim.SetBool("Aim",true);
            // Zoom in
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, zoomFOV, Time.deltaTime * 5f);
           

             float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0f, mouseX, 0f) * rotationSpeed * Time.deltaTime;
        }
    }

    void ZoomOut()
    {
        if (playerCamera != null && playerCamera.fieldOfView != defaultFOV)
        {
          anim.SetBool("Aim", false); 
            // Zoom out
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, defaultFOV, Time.deltaTime * 5f);
        }
}
}