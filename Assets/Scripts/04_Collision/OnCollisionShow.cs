using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 衝突すると、表示する
public class OnCollisionShow : MonoBehaviour 
{
	//-------------------------------------
	public GameObject targetObject; //［目標オブジェクト］
	public string tagName; //［タグ名］
	public GameObject showObject; //［表示するオブジェクト］
	private GameObject gameoverObject;
	private CameraManager cameraManager;
	private GameObject myCharObject;
	//-------------------------------------

	void Start()
	{
		myCharObject = GameObject.Find("block_09_0");
		gameoverObject = GameObject.Find("gameover_0");

		cameraManager = FindFirstObjectByType<CameraManager>();
		Debug.Assert(cameraManager != null, "CameraManager not found in the scene.");

		if (showObject != null)
		{
			showObject.SetActive(false); // 非表示にする
		}
	}
	void AddHP(int amount, bool dead = false)
	{
		if (cameraManager != null)
		{
			cameraManager.hetakusosennyouMode += amount;
			Debug.Log("hetakusosennyouMode: " + cameraManager.hetakusosennyouMode);

			if (cameraManager.hetakusosennyouMode <= 0 || dead)
			{
				cameraManager.hetakusosennyouMode = 0;
				Debug.Log("hetakusosennyouMode: " + cameraManager.hetakusosennyouMode);
				if (gameoverObject != null)
				{
					gameoverObject.SetActive(true); // ゲームオーバーを表示する
					myCharObject.SetActive(false); // 自分のキャラクターを非表示にする
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) { // 衝突したとき
		if (showObject == null && gameoverObject == null) return;

		if (tagName == "gameclear") // ゲームクリア
		{
			showObject.SetActive(true); // 表示する
			myCharObject.SetActive(false); // 自分のキャラクターを非表示にする
		}

		// 衝突したものが、目標オブジェクトか、タグ名なら
		if (collision.gameObject.tag == "enemy") // 敵に当たったら（赤い樽、茶色の樽）
		{
			AddHP(-100000000);
		}
		else if (collision.gameObject.tag == "friend") // 友達に当たったら、弱者救済モードを増やす
		{
			AddHP(1);
		}
		else if (collision.gameObject.tag == "family" || collision.gameObject.tag == "family2") // 即死
		{
			AddHP(0, true);
		}
	}
}
