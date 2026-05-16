using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ときどき、曲がる
public class SometimeTurn : MonoBehaviour 
{
	//-------------------------------------
	public float angle = 90; //［角度］
	public int maxCount = 50; //［頻度］
	//-------------------------------------
	int count = 0; // カウンター用

	void Start ()
	{
		count = 0;	// カウンターをリセット
	}

	void FixedUpdate()
	{
		count = count + 1; // カウンターに1を足して
		if (count >= maxCount)  // もし、maxCountになったら
		{
			int rand_angle = Random.Range(0, 360);
			transform.Rotate(0, 0, (float)rand_angle); // 回転して曲がる			
// 			transform.Rotate(0, 0, angle); // 回転して曲がる
			count = 0; // カウンターをリセット
		}
	}
}