using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LineDamage : MonoBehaviour
{
    private void FixedUpdate()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.right);
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.right * 100, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20f))
        {
            Debug.Log("transform.position" + transform.position);
            Debug.Log(hit.collider.name );
            if (hit.collider.gameObject.GetComponentInParent<DataPlayer>())
            {

                StartCoroutine(StaticClass.instanse.enumerator(0.5f, UiData.instanse.DebugImage.gameObject));
                UiData.instanse.DebugImage.gameObject.SetActive(true);
                UiData.instanse.DebugImage.GetComponentInChildren<Text>().text = "Нанесен урон!!!";
            }
        }
    }
    
}
