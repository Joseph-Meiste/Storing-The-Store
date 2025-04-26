using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public Camera cam;
    public Vector3 offset;

    private void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            transform.position = hit.point + offset;
        }
    }
}
