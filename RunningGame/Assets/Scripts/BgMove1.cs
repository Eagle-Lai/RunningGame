using UnityEngine;
using System.Collections;

public class BgMove1 : MonoBehaviour {

    float speed = 6.0f;
	
	void Update () {
        transform.Translate(-Vector2.right * Time.deltaTime * speed);
        if (transform.position.x >= 18f)
        {
            transform.position = new Vector3(-18f, 0,6);
        }
	}
}
