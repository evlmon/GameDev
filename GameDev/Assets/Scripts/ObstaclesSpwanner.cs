using UnityEngine;
using System.Collections;

public class ObstaclesSpwanner : MonoBehaviour {
	public GameObject platform;
	private float verticalMin = 2f;
	private float verticalMax = 7f;
	private float horizontalMin = 30;
	private float horizontalMax = 40f;
	int maxPlatforms = 5;
	int ticks = 0;

	public const int SPAWN_INTERVAL = 150;

	// Use this for initialization
	void Start () {
		
		Spawn ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ticks++;
		if (ticks > SPAWN_INTERVAL) {
			Spawn();
			ticks = 0;
		}
	}

	void Spawn()
	{
		int sign = Random.Range (0, 1);
		Vector2 randomPosition = new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range (verticalMin*(sign -1), verticalMax * (sign-1)));
		Instantiate(platform, randomPosition, Quaternion.identity);
	}
}
