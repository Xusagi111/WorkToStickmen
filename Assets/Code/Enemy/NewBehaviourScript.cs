using MoreMountains.NiceVibrations;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Start()
    {
        MMVibrationManager.Vibrate();
        Debug.Log("True");
    }
}
