using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinScript : MonoBehaviour
{
    private GameObject pin;
    private GameObject tappedPin;
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
        if (!GameStateScript.IsPinMoving && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed");
            Vector2 mousePos2D = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit2D.collider != null)
            {
                clickStartPos = mousePos2D;
                tappedPin = hit2D.collider.gameObject;
                // Debug.Log(tappedPinName);
            }
        }
        else if (!GameStateScript.IsPinMoving && Input.GetMouseButtonUp(0))
        {
            Debug.Log("Released");
            clickEndPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            delta = clickEndPos - clickStartPos;
        }
    }

    void FixedUpdate()
    {
        if (tappedPin != null)
        {
            if (tappedPin.name == pin.name && right && delta.x > 0 && (pin.transform.position.x - initPinPos.x) < moveLimit)
            {
                // Debug.Log("right: " + (pin.transform.position.x - initPinPos.x));
                pin.transform.Translate(Vector2.up * speed * Time.deltaTime);
                GameStateScript.IsPinMoving = true;
            }
            else if (tappedPin.name == pin.name && left && delta.x < 0 && (initPinPos.x - pin.transform.position.x) < moveLimit)
            {
                // Debug.Log("left: " + (initPinPos.x - pin.transform.position.x));
                pin.transform.Translate(Vector2.down * speed * Time.deltaTime);
                GameStateScript.IsPinMoving = true;
            }
        }
        if (right && (pin.transform.position.x - initPinPos.x) >= moveLimit)
        {
            Debug.Log("Unlock");
            GameStateScript.IsPinMoving = false;
        }
        else if (left && (initPinPos.x - pin.transform.position.x) >= moveLimit)
        {
            Debug.Log("Unlock");
            GameStateScript.IsPinMoving = false;
        }
    }
}
