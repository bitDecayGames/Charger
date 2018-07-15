using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    private float jumpHeight = 8.0f;
    private float jumpDelay = 0.25f;
    private float lastJump = 0;

    //reference to your flashlight
    public GameObject flashLight;
    //used to controller if flashlight is on.
    private bool flashLightOn = true;

    //used to start jump timer.
    private bool grounded = true;
    // used to determine if grounded
    private float previousY = 0;

    // positive in the x direction is right.
    private float facing = 1;


    // Use this for initialization
    Vector3 jumpForce;
    Rigidbody2D playerRigidbody;
       
    Vector3 playerXPosV3;


    void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        
        jumpForce = new Vector3(facing , jumpHeight, 0.0f);
        
        playerXPosV3 = new Vector3(gameObject.transform.position.x, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = Input.mousePosition;
        

        float x;
        playerXPosV3 = new Vector3(gameObject.transform.position.x, 0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            x = 1f * Time.deltaTime * 4.0f;
        }else if (Input.GetKey(KeyCode.A))
        {
            x = -1f * Time.deltaTime * 4.0f;
        }
        else
        {
            x = 0f * Time.deltaTime * 4.0f;
        }




        if (Input.GetAxis("Horizontal") > 0 && facing < 0)
        {
            //transform.RotateAround(playerXPosV3, Vector3.up, 180f);
            facing = 1;
        }
        else if (Input.GetAxis("Horizontal") < 0 && facing > 0)
        {
            //transform.RotateAround(playerXPosV3, Vector3.up, 180f);
            facing = -1;
        }

        transform.Translate(x, 0, 0);

        if (Input.GetKeyDown("space") && lastJump <= 0 && grounded)
        {
            lastJump = jumpDelay;
            //Use Impulse as the force on GameObject
            playerRigidbody.AddForce(jumpForce, ForceMode2D.Impulse);

        }

        if (lastJump > 0)
            lastJump -= Time.deltaTime;
        

        if (transform.position.y != previousY)        
            grounded = false;
        else
            grounded = true;

        //if (transform.position.x != previousX)
        //    isStill = false;
        //else
        //    isStill = true;


        previousY = transform.position.y;
        //previousX = transform.position.x;
        jumpForce = new Vector3(facing, jumpHeight, 0.0f);

        if (Input.GetMouseButtonDown(0))
        {
            if (flashLightOn)
            {
                flashLightOn = false;
                flashLight.SetActive(flashLightOn);
            }
            else
            {
                flashLightOn = true;
                flashLight.SetActive(flashLightOn);
            }
        }
    }

}
