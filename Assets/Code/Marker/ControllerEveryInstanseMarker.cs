using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControllerEveryInstanseMarker : IMarker
{
    public Image MarckerImage { get ; set ; }
    public RectTransform MyProperty { get; set; }
    public GameData GameData { get ; set; }
    public GameObject TrakingEnemy { get ; set; }

    public void ClearMarker()
    {
        throw new System.NotImplementedException();
    }

    public void Start(GameObject trakingEnemy, GameObject markerImage) // Добавление элементов к маркеру
    {
        TrakingEnemy = trakingEnemy;
        MarckerImage = markerImage.GetComponent<Image>();
        MyProperty = MarckerImage.gameObject.GetComponent<RectTransform>();
        GameData = GameData.instanse;
    }

    public void UpdateMarker()
    {
        float dist = Vector3.Distance(TrakingEnemy.transform.position, GameData.Player.transform.position);
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
    public void Start(GameObject trakingEnemy, GameObject markerImage);
}