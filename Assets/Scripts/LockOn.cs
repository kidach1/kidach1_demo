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

			// スムーズにターゲットの方向を向く
			// Quaternion.LookRotation(A - B); B位置からA位置を向いた状態の向きを算出
			Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
			// Quaternion.Slerp(現在の向き, 目標の向き, 歩合); 自身がターゲットに徐々に向くように、3つ目の引数（歩合）＝回転のスピード。
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * 10);

			// LookAtの際、XやZ軸もtargetの方向を向いてしまうのを補正
			transform.rotation = new Quaternion (0, transform.rotation.y, 0, transform.rotation.w);

			// カメラをターゲットに向ける
			Transform cameraParent = Camera.main.transform.parent;
			Quaternion targetRotation2 = Quaternion.LookRotation (target.transform.position - cameraParent.position);
			cameraParent.localRotation = Quaternion.Slerp (cameraParent.localRotation, targetRotation2, Time.deltaTime * 10);
			cameraParent.localRotation = new Quaternion (cameraParent.localRotation.x, 0, 0, cameraParent.localRotation.w);
		}
	}
}
