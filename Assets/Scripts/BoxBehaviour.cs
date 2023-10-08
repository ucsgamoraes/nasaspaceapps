using UnityEngine;
using UnityEngine.Events;

public class BoxBehaviour : MonoBehaviour
{
    public UnityEvent onInteraction;

    public string playerTag = "Player";
    public GameObject interactionUI;
    public Animator boxAnimator;
    private bool playerInRange = false;
    public AudioClip newItemSound;
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInRange = true;
            interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInRange = false;
            interactionUI.SetActive(false);
        }
    }

    private void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Play sound by name
    public void PlaySound(string soundName)
    {
        audioSource.PlayOneShot(newItemSound);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Trigger the box opening animation
            if (boxAnimator != null)
            {
                boxAnimator.SetTrigger("OpenBox");
            }

            // Trigger the interaction UnityEvent
            onInteraction.Invoke();

            // Add any other interaction logic here

            // Optional: Disable the interaction UI after interacting
            interactionUI.SetActive(false);
        }
    }
}
