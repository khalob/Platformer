using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float rotationSpeed = 5;
	void Update () {
		if (!GameControl.control.Paused) {
			transform.Rotate (new Vector2 (0, 30) * Time.deltaTime * rotationSpeed);
		}
	}
}