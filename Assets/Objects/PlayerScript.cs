using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public int jumpForce = 100;
    private float jumpCoolDown = 0.2f;
    private Vector3 jumpDirection;
    public bool canJump = true;
    public float movementSpeed = 10.0f;
    public Rigidbody body;
    private GameManager gameManager;
    // private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump") && canJump) {
            Vector3 jump = jumpDirection*jumpForce;
            body.AddForce(jump, ForceMode.Impulse);
            canJump = false;
        } else {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f).normalized;
            Vector3 movement = direction * movementSpeed;
            body.AddForce(movement);
        }


        if(Input.GetButton("Fire1")) {
            Time.timeScale = Mathf.Clamp(Time.timeScale-Time.fixedDeltaTime, 0.5f, 1.0f);
        } else {
            Time.timeScale = Mathf.Clamp(Time.timeScale+Time.fixedDeltaTime, 0.5f, 1.0f);
        }
    }

    public void OnCollisionEnter(Collision collision) {
        canJump = true; //allow jumping off of new surface
        Vector3 normal = collision.GetContact(0).normal; //get collision normal
        
        //if surface is ceiling don't allow a jump
        if(normal == Vector3.down) {
            canJump = false; 
            return;
        }
        
        Vector3 jumpDirection = Vector3.Reflect(-normal+Vector3.up, normal); //get jump directio off of surface
        if(jumpDirection == Vector3.zero) jumpDirection = Vector3.up; //prevents getting stuck on floor
       
        this.jumpDirection = jumpDirection; //set new jump direction
        this.jumpDirection.z = 0.0f;
        Debug.Log("JumpDirection: "+jumpDirection);
    }

}
