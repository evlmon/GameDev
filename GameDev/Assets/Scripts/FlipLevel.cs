using UnityEngine;
using System.Collections;

public class FlipLevel : MonoBehaviour {
	public bool upsideDown = false;
	private bool flip = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Flip"))
		{
			flip = true;
		}
	}

	void FixedUpdate()
	{
		if (true == flip) 
		{
			upsideDown = !upsideDown;
			FlipAllObstacles();
			flip = false;
		}
	}

	void FlipAllObstacles()
	{
		var obstacles = GameObject.FindGameObjectsWithTag("Obstacle");  //returns GameObject[]
		var monsters = GameObject.FindGameObjectsWithTag ("Monster");
		foreach(var obstacle in obstacles)
		{
			Flip (obstacle);
		}

		foreach(var monster in monsters)
		{
			Flip (monster);
		}
	}

	public void Flip(GameObject gameObject){
		var transform = gameObject.GetComponent<Transform> ();
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;

		var currentTranslation = transform.localPosition;
		currentTranslation.x = -currentTranslation.x;
		transform.position = new Vector3 (transform.position.x, -transform.position.y, transform.position.z);
	}
}
