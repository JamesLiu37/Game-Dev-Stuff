using UnityEngine;
using System.Collections;

public class CamCtrlKBm : MonoBehaviour {

    public float speed = 0.1f;
    public float sensitivity = 3.0f;
    private float lookSideways = 0.0f;
    private float lookVertical = 0.0f;
	// Use this for initialization
	void Start () {
	    // TODO: detect if VIVE headset or controllers are connected
		// if so, disable keyboard movement and mouse look
		// presence of VIVE devices will mess this script up

		// TODO: Collision with other objects and restrict movement to Nav-Mesh

		Cursor.visible = false; // mouse invisible only in the game window
	}

	// Update is called once per frame
	void Update () {
		// Keyboard Movement - Relative to Camera Direction
		float angRad = (transform.eulerAngles.y * Mathf.PI) / 180.0f; // angle in radians
		float forwardInput = Input.GetAxis("Vertical");
		float sidewaysInput = Input.GetAxis("Horizontal");
		// Forward/Back : z-axis
		float z = forwardInput * Mathf.Cos(angRad) + sidewaysInput * Mathf.Cos(angRad + Mathf.PI / 2);
		// Left/Right : x-axis
		float x = forwardInput * Mathf.Sin(angRad) + sidewaysInput * Mathf.Sin(angRad + Mathf.PI / 2);
		Vector3 move = new Vector3(x, 0.0f, z);
		transform.position += move * speed;

		// Mouse Look
		lookSideways += sensitivity * Input.GetAxis("Mouse X");
		lookVertical -= sensitivity * Input.GetAxis("Mouse Y");
		print(transform.eulerAngles.y);
        transform.eulerAngles = new Vector3(lookVertical, lookSideways, 0.0f);
	}
}