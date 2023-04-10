using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	// public float mSpeed = 20f;
	public float health = 4f;
	private bool isQuitting = false;
		
	// Use this for initialization
	void Start () {
		// NewDirection();
	}
	
	// Update is called once per frame
	void Update () {
		// transform.position += (mSpeed * Time.smoothDeltaTime) * transform.up;
		GlobalBehavior globalBehavior = GameObject.Find ("GameManager").GetComponent<GlobalBehavior>();
		
		GlobalBehavior.WorldBoundStatus status =
			globalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds);
			
		if (status != GlobalBehavior.WorldBoundStatus.Inside) {
			Debug.Log("collided position: " + this.transform.position);
			// NewDirection();
		}	
		if (health == 0)
		{
			Destroy(gameObject);
		}
	}

	// New direction will be something completely random!
	// private void NewDirection() {
	// 	Vector2 v = Random.insideUnitCircle;
	// 	transform.up = new Vector3(v.x, v.y, 0.0f);
	// }

	void OnCollisionEnter2D(Collision2D col)
    {
        // Check if the collision involves the other game object you're interested in
        if (col.gameObject.name == "Hero")
        {
            Destroy(gameObject);  // this.gameObject, this is destroying the game object
			GlobalBehavior.sTheGlobalBehavior.IncTouched();
        };
		if (col.gameObject.name == "Egg(Clone)")
        {
            health -= 1f;
			Destroy(col.gameObject);
            GlobalBehavior.sTheGlobalBehavior.DecEggCount();
			Color objectColor = GetComponent<Renderer>().material.color;
			objectColor.a *= 0.8f;
			GetComponent<Renderer>().material.color = objectColor;
			Debug.Log(health);
        };
    }
	void OnApplicationQuit()
	{
		isQuitting = true;
	}
	private void OnDestroy()
    {
		if (!isQuitting)
		{
        // Get a reference to the EnemySpawner script
        EnemySpawner enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        
        // Spawn a new enemy
        enemySpawner.spawnEnemy();
		}
    }
}
