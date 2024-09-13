using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f; // Speed of movement

	void Update()
	{
		// Get input from keyboard
		float moveX = Input.GetAxis("Horizontal"); // For left and right movement (A/D or LeftArrow/RightArrow)
		float moveZ = Input.GetAxis("Vertical");   // For forward and backward movement (W/S or UpArrow/DownArrow)

		// Create a movement vector
		Vector3 move = new Vector3(moveX, 0f, moveZ);

		// Apply movement to the player
		transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
	}
}
