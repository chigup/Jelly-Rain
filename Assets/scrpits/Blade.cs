
using UnityEngine;

public class Blade : MonoBehaviour {

    bool isCutting = false;
    public GameObject trail;

    Rigidbody2D rb;
    Camera cam;
    GameObject currentTrail;
    Vector2 newPos;
    Vector2 prevPos;
    SphereCollider bladeCollider;


    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent < Rigidbody2D >();
        bladeCollider = GetComponentInChildren<SphereCollider>();
    }


    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            isCutting = true;
            startCutting();
            bladeCollider.enabled = true;
            

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isCutting = false;
            stopCutting();
            bladeCollider.enabled = false;
        }
        if (isCutting)
        {
            updateCutting();
        }

	}

    void updateCutting()
    {
        
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        //changing from screen coordinate's to world coordinat's.



    }


    private void startCutting()
    {
        isCutting = true;
        bladeCollider.enabled = true;
        currentTrail = Instantiate(trail, transform);
   
      

    }


    private void stopCutting()
    {
        bladeCollider.enabled = false;
        isCutting = false;
        currentTrail.transform.parent = null;   
        Destroy(currentTrail, 1f);
       
    }



















}
