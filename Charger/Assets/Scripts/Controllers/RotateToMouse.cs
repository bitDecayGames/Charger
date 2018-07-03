using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour {

    public float speed = 5f;
    private HingeJoint2D hinge;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    private PlayerController playerController;
    private Transform playerPos;
    public float upperAngle = 70.0f;
    public float LowerAngle = -70.0f;
    private float prevsiousFacing;

    // Update is called once per frame
    void Update () {
        hinge = gameObject.GetComponent<HingeJoint2D>();
        playerController = transform.parent.gameObject.GetComponent<PlayerController>();
        playerPos = transform.parent.gameObject.GetComponent<Transform>();
        prevsiousFacing = playerController.getFacing;
        faceMouse();
    }

    void faceMouse()
    {
        float currentFacing = playerController.getFacing;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        Vector3 forward = Vector3.forward;
        

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 flashX = new Vector3(gameObject.transform.position.x, 0, 0);

        if (prevsiousFacing != currentFacing)
        {
            gameObject.transform.RotateAround(flashX, Vector3.forward, 180f);
        }
        

        Quaternion rotation = Quaternion.AngleAxis(angle, forward);
        

        if(angle > LowerAngle && angle < upperAngle)
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed*Time.deltaTime);

        prevsiousFacing = playerController.getFacing;

    }
}
