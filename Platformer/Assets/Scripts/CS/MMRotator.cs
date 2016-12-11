using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMRotator : MonoBehaviour {

	public float rotationSpeed = 5;
	void Update () {
		transform.Rotate (new Vector2 (0, 30) * Time.deltaTime * rotationSpeed);
	}
}
