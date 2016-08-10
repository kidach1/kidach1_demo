using UnityEngine;
using System.Collections;

public class LockOn : MonoBehaviour {

	GameObject target = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Lock")) {
			if (target != null) {
				target = null;
			} else {
				// ターゲットを取得する
				target = GameObject.FindWithTag("Enemy");
			}
		}

		if (target != null) {
			// ターゲットの方向を向く
			transform.LookAt(target.transform);
			transform.rotation = new Quaternion (0, transform.rotation.y, 0, transform.rotation.w);
		}
	}
}
