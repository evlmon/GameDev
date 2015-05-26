using UnityEngine;
using System.Collections;

public class DestroyObstacles : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy (other.gameObject);
	}
}
