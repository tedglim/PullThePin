using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinScript : MonoBehaviour
{
    // [SerializeField]
    private GameObject pin;
    private string tappedPinName;
    private Vector3 initPinPos;
    private Vector2 clickStartPos;
    private Vector2 clickEndPos;
    private Vector2 delta;

    [SerializeField]
    private bool right;
    [SerializeField]
    private bool left;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float moveLimit;
    

    // Start is called before the first frame update
    void Start()
    {
        pin = this.transform.gameObject;
        initPinPos = pin.transform.position;
        delta = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed");
            Vector2 mousePos2D = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit2D.collider != null)
            {
                clickStartPos = mousePos2D;
                tappedPinName = hit2D.collider.gameObject.transform.parent.name;
            }
        } else if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("Released");
            clickEndPos = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            delta = clickEndPos - clickStartPos;
        }

        if(tappedPinName == pin.name && right && delta.x > 0 && (pin.transform.position.x - initPinPos.x) < moveLimit)
        {
            Debug.Log("right: " + (pin.transform.position.x - initPinPos.x));
            pin.transform.Translate(Vector2.right * delta.x * speed * Time.deltaTime);
        }
        if(tappedPinName == pin.name && left && delta.x < 0 && (initPinPos.x - pin.transform.position.x) < moveLimit)
        {
            Debug.Log("left: " + (initPinPos.x - pin.transform.position.x));
            pin.transform.Translate(Vector2.left * delta.x * speed * Time.deltaTime);
        }
    }
}
