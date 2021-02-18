using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject text01;
    [SerializeField]
    private GameObject text02;
    [SerializeField]
    private GameObject text03;
    [SerializeField]
    private GameObject buttons;
    [SerializeField]
    private float delay01;
    [SerializeField]
    private float delay02;
    [SerializeField]
    private float delay03;
    [SerializeField]
    private float delayButtons;



    // Start is called before the first frame update
    void Start()
    {
        text01.SetActive(false);
        text02.SetActive(false);
        text03.SetActive(false);
        buttons.SetActive(false);
        StartCoroutine(DoDelay(text01, delay01));
        StartCoroutine(DoDelay(text02, delay02));
        StartCoroutine(DoDelay(text03, delay03));
        StartCoroutine(DoDelay(buttons, delayButtons));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DoDelay(GameObject gObj, float time)
    {
        yield return new WaitForSeconds(time);
        gObj.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
