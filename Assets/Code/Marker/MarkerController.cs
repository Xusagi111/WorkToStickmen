using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    [SerializeField] private DataEnemy dataEnemy = new DataEnemy();
    [SerializeField] private List<GameObject> Point;
    private void Start()
    {
        new SpavnMarker(dataEnemy.EnemyPoint, Point);
        for (int i = 0; i < Point.Count; i++)
        {
            //Point[i].
        }
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < Point.Count; i++)
        {
            if (Point.Count > dataEnemy.EnemyPoint.Length)
            {

            }
        }
    }
    private void DestroymarkerEnemy(GameObject currentGameobj) //����� ���������� �� �������. ������� ������� ������ � ������� ���� ���� �������.
    {
        //for (int i = 0; i < Point.Count; i++)
        //{
        //    if (itemEnemy.CurrentObjTracking == currentGameobj)
        //    {
        //        itemEnemy.CurrentObjTracking = null;
        //        Point[i].gameObject.SetActive(false);
        //    }   
        //}
    }
}

