using UnityEngine;

public class UiData : MonoBehaviour
{
    public GameObject PrefabMarker;
    public Canvas Canvas;
    public static UiData instanse;
    private void Awake()
    {
        instanse = this;
    }
}
