using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respaus : MonoBehaviour {

	public bool pausee;

	// Use this for initialization
	void Start () {
		pausee = false;

	}

	// Update is called once per frame
	void Update () {


	}


	public void Onpause(){
		pausee = !pausee;
		if (!pausee) {

			Time.timeScale = 1;
		} else if (pausee) {

			Time.timeScale = 0;
		}

	}
}
