using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("LevelBoundary"))
		{
			Destroy (this.gameObject);
		}
		if (other.gameObject.CompareTag ("Monster")) 
		{
			Destroy(other.gameObject);
		}
	}
}
