using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public int hp = 100;
	
	void Update()
	{

		if (hp <= 0) {

			Destroy (transform.parent.gameObject);
		}
	}
}
