using UnityEngine;

public class TrashCollection : MonoBehaviour, IInteractable
{
    public string Message;
    public bool interaction { get; set; }

    private ValueHolder holder;
    private FirstPersonController playerMovement;  
    public float slowdownFactor = 0.5f;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Camera/Player");
        playerMovement = player.GetComponent<FirstPersonController>(); 
        holder = GameObject.Find("Map").GetComponent<ValueHolder>();
    }

    public void Interact()
    {
        holder.MinusTrashCounter();
        playerMovement.walkSpeed = 5;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.walkSpeed = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.walkSpeed = 5;
        }
    }
}
