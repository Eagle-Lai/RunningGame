﻿using UnityEngine;
using System.Collections;

public class BGmoveBotton : MonoBehaviour {

    public static float speed = 4.0f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        if (transform.position.x >= 18f)
        {
            transform.position = new Vector3(-18f, -4.5f);
        }
    }
}
