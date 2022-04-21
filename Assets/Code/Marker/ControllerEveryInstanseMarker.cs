using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControllerEveryInstanseMarker : MonoBehaviour, IMarker
{
    public Image MarckerImage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public RectTransform MyProperty { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameData GameData { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject TrakingEnemy { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void ClearMarker()
    {
        throw new System.NotImplementedException();
    }

    public void Start() // Добавление элементов к маркеру
    {
        MyProperty = MarckerImage.gameObject.GetComponent<RectTransform>();
        GameData = GameData.instanse;
    }

    public void UpdateMarker()
    {
        float dist = Vector3.Distance(TrakingEnemy.transform.position, gameObject.transform.position);
        Debug.Log($"Дистанция:  { dist}");
        if (dist > 1)
        {

        }
    }
}
public interface IMarker //Если использовать переиспользование, добавить метод Add;
{
    public Image MarckerImage { get; set; }
    public RectTransform MyProperty { get; set; }
    public GameData GameData { get; set; }
    public GameObject TrakingEnemy { get; set; }
    public void UpdateMarker();
    public void ClearMarker();
    public void Start();
}