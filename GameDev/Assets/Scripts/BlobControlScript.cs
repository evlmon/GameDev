using System.Collections;
using UnityEngine;

public class BlobControlScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
 	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			var ccs = other.gameObject.GetComponent<CharacterControlScript>();
			ccs.Die();
		}
	}
}