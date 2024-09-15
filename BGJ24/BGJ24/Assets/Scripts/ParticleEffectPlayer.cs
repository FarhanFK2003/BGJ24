using UnityEngine;

public class ParticleEffectPlayer : MonoBehaviour
{
    public ParticleSystem particleEffect; // Reference to the particle system

    void Start()
    {
        //// Optionally, you can stop the particle system at the start if it's set to Play on Awake
        //if (particleEffect.isPlaying)
        //{
        //    particleEffect.Stop();
        //}
    }

    void Update()
    {
        // Example: Play the particle effect when the space key is pressed
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        PlayParticleEffect();
        //}
    }

    // Function to play the particle effect
    public void PlayParticleEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.Play();
        }
        else
        {
            Debug.LogWarning("Particle system reference is missing!");
        }
    }

    // Optional function to stop the particle effect
    public void StopParticleEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.Stop();
        }
    }
}


//using UnityEngine;

//public class ParticleEffectSpawner : MonoBehaviour
//{
//    public GameObject particlePrefab; // Prefab of the particle system
//    public Transform spawnLocation;   // The location where the particle effect should be instantiated

//    void Update()
//    {
//        // Example: Instantiate the particle effect when the space key is pressed
//        //if (Input.GetKeyDown(KeyCode.Space))
//        //{
//            SpawnParticleEffect();
//        //}
//    }

//    // Function to instantiate and play the particle effect
//    public void SpawnParticleEffect()
//    {
//        if (particlePrefab != null && spawnLocation != null)
//        {
//            // Instantiate the particle system prefab at the specified location
//            GameObject particleInstance = Instantiate(particlePrefab, spawnLocation.position, spawnLocation.rotation);

//            // Optionally, destroy the particle effect after its duration
//            Destroy(particleInstance, particleInstance.GetComponent<ParticleSystem>().main.duration);
//        }
//        else
//        {
//            Debug.LogWarning("Missing particlePrefab or spawnLocation reference!");
//        }
//    }
//}
