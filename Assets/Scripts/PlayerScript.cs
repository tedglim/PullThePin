using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private GameObject player;
    private float horizMove;
    [SerializeField]
    private float spd;
    private bool facingRight;
    [SerializeField]
    private float hurtDuration;
    [SerializeField]
    private float hurtColorInterval;
    [SerializeField]
    private GameObject soundManagerGObj;
    private SoundManagerScript soundManager;
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.gameObject;
        facingRight = true;
        soundManager = soundManagerGObj.GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        horizMove = Input.GetAxisRaw("Horizontal") * spd;
        FlipPlayer(horizMove);
        animator.SetFloat("Speed", Mathf.Abs(horizMove));
    }

    private void FlipPlayer(float dir)
    {
        if (facingRight && dir < 0)
        {
            facingRight = false;
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (!facingRight && dir > 0)
        {
            facingRight = true;
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void FixedUpdate()
    {

        player.transform.Translate(Vector2.right * horizMove * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Lose");
            LoseGame();
        }
        else if (other.gameObject.tag == "Collectible")
        {
            Debug.Log("Win");
            WinGame();
        }
    }

    private void LoseGame()
    {
        soundManager.PlaySound("Hurt");
        StartCoroutine(FlashRed());
        //Show Loss Screen
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

    private void WinGame()
    {
        //if there are collectibles
        //if there are collectibles touching me,
        //destroy tem and make noise
        //else
        //move towards nearby one.
        //Collect and destroy all coins i'm touching
        //find the rest
        soundManager.PlaySound("Collect");
        //Make Collect Sound
        //Show Win Screen
    }
}
