using UnityEditor.TerrainTools;
using UnityEngine;

public class DynamicMaterial: MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Material material3;

    private void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        Material[] newMaterials = new Material[3];
        
        newMaterials[0] = material1;
        newMaterials[1] = material2;
        newMaterials[2] = material3;

        int materialIndex = Random.Range(0, 3);
        renderer.material = newMaterials[materialIndex];
    }
}
