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
                Debug.Log("Вошел");
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                other.gameObject.GetComponent<Link>().PuppetMaster.state = RootMotion.Dynamics.PuppetMaster.State.Dead;
                
                //collision.gameObject.GetComponent<CharacterJoint>().
            }
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        if (collision.gameObject.GetComponent<ConfigurableJoint>())
    //        {
    //            ExtensionMethods.RemoveComponent<ConfigurableJoint>(collision.gameObject, false);
    //            //collision.gameObject.GetComponent<CharacterJoint>().
    //        }
    //    }
    //}

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