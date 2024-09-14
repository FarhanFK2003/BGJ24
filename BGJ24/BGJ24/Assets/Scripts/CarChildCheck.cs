//using UnityEngine;

//public class CarChildCheck : MonoBehaviour
//{
//    //public GameObject character; // Reference to the static character

//    // Update is called once per frame
//    void Update()
//    {
//        CheckIfCharacterIsInCar();
//    }

//    // Function to check if the character is a child of the car
//    void CheckIfCharacterIsInCar()
//    {
//        foreach (Transform child in transform)
//        {
//            if (child.gameObject.CompareTag("Character"))
//            {
//                Debug.Log("Character is already in the car.");
//                child.gameObject.SetActive(false);
//                return;
//            }
//        }

//        Debug.Log("Character is not in the car.");
//    }
//}


//using System.Collections.Generic;
//using UnityEngine;

//public class CarChildCheck : MonoBehaviour
//{
//    public int maxCapacity = 4; // Maximum number of characters the car can hold
//    private List<GameObject> charactersInCar = new List<GameObject>(); // List to store the characters added to the car

//    // Check if the car is at full capacity
//    public bool IsCarFull()
//    {
//        return charactersInCar.Count >= maxCapacity;
//    }

//    // Function to add a character to the car
//    public void AddCharacter(GameObject character)
//    {
//        if (!IsCarFull())
//        {
//            charactersInCar.Add(character);
//            Debug.Log("Character added to car. Current capacity: " + charactersInCar.Count);

//            // Deactivate the character but keep it in the list for future use
//            character.SetActive(false);
//        }
//        else
//        {
//            Debug.Log("Car is at full capacity. Cannot add more characters.");
//        }
//    }

//    // Function to remove a character from the car (optional)
//    public void RemoveCharacter(GameObject character)
//    {
//        if (charactersInCar.Contains(character))
//        {
//            charactersInCar.Remove(character);
//            Debug.Log("Character removed from car. Current capacity: " + charactersInCar.Count);
//        }
//    }

//    // Check if the car already contains a character
//    public bool DoesCarContainCharacter(GameObject character)
//    {
//        return charactersInCar.Contains(character);
//    }

//    // Function to reactivate and return a specific character from the car
//    public GameObject RetrieveCharacter()
//    {
//        if (charactersInCar.Count > 0)
//        {
//            GameObject retrievedCharacter = charactersInCar[0]; // Get the first character in the list
//            charactersInCar.RemoveAt(0); // Remove it from the list
//            retrievedCharacter.SetActive(true); // Reactivate the character
//            return retrievedCharacter;
//        }
//        Debug.Log("No characters to retrieve from the car.");
//        return null;
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CarChildCheck : MonoBehaviour
//{
//    public int maxCapacity = 4; // Maximum number of characters the car can hold
//    private List<GameObject> charactersInCar = new List<GameObject>(); // List to store the characters added to the car

//    // Check if the car is at full capacity
//    public bool IsCarFull()
//    {
//        return charactersInCar.Count >= maxCapacity;
//    }

//    // Function to add a character to the car
//    public void AddCharacter(GameObject character)
//    {
//        if (!IsCarFull())
//        {
//            charactersInCar.Add(character);
//            Debug.Log("Character added to car. Current capacity: " + charactersInCar.Count);

//            // Deactivate the character but keep it in the list for future use
//            character.SetActive(false);
//        }
//        else
//        {
//            Debug.Log("Car is at full capacity. Cannot add more characters.");
//        }
//    }

//    // Check if the car already contains a character
//    public bool DoesCarContainCharacter(GameObject character)
//    {
//        return charactersInCar.Contains(character);
//    }

//    // Function to activate all characters and move them towards the rocket
//    public void ActivateAndMoveCharactersTowardsRocket(GameObject rocket)
//    {
//        foreach (GameObject character in charactersInCar)
//        {
//            if (character != null)
//            {
//                character.SetActive(true); // Reactivate the character
//                StartCoroutine(MoveCharacterToRocket(character, rocket)); // Start moving the character towards the rocket
//            }
//        }
//    }

//    // Coroutine to move a character towards the rocket
//    private IEnumerator MoveCharacterToRocket(GameObject character, GameObject rocket)
//    {
//        float moveSpeed = 2f; // Set a move speed
//        while (Vector3.Distance(character.transform.position, rocket.transform.position) > 0.1f)
//        {
//            // Move the character towards the rocket
//            character.transform.position = Vector3.MoveTowards(character.transform.position, rocket.transform.position, moveSpeed * Time.deltaTime);
//            yield return null;
//        }

//        Debug.Log(character.name + " reached the rocket.");
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CarChildCheck : MonoBehaviour
//{
//    public int maxCapacity = 4; // Maximum number of characters the car can hold
//    private List<GameObject> charactersInCar = new List<GameObject>(); // List to store the characters added to the car

//    // Check if the car is at full capacity
//    public bool IsCarFull()
//    {
//        return charactersInCar.Count >= maxCapacity;
//    }

//    // Function to add a character to the car
//    public void AddCharacter(GameObject character)
//    {
//        if (!IsCarFull())
//        {
//            charactersInCar.Add(character);
//            Debug.Log("Character added to car. Current capacity: " + charactersInCar.Count);

//            // Deactivate the character but keep it in the list for future use
//            character.SetActive(false);
//        }
//        else
//        {
//            Debug.Log("Car is at full capacity. Cannot add more characters.");
//        }
//    }

//    // Check if the car already contains a character
//    public bool DoesCarContainCharacter(GameObject character)
//    {
//        return charactersInCar.Contains(character);
//    }

//    // Function to activate all characters and move them towards the rocket
//    public void ActivateAndMoveCharactersTowardsRocket(GameObject rocket)
//    {
//        List<GameObject> charactersToRemove = new List<GameObject>(); // List to hold characters that need to be removed

//        foreach (GameObject character in charactersInCar)
//        {
//            if (character != null)
//            {
//                character.SetActive(true); // Reactivate the character
//                StartCoroutine(MoveCharacterToRocket(character, rocket, charactersToRemove)); // Start moving the character towards the rocket
//            }
//        }

//        // Remove characters after they've been destroyed
//        StartCoroutine(RemoveDestroyedCharacters(charactersToRemove));
//    }

//    // Coroutine to move a character towards the rocket
//    private IEnumerator MoveCharacterToRocket(GameObject character, GameObject rocket, List<GameObject> charactersToRemove)
//    {
//        float moveSpeed = 2f; // Set a move speed
//        while (Vector3.Distance(character.transform.position, rocket.transform.position) > 0.1f)
//        {
//            // Move the character towards the rocket
//            character.transform.position = Vector3.MoveTowards(character.transform.position, rocket.transform.position, moveSpeed * Time.deltaTime);
//            yield return null;
//        }

//        Debug.Log(character.name + " reached the rocket and is being destroyed.");
//        charactersToRemove.Add(character); // Add the character to the list for removal

//        Destroy(character); // Destroy the character after reaching the rocket
//    }

//    // Coroutine to remove characters from the car's list after they are destroyed
//    private IEnumerator RemoveDestroyedCharacters(List<GameObject> charactersToRemove)
//    {
//        yield return new WaitForEndOfFrame(); // Wait for the current frame to finish

//        foreach (GameObject character in charactersToRemove)
//        {
//            if (charactersInCar.Contains(character))
//            {
//                charactersInCar.Remove(character);
//                Debug.Log(character.name + " has been removed from the car.");
//            }
//        }
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CarChildCheck : MonoBehaviour
//{
//    public int maxCapacity = 4; // Maximum number of characters the car can hold
//    private List<GameObject> charactersInCar = new List<GameObject>(); // List to store the characters added to the car

//    // Check if the car is at full capacity
//    public bool IsCarFull()
//    {
//        return charactersInCar.Count >= maxCapacity;
//    }

//    // Function to add a character to the car
//    public void AddCharacter(GameObject character)
//    {
//        if (!IsCarFull())
//        {
//            charactersInCar.Add(character);
//            Debug.Log("Character added to car. Current capacity: " + charactersInCar.Count);

//            // Deactivate the character but keep it in the list for future use
//            character.SetActive(false);
//        }
//        else
//        {
//            Debug.Log("Car is at full capacity. Cannot add more characters.");
//        }
//    }

//    // Check if the car already contains a character
//    public bool DoesCarContainCharacter(GameObject character)
//    {
//        return charactersInCar.Contains(character);
//    }

//    // Function to activate all characters and move them towards the rocket
//    public void ActivateAndMoveCharactersTowardsRocket(GameObject rocket)
//    {
//        List<GameObject> charactersToRemove = new List<GameObject>(); // List to hold characters that need to be removed

//        foreach (GameObject character in charactersInCar)
//        {
//            if (character != null)
//            {
//                character.SetActive(true); // Reactivate the character

//                // Unparent the character from the car
//                character.transform.SetParent(null);

//                // Start moving the character towards the rocket
//                StartCoroutine(MoveCharacterToRocket(character, rocket, charactersToRemove));
//            }
//        }

//        // Remove characters after they've been destroyed
//        StartCoroutine(RemoveDestroyedCharacters(charactersToRemove));
//    }

//    // Coroutine to move a character towards the rocket
//    private IEnumerator MoveCharacterToRocket(GameObject character, GameObject rocket, List<GameObject> charactersToRemove)
//    {
//        float moveSpeed = 2f; // Set a move speed
//        while (Vector3.Distance(character.transform.position, rocket.transform.position) > 0.1f)
//        {
//            // Move the character towards the rocket
//            character.transform.position = Vector3.MoveTowards(character.transform.position, rocket.transform.position, moveSpeed * Time.deltaTime);
//            yield return null;
//        }

//        Debug.Log(character.name + " reached the rocket and is being destroyed.");
//        charactersToRemove.Add(character); // Add the character to the list for removal

//        Destroy(character); // Destroy the character after reaching the rocket
//    }

//    // Coroutine to remove characters from the car's list after they are destroyed
//    private IEnumerator RemoveDestroyedCharacters(List<GameObject> charactersToRemove)
//    {
//        yield return new WaitForEndOfFrame(); // Wait for the current frame to finish

//        foreach (GameObject character in charactersToRemove)
//        {
//            if (charactersInCar.Contains(character))
//            {
//                charactersInCar.Remove(character);
//                Debug.Log(character.name + " has been removed from the car.");
//            }
//        }
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CarChildCheck : MonoBehaviour
//{
//    public int maxCapacity = 4; // Maximum number of characters the car can hold
//    private List<GameObject> charactersInCar = new List<GameObject>(); // List to store the characters added to the car

//    // Check if the car is at full capacity
//    public bool IsCarFull()
//    {
//        return charactersInCar.Count >= maxCapacity;
//    }

//    // Function to add a character to the car
//    public void AddCharacter(GameObject character)
//    {
//        if (!IsCarFull())
//        {
//            charactersInCar.Add(character);
//            Debug.Log("Character added to car. Current capacity: " + charactersInCar.Count);

//            // Deactivate the character but keep it in the list for future use
//            character.SetActive(false);
//        }
//        else
//        {
//            Debug.Log("Car is at full capacity. Cannot add more characters.");
//        }
//    }

//    // Check if the car already contains a character
//    public bool DoesCarContainCharacter(GameObject character)
//    {
//        return charactersInCar.Contains(character);
//    }

//    // Function to activate all characters and move them towards the rocket
//    public void ActivateAndMoveCharactersTowardsRocket(GameObject rocket)
//    {
//        List<GameObject> charactersToRemove = new List<GameObject>(); // List to hold characters that need to be removed

//        foreach (GameObject character in charactersInCar)
//        {
//            if (character != null)
//            {
//                character.SetActive(true); // Reactivate the character

//                // Unparent the character from the car
//                character.transform.SetParent(null);

//                // Start moving the character towards the rocket
//                StartCoroutine(MoveCharacterToRocket(character, rocket, charactersToRemove));
//            }
//        }

//        // Remove characters after they've been destroyed
//        StartCoroutine(RemoveDestroyedCharacters(charactersToRemove));
//    }

//    // Coroutine to move a character towards the rocket
//    private IEnumerator MoveCharacterToRocket(GameObject character, GameObject rocket, List<GameObject> charactersToRemove)
//    {
//        float moveSpeed = 2f; // Set a move speed

//        // Get the Animator component from the character and set "isRun" to true
//        Animator characterAnimator = character.GetComponent<Animator>();
//        if (characterAnimator != null)
//        {
//            characterAnimator.SetBool("isRun", true); // Start the running animation
//        }

//        while (Vector3.Distance(character.transform.position, rocket.transform.position) > 0.1f)
//        {
//            // Move the character towards the rocket
//            character.transform.position = Vector3.MoveTowards(character.transform.position, rocket.transform.position, moveSpeed * Time.deltaTime);
//            yield return null;
//        }

//        Debug.Log(character.name + " reached the rocket and is being destroyed.");
//        charactersToRemove.Add(character); // Add the character to the list for removal

//        Destroy(character); // Destroy the character after reaching the rocket
//    }

//    // Coroutine to remove characters from the car's list after they are destroyed
//    private IEnumerator RemoveDestroyedCharacters(List<GameObject> charactersToRemove)
//    {
//        yield return new WaitForEndOfFrame(); // Wait for the current frame to finish

//        foreach (GameObject character in charactersToRemove)
//        {
//            if (charactersInCar.Contains(character))
//            {
//                charactersInCar.Remove(character);
//                Debug.Log(character.name + " has been removed from the car.");
//            }
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChildCheck : MonoBehaviour
{
    public int maxCapacity = 4; // Maximum number of characters the car can hold
    private List<GameObject> charactersInCar = new List<GameObject>(); // List to store the characters added to the car

    // Check if the car is at full capacity
    public bool IsCarFull()
    {
        return charactersInCar.Count >= maxCapacity;
    }

    // Function to add a character to the car
    public void AddCharacter(GameObject character)
    {
        if (!IsCarFull())
        {
            charactersInCar.Add(character);
            Debug.Log("Character added to car. Current capacity: " + charactersInCar.Count);

            // Deactivate the character but keep it in the list for future use
            character.SetActive(false);
        }
        else
        {
            Debug.Log("Car is at full capacity. Cannot add more characters.");
        }
    }

    // Check if the car already contains a character
    public bool DoesCarContainCharacter(GameObject character)
    {
        return charactersInCar.Contains(character);
    }

    // Function to activate all characters and move them towards the rocket
    public void ActivateAndMoveCharactersTowardsRocket(GameObject rocket)
    {
        StartCoroutine(MoveCharactersTowardsRocket(rocket));
    }

    // Coroutine to move all characters towards the rocket
    private IEnumerator MoveCharactersTowardsRocket(GameObject rocket)
    {
        float moveSpeed = 2f; // Set a move speed

        // Iterate over a copy of the list to avoid modifying the list while iterating
        foreach (GameObject character in new List<GameObject>(charactersInCar))
        {
            if (character != null)
            {
                character.SetActive(true); // Reactivate the character

                // Unparent the character from the car
                character.transform.SetParent(null);

                // Move the character towards the rocket
                yield return StartCoroutine(MoveCharacterToRocket(character, rocket));
            }
        }
    }

    // Coroutine to move a character towards the rocket
    private IEnumerator MoveCharacterToRocket(GameObject character, GameObject rocket)
    {
        float moveSpeed = 2f; // Set a move speed

        // Get the Animator component from the character and set "isRun" to true
        Animator characterAnimator = character.GetComponent<Animator>();
        if (characterAnimator != null)
        {
            characterAnimator.SetBool("isRun", true); // Start the running animation
        }

        while (Vector3.Distance(character.transform.position, rocket.transform.position) > 0.1f)
        {
            // Move the character towards the rocket
            character.transform.position = Vector3.MoveTowards(character.transform.position, rocket.transform.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Debug.Log(character.name + " reached the rocket and is being destroyed.");

        // Remove the character from the car's list and destroy it
        charactersInCar.Remove(character);
        Destroy(character); // Destroy the character after reaching the rocket
    }
}

