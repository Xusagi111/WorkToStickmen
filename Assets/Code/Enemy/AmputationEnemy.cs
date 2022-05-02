using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmputationEnemy : MonoBehaviour
{
    [SerializeField] private Cinemachine.CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private GameObject PlayerBody;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            bool iskritPoint = false;
            Rigidbody CurrentEnemyRigidbody = other.gameObject.GetComponent<Rigidbody>();

            if (other.gameObject.GetComponentInParent<Link>().enabled == false)
            {
                return;
            }
            if (other.gameObject == other.gameObject.GetComponentInParent<Link>().HeadEnemy 
                || other.gameObject == other.gameObject.GetComponentInParent<Link>().ArmRight 
                || other.gameObject == other.gameObject.GetComponentInParent<Link>().forearmEnemy)
            {

                iskritPoint = true;
            }

            if (iskritPoint)
            {
                StartCoroutine(ActiveWinPanel(other.gameObject.GetComponentInParent<Link>()));
            }
            StartCoroutine(DelayToAnimation(other.gameObject.GetComponentInParent<Link>().AnimatorEnemy, other.gameObject, CurrentEnemyRigidbody, iskritPoint));
            StartCoroutine(ChangesTimeScale(other.gameObject.GetComponentInParent<Link>().gameObject));
        }
    }
    private IEnumerator DelayToAnimation(Animator animator, GameObject CurrentGameObj, Rigidbody CurrentEnemyRigidbody, bool isDead)
    {
        animator.enabled = false;
        CurrentEnemyRigidbody.velocity = new Vector3(5, 10, 0);
        CurrentEnemyRigidbody.isKinematic = false;
        if (isDead)
        {
            CurrentGameObj.gameObject.GetComponentInParent<Link>().PuppetMaster.mappingWeight = 1;
            CurrentGameObj.gameObject.GetComponentInParent<Link>().PuppetMaster.state = RootMotion.Dynamics.PuppetMaster.State.Dead;
        }
        yield return new WaitForSeconds(0.3f);
        Destroy(CurrentGameObj);
        animator.enabled = true;
    }
    private IEnumerator ChangesTimeScale(GameObject CurrentObj)
    {
        _cinemachineVirtualCamera.Follow = CurrentObj.transform;
        _cinemachineVirtualCamera.LookAt = CurrentObj.transform;
        _cinemachineVirtualCamera.m_Lens.FieldOfView = 30f;

        Time.timeScale = 0.3f;

        yield return new WaitForSeconds(1f);

        _cinemachineVirtualCamera.Follow = PlayerBody.transform;
        _cinemachineVirtualCamera.LookAt = PlayerBody.transform;

        _cinemachineVirtualCamera.m_Lens.FieldOfView = 45f;
        Time.timeScale = 1f;
    }
    private IEnumerator ActiveWinPanel(Link link)
    {
        UiData.instanse.Winimage.gameObject.SetActive(true);
        UiData.instanse.ParticleWin.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        link.enabled = false;
        UiData.instanse.Winimage.gameObject.SetActive(false);
        UiData.instanse.ParticleWin.gameObject.SetActive(false);
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