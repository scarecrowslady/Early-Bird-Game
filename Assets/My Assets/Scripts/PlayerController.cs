using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //player body
    public Image playerChara;

    //calculating health and points
    public float healthHitPoint;
    public float hiScoreAdd;

    //managing sounds
    public AudioSource hitWorm;
    public AudioSource didntHitWorm;

    //managing game states
    GameController gameManagingScript;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManagingScript = gameManager.GetComponent<GameController>();

        //controlling numbers
        healthHitPoint = -10;
        hiScoreAdd = 5;
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerChara();

        //destroy circles
        if (Input.GetMouseButtonDown(0))
        {
            ClickDestroyCircle();
        }
    }

    void ClickDestroyCircle()
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        //clicking on empty hole
        if(hit.collider.CompareTag("ring_empty"))
        {
            Debug.Log("clicked on " + hit.collider.tag);

            hitWorm.Play();

            gameManagingScript.GetComponent<GameController>().ManagingHealth(healthHitPoint);

            Destroy(hit.collider.gameObject);
        }

        //clicking on full hole
        if (hit.collider.CompareTag("ring_full"))
        {
            Debug.Log("clicked on " + hit.collider.tag);

            didntHitWorm.Play();

            gameManagingScript.GetComponent<GameController>().AddingPoints(hiScoreAdd);

            Destroy(hit.collider.gameObject);
        }
    }

    public void SetPlayerChara()
    {
        if (MainManager.Instance != null)
        {
            playerChara.overrideSprite = MainManager.Instance.PlayerChara.sprite;

            Debug.Log("the player is:" + playerChara.name);
        }
    }
}
