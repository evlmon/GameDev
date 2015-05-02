using UnityEngine;
using System.Collections;

public class MoveObstacles : MonoBehaviour {
	public float speed = -10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var obstacles = GameObject.FindGameObjectsWithTag("Obstacle");  //returns GameObject[]
		foreach(var obstacle in obstacles)
		{
			var rb2d = obstacle.GetComponent<Rigidbody2D>();
			rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
		}
	}
}
