using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float jumpDelay = 0.5f;
    private float lastJump = 0;

    private bool grounded = true;
    //private bool isStill = true;
    private float previousY = 0;// used to determine if grounded
    //private float previousX = 0;//used to determine if moving in a direction, to avoid applying transform when you cant move.

    private float jumpHeight = 8.0f;
    public float getFacing
    {
       get { return facing; }
    }
    private float facing = 1;// positive in the x direction
    private float previousFacing;
    private bool flashLightOn = false;
    // Use this for initialization
    Vector3 m_NewForce;
    Rigidbody2D m_Rigidbody;
    BoxCollider2D m_BoxCollider;
    GameObject m_flash;
    Vector3 yAxis = new Vector3(0,1,0);
    Vector3 playerX;


    void Start () {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_BoxCollider = GetComponent<BoxCollider2D>();
        m_flash = gameObject.transform.Find("Flash").gameObject;
        m_NewForce = new Vector3(facing , jumpHeight, 0.0f);
        previousFacing = facing;
        playerX = new Vector3(gameObject.transform.position.x, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = Input.mousePosition;
        SpriteRenderer playerSprite = gameObject.GetComponent<SpriteRenderer>();

        float x;
        playerX = new Vector3(gameObject.transform.position.x, 0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            x = 1f * Time.deltaTime * 4.0f;
        }else if (Input.GetKey(KeyCode.A))
        {
            x = 1f * Time.deltaTime * 4.0f;
        }
        else
        {
            x = 0f * Time.deltaTime * 4.0f;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            if (flashLightOn)
            {
                flashLightOn = false;
                m_flash.SetActive(flashLightOn);
            }
            else
            {
                flashLightOn = true;
                m_flash.SetActive(flashLightOn);
            }                
        }

        Vector3 origin = new Vector3(0.0f, 0, 0);
        if (Input.GetAxis("Horizontal") > 0 && facing < 0)
        {
            gameObject.transform.RotateAround(playerX, Vector3.up,180f);
            previousFacing = facing;
            facing = 1;
        }
        else if (Input.GetAxis("Horizontal") < 0 && facing > 0)
        {
            gameObject.transform.RotateAround(playerX, Vector3.up, 180f);
            previousFacing = facing;
            facing = -1;
        }

        transform.Translate(x, 0, 0);

        if (Input.GetKeyDown("space") && lastJump <= 0 && grounded)
        {
            lastJump = jumpDelay;
            //Use Impulse as the force on GameObject
            m_Rigidbody.AddForce(m_NewForce, ForceMode2D.Impulse);

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
        m_NewForce = new Vector3(facing, jumpHeight, 0.0f);
    }

}
