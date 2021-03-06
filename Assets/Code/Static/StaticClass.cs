using System.Collections;
using UnityEngine;

public class StaticClass : MonoBehaviour
{
    public static StaticClass instanse;
    public void Awake()
    {
        instanse = this;
    }
    public IEnumerator enumerator(float second, GameObject GameObjSetActive)
    {
        GameObjSetActive.SetActive(true);
        yield return new WaitForSeconds(second);
        GameObjSetActive.SetActive(false);
    }
}