using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject player;
    private string Behavior;
    public float force;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(ContactPoint2D hitPos in collision.contacts)
        {
            if (collision.gameObject.tag.Equals("Flash"))
            {
                if (hitPos.normal.y < 0)
                {
                    Debug.Log("Hit the top:" + hitPos.normal.y);
                    Vector3 newTransform = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    transform.position = newTransform;
                }
                else if (hitPos.normal.y > 0)
                {
                    Debug.Log("Hit the bottom: " + hitPos.normal.y);
                    Vector3 newTransform = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    transform.position = newTransform;
                }
                else if (hitPos.normal.x < 0)
                {
                    Debug.Log("Hit the left:" + hitPos.normal.x);
                    Vector3 newTransform = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    transform.position = newTransform;
                }
                else
                {
                    Debug.Log("Hit the left:" + hitPos.normal.x);
                    Vector3 newTransform = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    transform.position = newTransform;
                }
            }
            }
    }
}
