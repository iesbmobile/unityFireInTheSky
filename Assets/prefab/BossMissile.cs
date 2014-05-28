using UnityEngine;
using System.Collections;

public class BossMissile : MonoBehaviour {

    public float missileSpeed;
	public float missileTimerLimit;
    private float missileTimer;

	void Start() {
		missileTimer = 0.0f;
        }

	void Update () {
		missileTimer += Time.deltaTime;
		transform.position += transform.forward * missileSpeed;
		if (missileTimer >= missileTimerLimit) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
						Destroy (gameObject);
				}
		}


}
