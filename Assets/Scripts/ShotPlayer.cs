using UnityEngine;
using System.Collections;

public class ShotPlayer : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		// 出現後一定時間で自動的に消滅させる
		Destroy(gameObject, 2.0F);
	}
	
	// Update is called once per frame
	void Update () {
		// 弾を前進させる
		transform.position += transform.forward * Time.deltaTime * 100;
	}

	// 他のオブジェクトと衝突した時に呼ばれるメソッド
	private void OnCollisionEnter(Collision collider) {
		if (collider.gameObject.name == "Terrain") {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}
	}
}
