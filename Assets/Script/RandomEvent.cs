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
    TimeTracker Timer;

    private int TrashCount;

    void Awake()
    {
        Timer = FindObjectOfType<TimeTracker>();
        pathFinding = FindObjectOfType<PathFinding>();
        TrashFolder = FindObjectOfType<FindTrash>()?.transform ?? Instantiate(TrashFolderPrefab).transform;
        UpdateText();
        TrashCoolDownTimer = Random.Range(-5f, 0f);
    }

    void Update()
    {
        TrashCoolDownTimer += Time.deltaTime;

        if (TrashCoolDownTimer >= TrashCoolDown)
        {
            Trash();
            TrashCoolDownTimer = Random.Range(-5f, 0f);
        }
    }

    private void UpdateText()
    {
        TrashBox = "I placed " + TrashCount + " trash!";
    }

    private void Trash()
    {
        if (Random.Range(1, 15) == 14)
        {
            Timer.AddTrashCounter();
            SpawnTrash();
            UpdateText();
        }
    }

    public void SpawnTrash()
    {
        Instantiate(
            TrashPile,
            pathFinding.Customer.transform.position,
            pathFinding.Customer.transform.rotation,
            TrashFolder
        );
    }
}
