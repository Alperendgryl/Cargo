using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float screenWidth = Screen.width;
    public float jumpingForce = 200f;
    public static float speed = 3f;

    
    private bool isMoving = false;
    public bool isDead = false;

    private Animator anim;

    AudioSource footstep;
    DeadPhysics dp;

    private void Start()
    {
        anim = GetComponent<Animator>();
        footstep = GetComponent<AudioSource>();
        this.transform.position = new Vector3(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"), PlayerPrefs.GetFloat("zPos"));
    }

    void Update()
    {
        PlayerMovement();
        PlayerPrefs.SetFloat("xPos", this.transform.position.x);
        PlayerPrefs.SetFloat("yPos", this.transform.position.y);
        PlayerPrefs.SetFloat("zPos", this.transform.position.z);
    }

    void PlayerMovement()
    {
        anim.SetBool("isWalking", false); //ıdle
        anim.SetBool("isWalkingBackward", false); // ıdle
        anim.SetBool("isDying", false);
        isMoving = false;


        if (Input.GetKey("right")) // right
        {
            //(Input.GetTouch(0).position.x > screenWidth / 4 && Input.GetTouch(0).position.x < screenWidth / 2 ||  // FOR MOBILE DEVICES DELETE THE GETKEY CODES AND REPLACE THIS CODE LINE
            transform.position += Vector3.right * speed * Time.deltaTime;
            anim.SetBool("isWalking", true);
            isMoving = true;
        }

        if (Input.GetKey("left")) // left
        {
            //Input.GetTouch(0).position.x < screenWidth / 4 ||  // FOR MOBILE DEVICES DELETE THE GETKEY CODES AND REPLACE THIS CODE LINE0
            transform.position += Vector3.left * speed * Time.deltaTime;
            anim.SetBool("isWalkingBackward", true);
            isMoving = true;
        }

        if(isDead == true)
        {
            anim.SetBool("isDying", true);
        }

        if (isMoving)
        {
            if (!footstep.isPlaying)
            {
                footstep.Play();
            }
        }
        else
        {
            footstep.Stop();
        }
    }

    /*
      
        private void OnCollisionEnter(Collision collision)
        {
        canJump = true;
        }

        private bool canJump = false;
    
        if (Input.GetKeyDown("space") && canJump) // Jump 
        {
            //Input.GetTouch(0).position.x > screenWidth / 2 ||  // FOR MOBILE DEVICES DELETE THE GETKEY CODES AND REPLACE THIS CODE LINE
            GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
            canJump = false;
            //anim.SetBool("isJumping", true);
        }
     */

}
