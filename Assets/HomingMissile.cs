using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

	public GameObject target;

	public float speed = 5f;
	public float rotateSpeed = 200f;
	public GameObject explosioneffect;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
				//GameObject.Find("pause").SetActive(false);
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		Vector2 direction = (Vector2)GameObject.Find("AlienSpaceship_0").GetComponent<Transform>().position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
	}

		void OnTriggerEnter2D (Collider2D other)
		{if(other.gameObject.CompareTag("Missle")){


						Destroy(gameObject);

				}
	}
}
