using UnityEngine;
using System.Collections;

public class ObstaclesSpwanner : MonoBehaviour {
	public GameObject platform;
	public GameObject blob;

	private float verticalMin = 2f;
	private float verticalMax = 7f;
	private float horizontalMin = 30;
	private float horizontalMax = 40f;
	int ticks = 0;
	int nextMonterSpawn = 0;

	public const int SPAWN_INTERVAL = 150;

	private FlipLevel flipScript;

	// Use this for initialization
	void Start () {
		nextMonterSpawn = Random.Range (50, 100);
		flipScript = gameObject.GetComponent<FlipLevel> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ticks++;
		SpawnMonster ();
		if (ticks > SPAWN_INTERVAL) {
			SpawnObstacle();
			ticks = 0;
		}
	}
	void SpawnMonster()
	{
		if (--nextMonterSpawn == 0) {
			nextMonterSpawn = Random.Range(50,100);
			Vector2 randomPosition = new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range (verticalMin, verticalMax ));
			var blobInstance  = Instantiate(blob, randomPosition, Quaternion.identity) as GameObject;
			if(!flipScript.upsideDown)
			{
				flipScript.Flip(blobInstance);
			}

			var transform = blobInstance.GetComponent<Transform> ();
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;

		}
	}

	void SpawnObstacle()
	{
		int sign = Random.Range (0, 1);
		Vector2 randomPosition = new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range (verticalMin*(sign -1), verticalMax * (sign-1)));
		Instantiate(platform, randomPosition, Quaternion.identity);
	}
}
