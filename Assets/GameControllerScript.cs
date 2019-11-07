using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {
	public GameObject spaceship;
	bool ispouned;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!ispouned){
			Instantiate (spaceship, transform.position, transform.rotation);
		ispouned = true;
	}
	}
}
