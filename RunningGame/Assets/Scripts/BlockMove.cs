using UnityEngine;
using System.Collections;

public class BlockMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
     transform.Translate(Vector2.left * Time.deltaTime * 4.0f);
     Destroy(this.gameObject, 5.0f);
	}
}
