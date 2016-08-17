using UnityEngine;
using System.Collections;

public class FlameSpawner : MonoBehaviour {

	public float velocity;

	// Use this for initialization
	void Start () {

		// To have the fireball fall randomly following 5 paths
		int randomNumber = Random.Range(2,10);
		if (randomNumber % 2 != 0) {
			randomNumber++;
		}

		Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(randomNumber/10.0f, 5.0f, 0.0f));
		position.z = 0.0f;
		transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(0, Time.deltaTime * velocity, 0);

		// Remove
		if (Camera.main.WorldToViewportPoint(transform.position).y < 0.0f) {
			Destroy(gameObject);
		}
	}
}
