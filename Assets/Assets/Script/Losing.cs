using UnityEngine;

public class Losing : MonoBehaviour
{
    public ValueHolder valueHolder; 
    public SceneSwitcher sceneSwitcher; 

    public int angryCustomerLimit = 5;
    public int trashLimit = 10;

    private void Update()
    {
        if (valueHolder.NumberOfAngryCustomers >= angryCustomerLimit)
        {
            sceneSwitcher.SwitchScene();
        }

        if (valueHolder.NumberOfTrash >= trashLimit)
        {
            sceneSwitcher.SwitchScene();
        }
    }
}
