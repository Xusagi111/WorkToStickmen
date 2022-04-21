using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    [SerializeField] private DataEnemy dataEnemy = new DataEnemy();
    [SerializeField] private List<GameObject> Point;
    [SerializeField] private List<IMarker> markers = new List<IMarker>();
    [SerializeField] private bool isUpdate; 
    private void Start()
    {
        new SpavnMarker(dataEnemy.EnemyPoint, Point);
        for (int i = 0; i < Point.Count; i++)
        {
            ControllerEveryInstanseMarker controllerEveryInstanse = new ControllerEveryInstanseMarker();
            controllerEveryInstanse.Start(dataEnemy.EnemyPoint[i].gameObject, Point[i].gameObject);
            markers.Add(controllerEveryInstanse);
        }
        isUpdate = true;
        StartCoroutine(FixedUpdateTo3F());
    }
    IEnumerator FixedUpdateTo3F()
    {
        while (isUpdate)
        {
            yield return new WaitForSeconds(0.3f);
            for (int i = 0; i < markers.Count; i++)
            {
                markers[i].UpdateMarker();
            }
        }
    }
    private void DestroymarkerEnemy(GameObject currentGameobj) //Будет вызываться по событию. Удалять текущий маркер и чистить поле гейм объекта.
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

