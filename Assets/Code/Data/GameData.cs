using UnityEngine;

public class GameData : MonoBehaviour
{
    public GameObject Player;
    public static GameData instanse;
    private void Start()
    {
        instanse = this;
    }
}
