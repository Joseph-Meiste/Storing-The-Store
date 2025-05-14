using UnityEngine;

public class Winning : MonoBehaviour
{
    public ValueHolder valueHolder; // Reference to ValueHolder script
    public SceneSwitcher sceneSwitcher; // Reference to SceneSwitcher script

    public int dayLimit = 5; // Number of days needed to win

    private void Update()
    {
        if (valueHolder.DayNumber >= dayLimit)
        {
            sceneSwitcher.SwitchScene();
        }
    }
}
