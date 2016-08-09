using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject target;
	public GameObject shot;
	public GameObject enemyMuzzle;

	float shotInterval = 0;
	float shotIntervalMax = 1.0f;


	// Use this for initialization
	void Start () {
		// ターゲットを取得
		target = GameObject.Find("PlayerTarget");
	}
	
	// Update is called once per frame
	void Update () {
		// ターゲットの方向を向く
		transform.LookAt(target.transform);

		shotInterval += Time.deltaTime;

		if (shotInterval > shotIntervalMax) {

			Debug.Log("self: " + transform.position);
			Debug.Log ("target: " + target.transform.position);

			Instantiate (shot, enemyMuzzle.transform.position, transform.rotation);
			shotInterval = 0;
		}
	}
}
