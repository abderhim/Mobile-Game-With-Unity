using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


		void OnTriggerEnter2D ()
		{
				// Put a particle effect here
				//Instantiate(explosioneffect, transform.position, transform.rotation);
				Destroy(gameObject);

		}
}
