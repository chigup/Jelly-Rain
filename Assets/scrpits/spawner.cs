using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public static Vector3 velofjelly;
    public GameObject jellyObject;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;
    public float destroyTime = 10f;

    GameObject jel;
  
    void Start () {
        // Starting coroutine .
        StartCoroutine(spawn());
	}
	
	IEnumerator spawn()
    {
        while (true)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                int degree = Random.Range(45, 80);
                spawnPoints[i].Rotate(degree, 0f, 0f);
                // randomizing the cube spawing angle.
              

            }
            //  Destroy(jelly);
            float delay = Random.Range(minDelay, maxDelay);
            //randomzing the time after hich each cube will spawn.
            yield return  new WaitForSeconds(delay);

            
            int index = Random.Range(0, spawnPoints.Length);
            //selecting random spawner point.
            Transform spawnPoint = spawnPoints[index];
          
     
           
            jel =     Instantiate(jellyObject, spawnPoint.position,spawnPoint.rotation);
          
        }
    }




    private void Update()
    {
        velofjelly = jel.GetComponent<Rigidbody>().velocity;
        // Debug.Log("got children");
       // Debug.Log(velofjelly+"from spawner");
    }

}

