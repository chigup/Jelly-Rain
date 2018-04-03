using UnityEngine;

public class jelly : MonoBehaviour
{

    public GameObject jellyObject;
    public GameObject cutJelly;
    public GameObject jellyForPosition;
   
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "blade")
        {


           Vector3 direction = (other.transform.position - jellyForPosition.transform.position).normalized;
            //Getting a vector from initial postion of blade to final position of blade.
           int degree = Random.Range(0, 360);
           Quaternion rotation = Quaternion.AngleAxis(degree, direction);
            //Getting the amount to be rotated for cutted jelly.
           GameObject cutjel =   Instantiate(cutJelly, jellyForPosition.transform.position, rotation);
            //instantiate the cutted jelly in place of the jelly.
           Destroy(jellyObject);
            //   Debug.Log(cutjel.GetComponent<Rigidbody>().velocity+"old vel");
            cutjel.GetComponent<Rigidbody>().velocity = spawner.velofjelly;
            //  Debug.Log(cutjel.GetComponentInChildren<Rigidbody>().velocity+"new vel");

           
        }
    }

}
