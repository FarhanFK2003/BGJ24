using UnityEngine;

public class OutlineCollision : MonoBehaviour
{
    public GameObject rocket; // Reference to the rocket GameObject inside the outline
    private CarChildCheck carChildCheck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Assuming the car is tagged as "Player"
        {
            Debug.Log("Car collided with the outline.");

            // Get the CarChildCheck script from the car
            carChildCheck = other.GetComponent<CarChildCheck>();

            if (carChildCheck != null)
            {
                // Activate all characters and move them towards the rocket
                carChildCheck.ActivateAndMoveCharactersTowardsRocket(rocket);
            }
        }
    }
}
