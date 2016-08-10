using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Marker : MonoBehaviour {

	Image marker;
	public Image markerImage;
	GameObject compass;

	// Use this for initialization
	void Start () {
		// マーカーをレーダー（コンパス）上に表示する処理
		// コンパス取得
		compass = GameObject.Find("Compass");
		// マーカーをprefabから初期化
		marker = Instantiate (markerImage, compass.transform.position, Quaternion.identity) as Image;
		// マーカーをコンパスの子オブジェクトに。第二引数をfalseにすることで、子オブジェクトにした際もスケールを維持。
		marker.transform.SetParent (compass.transform, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
