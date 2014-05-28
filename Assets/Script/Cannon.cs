using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20;
	public AudioClip shot;
	private bool canShot = true;

	public float tempoEntreTiro = 0f;
	private float Count = 2f;
	//public string name = "";
	GameObject[] cannons;

	// Use this for initialization
	void Start () {
		cannons =  GameObject.FindGameObjectsWithTag("Cannon");
		Random.seed = 1;
	}
	
	// Update is called once per frame
	void Update () {



		if (Count >= 1.1f) {
			canShot = true;
		}

		if (canShot) {
	


			ObjectPool.Instance.GetObjectForType("Projectile", cannons[0].transform.position);
//			for(int x = 0; x < cannons.Length; x++){
//				
//				//StartCoroutine(Shot(cannons[x]));
//				//ShotNormal(cannons[x]);
//			}
			canShot =  false;

			Count = tempoEntreTiro;
		} 

		Count = Count + Time.deltaTime;





	}


	/*
	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Enemy"){
			Destroy(this.gameObject);
		}
	}
	*/



}
