﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosScript : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(1, 2, 0);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z + offset.z);
    }
}
