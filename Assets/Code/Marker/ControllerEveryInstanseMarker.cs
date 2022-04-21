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
        TrakingEnemy = null;
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

        if (dist < 10)
        {
            if (MarckerImage.gameObject.activeSelf != false)
            {
                MarckerImage.gameObject.SetActive(false);
            }
            return;
        }
        ControllerPositionGameObj();

        if (dist > 10)
        {
            if (MarckerImage.gameObject.activeSelf != true)
            {
                MarckerImage.gameObject.SetActive(true);
            }
            Debug.Log($"Дистанция:  { dist}");
        }
    }
    private void ControllerPositionGameObj()
    {

        float minX = MarckerImage.GetPixelAdjustedRect().width / 2;

        float maxX = Screen.width - minX;

        float minY = MarckerImage.GetPixelAdjustedRect().height / 2;

        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(TrakingEnemy.transform.position);

        if (Vector3.Dot((TrakingEnemy.transform.position - MarckerImage.transform.position), MarckerImage.transform.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        MarckerImage.transform.position = pos;
    }
}
public interface IMarker
{
    public Image MarckerImage { get; set; }
    public RectTransform MyProperty { get; set; }
    public GameData GameData { get; set; }
    public GameObject TrakingEnemy { get; set; }
    public void UpdateMarker();
    public void ClearMarker();
    public void Start(GameObject trakingEnemy, GameObject markerImage);
}