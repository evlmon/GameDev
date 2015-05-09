using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2d;
    
    // Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    public void Move(Vector3 direction, Vector3 rotation)
    {
        //transform.rotation =Quaternion. rotation;
        rb2d.velocity = direction;   
    }
}
