using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<Link>())
            {
                Rigidbody CurrentEnemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
                CurrentEnemyRigidbody.isKinematic = false;
                CurrentEnemyRigidbody.velocity = new Vector3(5,10,0);

                //other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                StartCoroutine(ChangesTimeScale());
                if (other.gameObject.GetComponent<Link>().CurrentGameObj != null)
                {
                    other.gameObject.GetComponent<Link>().PuppetMaster.mappingWeight = 1;
                    other.gameObject.GetComponent<Link>().PuppetMaster.state = RootMotion.Dynamics.PuppetMaster.State.Dead;
                    StartCoroutine(ActiveWinPanel());
                }
            }
        }
    }
    private IEnumerator ChangesTimeScale()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
    }
    private IEnumerator ActiveWinPanel()
    {
        UiData.instanse.Winimage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        UiData.instanse.Winimage.gameObject.SetActive(false);
    }
}
public static class ExtensionMethods
{
    public static void RemoveComponent<Component>(this GameObject obj, bool immediate = false)
    {
        Component component = obj.GetComponent<Component>();

        if (component != null)
        {
            if (immediate)
            {
                Object.DestroyImmediate(component as Object, true);
            }
            else
            {
                Object.Destroy(component as Object);
            }

        }
    }
}