//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Collision : MonoBehaviour
//{
//    public GameObject car; // Reference to the car GameObject
//    public GameObject character; // Reference to the static character
//    public GameObject outline; // Reference to the static character
//    public float moveSpeed = 2f; // Speed at which the character moves towards the car
//    public float range = 0.1f; // Speed at which the character moves towards the car
//    public Animator animator;

//    private bool isMovingTowardsCar = false;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (isMovingTowardsCar)
//        {
//            MoveCharacterTowardsCar();
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.CompareTag("Player"))
//        {
//            Debug.Log("Car");
//            isMovingTowardsCar = true;
//            animator.SetBool("isRun", true);
//            Destroy(outline.gameObject, 1.5f);
//        }
//    }

//    // Function to move the character towards the car
//    void MoveCharacterTowardsCar()
//    {
//        // Calculate the step based on moveSpeed and deltaTime
//        float step = moveSpeed * Time.deltaTime;

//        // Move the character towards the car's position
//        character.transform.position = Vector3.MoveTowards(character.transform.position, car.transform.position, step);

//        // Check if the character has reached the car
//        if (Vector3.Distance(character.transform.position, car.transform.position) < range)
//        {
//            // Re-parent the character to the car
//            character.transform.SetParent(car.transform);

//            // Stop moving the character
//            isMovingTowardsCar = false;

//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject car; // Reference to the car GameObject
    public GameObject character; // Reference to the static character
    public GameObject outline; // Reference to the outline circle
    public float moveSpeed = 2f; // Speed at which the character moves towards the car
    public float range = 0.1f; // Range at which the character attaches to the car
    public Animator animator;

    private bool isMovingTowardsCar = false;
    private CarChildCheck carChildCheck;

    // Start is called before the first frame update
    void Start()
    {
        // Get the CarChildCheck script from the car
        carChildCheck = car.GetComponent<CarChildCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingTowardsCar)
        {
            MoveCharacterTowardsCar();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if the car has space and does not already contain this specific character
            if (!carChildCheck.IsCarFull() && !carChildCheck.DoesCarContainCharacter(character))
            {
                Debug.Log("Car has space. Moving character towards car.");
                isMovingTowardsCar = true;
                animator.SetBool("isRun", true);
                Destroy(outline.gameObject, 1.5f);
            }
            else
            {
                Debug.Log("Car is full or already has this character.");
            }
        }
    }

    // Function to move the character towards the car
    void MoveCharacterTowardsCar()
    {
        // Calculate the step based on moveSpeed and deltaTime
        float step = moveSpeed * Time.deltaTime;

        // Move the character towards the car's position
        character.transform.position = Vector3.MoveTowards(character.transform.position, car.transform.position, step);

        // Check if the character has reached the car
        if (Vector3.Distance(character.transform.position, car.transform.position) < range)
        {
            // Re-parent the character to the car
            character.transform.SetParent(car.transform);

            // Notify the car to add the character to its list
            carChildCheck.AddCharacter(character);

            // Stop moving the character
            isMovingTowardsCar = false;
        }
    }
}

