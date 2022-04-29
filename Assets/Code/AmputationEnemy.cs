using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmputationEnemy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            Rigidbody CurrentEnemyRigidbody = other.gameObject.GetComponent<Rigidbody>();


            if (other.gameObject == other.gameObject.GetComponentInParent<Link>().HeadEnemy)
            {
                other.gameObject.GetComponentInParent<Link>().PuppetMaster.mappingWeight = 1;
                other.gameObject.GetComponentInParent<Link>().PuppetMaster.state = RootMotion.Dynamics.PuppetMaster.State.Dead;
               
                StartCoroutine(DelayToAnimation(other.gameObject.GetComponentInParent<Link>().AnimatorEnemy, other.gameObject, CurrentEnemyRigidbody));
               // Destroy(other.gameObject);

                StartCoroutine(ActiveWinPanel()); //В дальнейшм убрать
                return;
            }

            StartCoroutine(DelayToAnimation(other.gameObject.GetComponentInParent<Link>().AnimatorEnemy, other.gameObject, CurrentEnemyRigidbody));
           
            //CurrentEnemyRigidbody.velocity = new Vector3(5, 10, 0);

            StartCoroutine(ChangesTimeScale());
           

        }
    }
    private IEnumerator DelayToAnimation(Animator animator, GameObject CurrentGameObj, Rigidbody CurrentEnemyRigidbody)
    {
        animator.enabled = false;
        CurrentEnemyRigidbody.velocity = new Vector3(5, 10, 0);
        CurrentEnemyRigidbody.isKinematic = false;
        yield return new WaitForSeconds(0.3f);
        Destroy(CurrentGameObj);
        animator.enabled = true;
    }
    private IEnumerator ChangesTimeScale()
    {
        Time.timeScale = 0.3f;
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