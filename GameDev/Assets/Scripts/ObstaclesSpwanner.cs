using UnityEngine;
using System.Collections;

public class ObstaclesSpwanner : MonoBehaviour {
	public GameObject platform;
	private float verticalMin = 2f;
	private float verticalMax = 7f;
	private float horizontalMin = 20;
	private float horizontalMax = 30f;
	int maxPlatforms = 5;
	int ticks = 0;

	public const int SPAWN_INTERVAL = 200;

	private Vector2 originPosition;
	// Use this for initialization
	void Start () {
		originPosition = transform.position;
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
		Vector2 randomPosition = originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range (verticalMin*(sign -1), verticalMax * (sign-1)));
		Instantiate(platform, randomPosition, Quaternion.identity);
	}
}
