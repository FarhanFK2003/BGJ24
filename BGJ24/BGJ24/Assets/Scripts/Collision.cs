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

using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject car; // Reference to the car GameObject
    public GameObject character; // Reference to the static character
    public GameObject outline; // Reference to the outline circle
    public float moveSpeed = 2f; // Speed at which the character moves towards the car
    public float range = 0.1f; // Range at which the character attaches to the car
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip clip;

    private bool isMovingTowardsCar = false;
    private CarChildCheck carChildCheck;

    // Start is called before the first frame update
    void Start()
    {
        // Get the CarChildCheck script from the car
        //carChildCheck = car.GetComponent<CarChildCheck>();

        car = GameObject.FindGameObjectWithTag("Player");
        if (car != null)
        {
            // Get the CarChildCheck script from the car
            carChildCheck = car.gameObject.GetComponent<CarChildCheck>();
        }

        if(audioSource != null)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
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
        //Debug.Log(""+other.gameObject.layer+" "+ other.transform.position);
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if the car has space and does not already contain this specific character
            if (!carChildCheck.IsCarFull() /*&& !carChildCheck.DoesCarContainCharacter(character)*/)
            {
                Debug.Log("Car has space. Moving character towards car.");
                audioSource.PlayOneShot(clip);
                isMovingTowardsCar = true;
                animator.SetBool("isRun", true);
                outline.SetActive(false);
                //Destroy(outline.gameObject, 1.5f);
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

        // Rotate the character to face the car
        Vector3 directionToCar = car.transform.position - character.transform.position;
        directionToCar.y = 0; // Keep the character upright (ignore vertical rotation)
        Quaternion targetRotation = Quaternion.LookRotation(directionToCar);

        // Smoothly rotate the character towards the car
        character.transform.rotation = Quaternion.Slerp(character.transform.rotation, targetRotation, step * 2);

        // Check if the character has reached the car
        if (Vector3.Distance(character.transform.position, car.transform.position) < range)
        {
            if (!carChildCheck.IsCarFull())
            {
                // Destroy the current parent of the character if it exists
                if (character.transform.parent != null)
                {
                    Destroy(character.transform.parent.gameObject);
                }

                // Re-parent the character to the car
                character.transform.SetParent(car.transform);

                // Notify the car to add the character to its list
                carChildCheck.AddCharacter(character);

                // Stop moving the character
                isMovingTowardsCar = false;
            }
            else
            {
                isMovingTowardsCar = false;
                animator.SetBool("isRun", false);
                outline.SetActive(true);
            }
        }
    }
}

