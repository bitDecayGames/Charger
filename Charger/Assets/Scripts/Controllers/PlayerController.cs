using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float jumpDelay = 2.0f;
    private float lastJump = 0;
    private float facing = 1;// positive in the x direction
    private bool grounded = true;
    private float previousY = 0;// used to determine if grounded
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        SpriteRenderer playerSprite = gameObject.GetComponent<SpriteRenderer>();
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;

        if (Input.GetAxis("Horizontal") > 0 && facing < 0)
        {
            playerSprite.flipX = false;
            facing = 1;
        }
        else if (Input.GetAxis("Horizontal") < 0 && facing > 0)
        {            
            playerSprite.flipX = true;
            facing = -1;
        }

        transform.Translate(x, 0, 0);

        if (Input.GetKeyDown("space") && lastJump <= 0 && grounded)
        {
            lastJump = jumpDelay;
             transform.Translate(Vector3.up * 130 * Time.deltaTime, Space.World);
        }

        if (lastJump > 0)
            lastJump -= Time.deltaTime;

        if (transform.position.y != previousY)        
            grounded = false;
        else
            grounded = true;

        previousY = transform.position.y;
    }
}
