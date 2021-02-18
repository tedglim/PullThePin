using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    private GameObject player;
    private float horizMove;
    [SerializeField]
    private float rMoveTime;
    [SerializeField]
    private float lMoveTime;
    [SerializeField]
    private float spd;
    private float duration;
    [SerializeField]
    private float hurtDuration;
    [SerializeField]
    private float hurtColorInterval;
    private bool isCollecting;
    [SerializeField]
    private GameObject spawner;
    [SerializeField]
    private GameObject soundManagerGObj;
    private SoundManagerScript soundManager;
    [SerializeField]
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.gameObject;
        isCollecting = false;
        duration = 0f;
        soundManager = soundManagerGObj.GetComponent<SoundManagerScript>();
    }

    void FixedUpdate()
    {
        if (isCollecting)
        {
            AutoMove();
        }
    }

    private void AutoMove()
    {
        if (duration < rMoveTime)
        {
            horizMove = spd;
            player.transform.Translate(Vector2.right * horizMove * Time.deltaTime);
        }
        else if (duration < rMoveTime + lMoveTime)
        {
            horizMove = -spd;
            FlipPlayer(horizMove);
            player.transform.Translate(Vector2.right * horizMove * Time.deltaTime);
        }
        else
        {
            isCollecting = false;
            horizMove = 0;
        }
        animator.SetFloat("Speed", Mathf.Abs(horizMove));
        duration += Time.deltaTime;
    }

    private void FlipPlayer(float dir)
    {
        if (dir < 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (dir > 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            // Debug.Log("Lose");
            soundManager.PlaySound("Hurt");
            LoseGame();
        }
        else if (other.gameObject.tag == "Collectible")
        {
            // Debug.Log("Win");
            soundManager.PlaySound("Collect");
            Destroy(other.gameObject);
            WinGame();
        }
    }

    private void LoseGame()
    {
        StartCoroutine(FlashRed());
        if (!GameStateScript.IsGameOver)
        {
            GameStateScript.IsGameOver = true;
            StartCoroutine(ShowDefeat());
        }
    }

    IEnumerator FlashRed()
    {
        float timeElapsed = 0;
        float startTime = Time.time;
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        Color tmp = sr.color;
        while (timeElapsed < hurtDuration)
        {
            if (sr.color != Color.red)
            {
                sr.color = Color.red;
            }
            else
            {
                sr.color = tmp;
            }
            yield return new WaitForSeconds(hurtColorInterval);
            timeElapsed = Time.time - startTime;
        }
    }

    IEnumerator ShowDefeat()
    {
        yield return new WaitForSeconds(hurtDuration);
        GameEventsScript.defeat.Invoke();
    }

    private void WinGame()
    {
        isCollecting = true;
        if (!GameStateScript.IsGameOver)
        {
            GameStateScript.IsGameOver = true;
            StartCoroutine(ShowVictory());
        }
    }

    IEnumerator ShowVictory()
    {
        yield return new WaitForSeconds(hurtDuration);
        GameEventsScript.victory.Invoke();
    }
}
