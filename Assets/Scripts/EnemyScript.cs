using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject soundManagerGObj;
    private SoundManagerScript soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = soundManagerGObj.GetComponent<SoundManagerScript>();
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            soundManager.PlaySound("Destroy");
            Destroy(col.gameObject);
            if(!GameStateScript.IsGameOver)
            {
                GameStateScript.IsGameOver = true;
                StartCoroutine(ShowDefeat());
            }
        }
    }

    IEnumerator ShowDefeat()
    {
        yield return new WaitForSeconds(1.0f);
        GameEventsScript.defeat.Invoke();
    }
}
