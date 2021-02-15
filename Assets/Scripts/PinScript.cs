using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    private Vector2 currPinPos;
    private Vector2 prevMousePos;
    private Vector2 deltaMousePos;
    [SerializeField]
    private float pwr;
    private bool canMovePin;

    // Start is called before the first frame update
    void Start()
    {
        currPinPos = (Vector2) transform.position;
        deltaMousePos = Vector2.zero;
        canMovePin =  false;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButton(0))
        // {

        // }
        // else 
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Holding");
            Vector2 mousePos2D = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit2D.collider != null || canMovePin)
            {
                Debug.Log("HEY");
                Debug.Log(hit2D.collider.gameObject.name);

                canMovePin = true;
                deltaMousePos.x = mousePos2D.x - prevMousePos.x;
                hit2D.collider.gameObject.transform.position += (Vector3) deltaMousePos * pwr * Time.deltaTime;
                prevMousePos = mousePos2D;
                // deltaMousePos = mousePos2D - prevMousPos;
                // currPinPos += deltaMousePos;
            }
        } else if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("Released");
            canMovePin = false;
        }
        // Input.GetMouseButton()
        // Input.GetMouseButtonDown()
        // Input.GetMouseButtonUp()
    }
}
