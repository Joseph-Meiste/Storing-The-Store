using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Progress;

public class PathFinding : MonoBehaviour
{
    public GameObject TargetItem;
    public GameObject Body;
    public GameObject Object;

    public NavMeshAgent Customer;

    public Animator animator;

    public bool ItemReached;
    public bool ReadyForCheckOut;
    public bool CheckOutReached;
    public bool ItemFound;
    public bool CheckedOut;

    ItemRandomizer ItemRandomizer;
    TimeTracker Timer;

    private string Direction;

    private void Awake()
    {
        animator = Body.GetComponent<Animator>(); ;
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

        if (ReadyForCheckOut)
        {
            GoToCheckOut();
            CheckIfReachedCheckOut();
        }

        if (CheckedOut)
        {
            GoToTheExit();
            CheckIfReachedExit();
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
    public void CheckIfReachedItem()
    {
        if (!ItemReached)
        {
            float distanceToItem = Vector3.Distance(Customer.transform.position, TargetItem.transform.position);

            if (distanceToItem < 0.5f)
            {
                animator.SetTrigger("ReadyToSearch");
                ItemReached = true;
            }
        }
    }
    public void TryTakeItem()
    {
        CheckOverLoad targetShelf = GameObject.Find(ItemRandomizer.Item).GetComponent<CheckOverLoad>();
        ItemFound = targetShelf.TakeItem();

        if (ItemFound) { TakeItem(); }
        else { Steal(); };
    }
    public void TakeItem()
    {
        animator.SetTrigger("IsItemFound");
    }
    public void Steal()
    {
        Debug.Log("Steal");
    }
    public void GoToCheckOut()
    {
        if (!CheckedOut)
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
    }
    public void CheckIfReachedCheckOut()
    {
        float distanceToCheckOut = Vector3.Distance(Customer.transform.position, GameObject.Find(Direction).transform.position);

        if (distanceToCheckOut < 1f)
        {
            CheckedOut = true;
        }
    }
    public void GoToTheExit()
    {
        Customer.destination = GameObject.Find("Exit").transform.position;
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