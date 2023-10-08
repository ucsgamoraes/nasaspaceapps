using UnityEngine;
using UnityEngine.Events;

public class TotenBehaviour : MonoBehaviour
{
    public UnityEvent onInteraction;

    public string playerTag = "Player";
    public GameObject interactionUI;
    public Animator boxAnimator;
    private bool playerInRange = false;
    public InventorySystem inv;
    public AudioClip newItemSound;
    private AudioSource audioSource;
    public Renderer objectRenderer;
    public Color newColor;

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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Play sound by name
    public void PlaySound()
    {
        audioSource.PlayOneShot(newItemSound);
    }

    public void Activate()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = newColor;
            PlaySound();
        }
        else
        {
            Debug.LogError("Renderer component not found on the object!");
        }
    }

    private void Update()
    {
        Debug.Log(inv.inventory["Tritium"].quantity);
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && inv.inventory["Tritium"].quantity > 0)
        {
            inv.RemoveOne("Tritium");
            Activate();
            onInteraction.Invoke();
            interactionUI.SetActive(false);
            inv.UpdateInventoryUI();
        }
    }
}
