using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 衝突すると、表示する
public class OnCollisionShow : MonoBehaviour 
{
	//-------------------------------------
	public GameObject targetObject; //［目標オブジェクト］
	public string tagName; //［タグ名］
	public GameObject showObject; //［表示するオブジェクト］
	//-------------------------------------

	void Start()
	{
		if (showObject != null)
		{
			showObject.SetActive(false); // 非表示にする
		}
	}

	void OnCollisionEnter2D(Collision2D collision) { // 衝突したとき
		if (showObject == null) return;

		// 衝突したものが、目標オブジェクトか、タグ名なら
		if (collision.gameObject == targetObject ||
			collision.gameObject.tag == tagName) 
		{
			var cameraManager = FindFirstObjectByType<CameraManager>();
			if (cameraManager != null)
			{
				cameraManager.hetakusosennyouMode = cameraManager.hetakusosennyouMode - 100000000; // 弱者救済モードを有効にする
				Debug.Log("hetakusosennyouMode: " + cameraManager.hetakusosennyouMode);
				if (cameraManager.hetakusosennyouMode <= 0)
				{
					showObject.SetActive(true); // 表示する
				}
			}
		}
	}
}
