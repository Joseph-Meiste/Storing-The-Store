using UnityEngine;

public class TrashCollection : MonoBehaviour, IInteractable
{
    public string Message;
    public bool interaction { get; set; }

    private ValueHolder holder;
    private FirstPersonController playerMovement;  
    public float slowdownFactor = 0.5f; 

    private float originalSpeed;  
    private void Awake()
    {
        holder = GameObject.Find("Map").GetComponent<ValueHolder>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<FirstPersonController>(); 
        originalSpeed = playerMovement.sprintSpeed; 
    }

    public void Interact()
    {
        holder.MinusTrashCounter();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.sprintSpeed *= slowdownFactor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.sprintSpeed = originalSpeed;
        }
    }
}
