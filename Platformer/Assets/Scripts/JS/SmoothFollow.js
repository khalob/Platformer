var target: Transform;
var distance = 10;
var height = 0;
var damping = 5.0;
var smoothRotation = false;
var rotationDamping = 10.0;
var lockRotation: boolean = true;
var lockCameraY: boolean;

function Update() {
	var wantedPosition = target.TransformPoint(0, height, -distance);
	transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);
	if (smoothRotation) {
		var wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
	} else transform.LookAt(target, target.up);
		if (lockRotation) {
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
}

function LateUpdate() {
	if (lockCameraY) {
		GetComponent. < Camera > ().main.transform.position.y = height;
	}
}