using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour {

		public float speed = 1f;
		public GameObject explosioneffect;
		public GUIText gameover;
		public GameObject star;
		public GameObject bomb;
		public float spawnbombTime = 5f; 
		public GameObject flesh;
		public GameObject fleshL;
		private int scorex;

		float x;
		float y;
		float z;
		Vector3 pos;
		bool ins=false;
		bool f = false;
          
		 void Start(){
				flesh.SetActive (false);
				fleshL.SetActive (false);
				Text t=GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
				scorex = int.Parse(t.text);
		
						Spawn ();

				InvokeRepeating ("SpawnBomb", spawnbombTime, spawnbombTime);
		}


		private void Update()
		{
				
				float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
				float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

				transform.Translate(horizontal, vertical, 0f);
				GameObject starx = GameObject.FindGameObjectWithTag ("Star");

				if ((transform.position.x + 7.8f < starx.transform.position.x) && !f) {
						flesh.SetActive (true);
					
						//Instantiate (flesh, pos,Quaternion.Euler(0f,0f,0f));
						f = true;
					
				} else {
						Debug.Log ("3");
						f = false;
						flesh.SetActive (false);
				}

				if ((starx.transform.position.x <transform.position.x - 7.8f  ) && !f) {
						fleshL.SetActive (true);

						//Instantiate (flesh, pos,Quaternion.Euler(0f,0f,0f));
						f = true;

				} else {
						Debug.Log ("3");
						f = false;
						fleshL.SetActive (false);
				}


		}



		void OnTriggerEnter2D (Collider2D other)
		{
				// Put a particle effect here
				if(other.gameObject.CompareTag("Missle")){

						Instantiate(explosioneffect, transform.position, transform.rotation);
						Destroy(gameObject);
						Application.LoadLevel ("gmo");
				}


				else if(other.gameObject.CompareTag("Star")){
						scorex++;
						Text t=GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
						t.text = scorex.ToString ();
						Spawn ();
						Destroy (other.gameObject);

				}

				else if(other.gameObject.CompareTag("Bomb")){
						ins = false;
					

						Destroy (other.gameObject);

						GameObject[] missiles = GameObject.FindGameObjectsWithTag ("Missle");
						foreach (GameObject missile in missiles) {
								Destroy (missile);
						}

				}

				//GameObject.Find("pause").SetActive(true);

			
		}



		void Spawn ()
		{
				// If the player has no health left...
				x = Random.Range(-20,20);
				y =Random.Range(-20,20);
				z = 0;
				pos = new Vector3(x, y, z);

				Debug.Log ("1");

				// Find a random index between zero and one less than the number of spawn points.
				//int spawnPointIndex = Random.Range (0, spawnPoints.Length);

				// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.

				Instantiate (star, pos,Quaternion.Euler(0f,0f,0f));

		}

		void SpawnBomb ()
		{
				// If the player has no health left...
				x = Random.Range(-20,20);
				y = 0;
				z = 0;
				pos = new Vector3(x, y, z);

				// Find a random index between zero and one less than the number of spawn points.
				//int spawnPointIndex = Random.Range (0, spawnPoints.Length);

				// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
				if (!ins) {
						Instantiate (bomb, pos,Quaternion.Euler(0f,0f,0f));
						ins = true;
				}


		}

	
}
