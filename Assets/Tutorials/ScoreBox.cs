using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    [Header("Configuration de la case")]
    public int valeurPoints = 10; 
    
    public AudioClip winSound; 
    
    [Header("Effets Visuels")]
    public GameObject particulesPrefab; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bille"))
        {
            ScoreManager.instance.ModifierScore(valeurPoints);

            if (winSound != null && audioSource != null) 
            {
                audioSource.PlayOneShot(winSound);
            }

            if (particulesPrefab != null)
            {
                GameObject vfx = Instantiate(particulesPrefab, transform.position, Quaternion.identity);
                Destroy(vfx, 1f); 
            }

            Destroy(other.gameObject);
        }
    }
}