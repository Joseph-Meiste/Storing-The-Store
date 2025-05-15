using UnityEngine;

public class RandomEvent : MonoBehaviour
{
    public float TrashCoolDownTimer;
    public float TrashCoolDown;
    public string TrashBox;

    public GameObject TrashPile;
    public GameObject TrashFolderPrefab;

    PathFinding pathFinding;
    Transform TrashFolder;
    ValueHolder Holder;

    private int TrashCount;

    void Awake()
    {
        Holder = FindObjectOfType<ValueHolder>();
        pathFinding = FindObjectOfType<PathFinding>();
        TrashFolder = FindObjectOfType<FindTrash>()?.transform ?? Instantiate(TrashFolderPrefab).transform;
        UpdateText();
        TrashCoolDownTimer = Random.Range(-3f, 0f);
    }

    void Update()
    {
        if (pathFinding.Trash)
        {
            TrashCoolDownTimer += Time.deltaTime;

            if (TrashCoolDownTimer >= TrashCoolDown)
            {
                Trash();
                TrashCoolDownTimer = Random.Range(-2f, 0f);
            }
        }
    }

    private void UpdateText()
    {
        TrashBox = "I placed " + TrashCount + " trash!";
    }

    private void Trash()
    {
        if (Random.Range(0, 15) == 1)
        {
            SpawnTrash();
            UpdateText();
        }
    }

    public void SpawnTrash()
    {
        Instantiate(
            TrashPile,
            pathFinding.Customer.transform.position + new Vector3(0f, -.3f, 0f),
            pathFinding.Customer.transform.rotation,
            TrashFolder
        );
        TrashCount++;
        Holder.AddTrashCounter();
    }
}