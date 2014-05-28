using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	
	public float bossTimerLimit;
	public GameObject bossMissilePrefab, bossMissileLauncher01, bossMissileLauncher02;
    public float bossHealth;
    public float bossTimer;
	public Vector3 bossNewPosition, bossNewPositionViewport;
	public float bossNewPositionX;
	public float bossNewPositionZ;
	public float bossPositionY;
	public bool bossMoving = false, bossAttacking = false, bossMissile;
	Camera cam;
	public float bossHealthBar;
	public GameObject player;
	public float bossAttackTimer;
	public bool bossCanAttack = false;
	public float bossCanAttackTimer;
	
	
	
	// Use this for initialization
	void Start () {
		bossPositionY = 30.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!bossCanAttack) {
			transform.position = new Vector3 (0.0f, 0.0f, Camera.main.transform.position.z + 100.0f);
			bossCanAttackTimer += Time.deltaTime;
			if (bossCanAttackTimer >= 2.0f) 
				bossCanAttack = true;
		} else if (bossCanAttack) {
			player = GameObject.FindGameObjectWithTag ("Player");
			transform.LookAt (player.transform);
			bossTimer += Time.deltaTime;
			if (bossTimer >= bossTimerLimit) {
				if (bossMoving == false && bossAttacking == false) {
					BossMoveCalc ();
					bossAttackTimer = 0.0f;
				}
				if (bossMoving == true && bossAttacking == false) {
					bossAttackTimer += Time.deltaTime;
					bossNewPosition = Camera.main.ViewportToWorldPoint (bossNewPositionViewport);
					bossNewPosition = new Vector3(bossNewPosition.x, 13.0f, bossNewPosition.z);
					gameObject.transform.position = Vector3.Lerp (transform.position, bossNewPosition, 3.0f * Time.deltaTime);
					if (bossAttackTimer >= 2.0f) {
						bossMoving = false;
						bossAttacking = true;
					}
								
				}
				if (bossMoving == false && bossAttacking == true) {
					BossAttack ();
				}
			}
			if (bossHealth <= 0.0f) {
				Destroy (gameObject);
			}
			if (bossHealth > 0.0f) {
				bossHealthBar = bossHealth;
			} else if (bossHealth <= 0.0f) {
				bossHealthBar = 0.0f;
			}
		}
	}

    void OnGUI() {
        GUI.Box(new Rect(Screen.width/2.0f - bossHealthBar, Screen.height/12.0f, bossHealthBar * 2.0f, 20.0f), " ");
        //GUI.Box(new Rect(Screen.width/2 - bossHealthBar, 10, 100, 90), "Loader Menu");
    }


		

	
	void BossAttack() {
        if (bossMissile)
        {
            Instantiate(bossMissilePrefab, bossMissileLauncher01.transform.position, gameObject.transform.rotation);
            
        }
        else
        {
            Instantiate(bossMissilePrefab, bossMissileLauncher02.transform.position, gameObject.transform.rotation);
        }
        bossMissile = !bossMissile;
		bossTimer = 0.0f;
		bossAttacking = false;
		return;
		
	}
	
	void BossMoveCalc() {
		bossNewPositionX = Random.Range (0.2f, 0.8f);
		bossNewPositionZ = Random.Range (0.7f, 0.9f);
		bossNewPositionViewport = new Vector3(bossNewPositionX, bossNewPositionZ, bossPositionY);
		bossMoving = true;
		return;
		
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Shot") {
			bossHealth -= 5.0f;
            Destroy(other.gameObject);
            Debug.Log("Colisao");
	}
}
}

//Fazer:
//Empty GameObjects para atirar os misseis
//Box Collider no Boss
//Tag "Shot" no tiro do player
//

