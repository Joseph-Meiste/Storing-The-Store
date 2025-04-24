using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public GameObject TargetItem;
    public GameObject Body;

    public NavMeshAgent Customer;

    public Animator Animator;

    public bool ItemReached;
    public bool ItemFound;
    public bool CheckedOut;

    ItemRandomizer ItemRandomizer;
    TimeTracker Timer;

    private string Direction;

    private void Awake()
    {
        ItemRandomizer = FindObjectOfType<ItemRandomizer>();
        Timer = FindObjectOfType<TimeTracker>();
    }

    public void FindPath()
    {
        string Item = ItemRandomizer.Item;
        TargetItem = GameObject.Find(Item);
        ItemReached = false;
        ItemFound = false;
    }

    public void Update()
    {
        if (!ItemReached)
        {
            MoveToShelf();
            CheckIfReachedItem();
        }
        if (ItemReached)
        {
            GoToCheckOut();
            //Animator.SetTrigger("Search");
            CheckIfReachedCheckOut();
        }

        if (CheckedOut)
        {
            GoToTheExit();
            CheckIfReachedExit();
        }
    }
    
    public void GoToCheckOut()
    {
        int CheckOut = UnityEngine.Random.Range(1, 3);
        if (CheckOut == 1)
        {
            Direction = "Left";
            Customer.destination = GameObject.Find(Direction).transform.position;
        }
        else if (CheckOut == 2)
        {
            Direction = "Right";
            Customer.destination = GameObject.Find(Direction).transform.position;
        }
    }

    public void MoveToShelf()
    {
        if (TargetItem != null)
        {
            Customer.destination = TargetItem.transform.position;
        }
        else
        {
            Customer.destination = GameObject.Find("Spawn").transform.position;
            FindPath();
        }
    }

    /* public void Steal()
     {
         ItemRandomizer.Generate 
     }*/

    public void GoToTheExit()
    {
        Customer.destination = GameObject.Find("Exit").transform.position;
    }

    public void CheckIfReachedItem()
    {
        float distanceToItem = Vector3.Distance(Customer.transform.position, TargetItem.transform.position);

        if (distanceToItem < 0.5f)
        {
            ItemReached = true;
        }
    }

    public void CheckIfReachedCheckOut()
    {
        float distanceToCheckOut = Vector3.Distance(Customer.transform.position, GameObject.Find(Direction).transform.position);

        if (distanceToCheckOut < 1f)
        {
            CheckedOut = true;
        }
    }

    public void CheckIfReachedExit()
    {
        float distanceToCheckOut = Vector3.Distance(Customer.transform.position, GameObject.Find("Exit").transform.position);

        if (distanceToCheckOut < 1f)
        {
            Timer.IncrementInt();
            Destroy(Body);
        }
    }
}