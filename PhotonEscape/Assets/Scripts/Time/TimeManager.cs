using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public static void AlterTime(float actualTime) {
		Time.timeScale = actualTime;
	}
}
