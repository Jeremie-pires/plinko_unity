using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Spawner : MonoBehaviour
{
    public float speed = 5f;
    public GameObject Bille;
    
    [Header("Limites de déplacement")]
    public float minX = -4.5f; 
    public float maxX = 4.5f;  
    
    [Header("Gestion des Tirs")]
    public int maxTirs = 10;
    public TextMeshProUGUI tirsTextComposant; 
    private int tirsRestants;
    private GameObject billeActuelle; 

    [Header("Audio Spawner")]
    public AudioClip dropSound;
    private AudioSource audioSource;

    [Header("Inputs")]
    public InputActionReference moveAction;
    public InputActionReference spawnAction;

    void Start()
    {
        tirsRestants = maxTirs;
        MettreAJourUiTirs();
        
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontalInput = moveAction.action.ReadValue<Vector2>().x;
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        
        float xBloque = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(xBloque, transform.position.y, transform.position.z);

        if (spawnAction.action.WasPressedThisFrame())
        {
            if (tirsRestants > 0 && billeActuelle == null)
            {
                billeActuelle = Instantiate(Bille, transform.position, Quaternion.identity);
                
                if (dropSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(dropSound);
                }

                tirsRestants--;
                MettreAJourUiTirs();
            }
        }
    }

    void MettreAJourUiTirs()
    {
        if (tirsTextComposant != null)
        {
            tirsTextComposant.text = "Billes : " + tirsRestants;
        }
    }
}