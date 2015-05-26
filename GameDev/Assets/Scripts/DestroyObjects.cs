using UnityEngine;
using System.Collections;

public class DestroyObjects : MonoBehaviour {
	

	void OnTriggerExit2D(Collider2D other)
	{
		Destroy (other.gameObject);
	}
}
