﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour 
{
    public GameObject player;
    private Vector3 v3Pos;
    private float angle;
    private float distance = .65f;
    private bool flashLightOn = true;
 
    void Update()
    {
        v3Pos = Input.mousePosition;
        v3Pos.z = (player.transform.position.z - Camera.main.transform.position.z);
        v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
        v3Pos = v3Pos - player.transform.position;
        angle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        if (angle < 0.0f) angle += 360.0f;
        transform.localEulerAngles = new Vector3(0, 0, angle);
        float xPos = Mathf.Cos(Mathf.Deg2Rad * angle) * distance;
        float yPos = Mathf.Sin(Mathf.Deg2Rad * angle) * distance;

        transform.localPosition = new Vector3(player.transform.position.x + xPos * 3, player.transform.position.y + yPos * 3  ,0);

        
    }
}
