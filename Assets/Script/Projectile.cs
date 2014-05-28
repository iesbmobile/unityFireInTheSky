using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float velocity = 20f;
	public float duration = 5f;

	float startTime;

	ParticleSystem particlesystem;

	void OnEnable ()
	{
		startTime = Time.time;
		particlesystem = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
		particlesystem.enableEmission = true;

	}

	void FixedUpdate ()
	{
		if (Time.time - startTime > duration)
		{
			ObjectPool.Instance.PoolObject(gameObject);
		}
		else
		{
			transform.rigidbody.velocity = transform.forward * velocity;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Enemy enemy = other.GetComponent<Enemy>();

		if (enemy)
		{

			enemy.hp -= 1;
			Debug.Log("colidiu");

			ObjectPool.Instance.PoolObject(gameObject);
		}


	}

}
