using System.Collections.Generic;
using UnityEngine;

public class SpavnMarker //Cпвн и добавление в маркеры текущих объектов
{
    public SpavnMarker(GameObject[] EnemyPoint, List<GameObject> listCurrentPoint)
    {
        UiData uiData = UiData.instanse;
        for (int i = 0; i < EnemyPoint.Length; i++)
        {
            GameObject CreateGameObj = GameObject.Instantiate(uiData.PrefabMarker, Vector3.zero, Quaternion.identity);
            AddSettings(CreateGameObj, uiData);
            listCurrentPoint.Add(CreateGameObj);
        }
    }
    private void AddSettings(GameObject CurrentCreateMarker, UiData uiData)
    {
        CurrentCreateMarker.transform.SetParent(uiData.Canvas.transform);
        CurrentCreateMarker.transform.localScale = new Vector3(1, 1, 1);
    }
}
