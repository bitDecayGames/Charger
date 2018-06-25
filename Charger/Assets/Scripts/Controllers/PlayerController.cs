using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        

        transform.Translate(x, 0, 0);

        if (Input.GetKeyDown("space"))
        {
             transform.Translate(Vector3.up * 130 * Time.deltaTime, Space.World);
        }
    }
}
