using UnityEngine;
using System.Collections;

public class TrashCollection : MonoBehaviour, IInteractable
{
    public string Message;
    public bool interaction { get; set; }

    private ValueHolder holder;
    private FirstPersonController playerMovement;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Camera/Player");
        playerMovement = player.GetComponent<FirstPersonController>();
        holder = GameObject.Find("Map").GetComponent<ValueHolder>();
    }

    public void Interact()
    {
        StartCoroutine(DelayedTrashInteraction());
    }

    private IEnumerator DelayedTrashInteraction()
    {
        holder.MinusTrashCounter();
        playerMovement.walkSpeed = 5;
        playerMovement.sprintSpeed = 7f;

        yield return new WaitForSeconds(.1f);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.walkSpeed = 1;
            playerMovement.sprintSpeed = 2.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.walkSpeed = 5;
            playerMovement.sprintSpeed = 7f;
        }
    }
}
