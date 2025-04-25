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
    public bool Angry;

    ItemRandomizer ItemRandomizer;
    ValueHolder Holder;
    RandomEvent RandomEvent;

    private string Direction;

    private void Awake()
    {
        animator = Body.GetComponent<Animator>();
        ItemRandomizer = FindObjectOfType<ItemRandomizer>();
        RandomEvent = FindObjectOfType<RandomEvent>();
        Holder = FindObjectOfType<ValueHolder>();
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

    public void FindPath()
    {
        string Item = ItemRandomizer.Item;
        TargetItem = GameObject.Find(Item);
        ItemReached = false;
        ItemFound = false;
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
                Vector3 targetEuler = TargetItem.transform.eulerAngles;
                Vector3 customerEuler = Customer.transform.eulerAngles;

                Quaternion targetRotation = Quaternion.Euler(customerEuler.x, targetEuler.y, customerEuler.z);
                Customer.transform.rotation = Quaternion.RotateTowards(Customer.transform.rotation, targetRotation, 180f * Time.deltaTime);

                float angleDifference = Quaternion.Angle(Customer.transform.rotation, targetRotation);
                if (angleDifference < 5f)
                {
                    animator.SetTrigger("ReadyToSearch");
                    ItemReached = true;
                }
            }
        }
    }

    public void TryTakeItem()
    {
        CheckOverLoad targetShelf = GameObject.Find(ItemRandomizer.Item).GetComponent<CheckOverLoad>();

        ItemFound = targetShelf.TakeItem();
        Debug.Log(ItemFound);

        if (ItemFound == true)
        {
            GrabItem();
        }
        else
        {
            BadEvent();
        }
    }

    public void GrabItem()
    {
        animator.SetTrigger("IsItemFound");
    }

    public void BadEvent()
    {
        Angry = true;
        Customer.speed = 10f;
        Holder.AddAngryCustomer();
        //Grab 2 items rather than 1 , throws 3 trash, break a light; 
        int Random = UnityEngine.Random.Range(1, 4);
        switch (Random)
        {
            case 1:
                for (int loop = 0; loop <= 2; loop++)
                {
                    ItemRandomizer.FindItem();
                }
                break;
            case 2:
                for (int loop = 0; loop <= 3; loop++)
                {
                    RandomEvent.SpawnTrash();
                }
                break;
            case 3:
                RandomEvent.BreakLight();
                break;
        }
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
            Holder.IncrementInt();
            Destroy(Object);
        }
    }
}