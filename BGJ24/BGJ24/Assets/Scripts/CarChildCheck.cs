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

    // Function to remove a character from the car (optional)
    public void RemoveCharacter(GameObject character)
    {
        if (charactersInCar.Contains(character))
        {
            charactersInCar.Remove(character);
            Debug.Log("Character removed from car. Current capacity: " + charactersInCar.Count);
        }
    }

    // Check if the car already contains a character
    public bool DoesCarContainCharacter(GameObject character)
    {
        return charactersInCar.Contains(character);
    }

    // Function to reactivate and return a specific character from the car
    public GameObject RetrieveCharacter()
    {
        if (charactersInCar.Count > 0)
        {
            GameObject retrievedCharacter = charactersInCar[0]; // Get the first character in the list
            charactersInCar.RemoveAt(0); // Remove it from the list
            retrievedCharacter.SetActive(true); // Reactivate the character
            return retrievedCharacter;
        }
        Debug.Log("No characters to retrieve from the car.");
        return null;
    }
}

