using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class getInBoat : MonoBehaviour
{
    public GameObject trashSpawners;
    public GameObject player;
    public GameObject fixedBoat;
    public new GameObject camera;
    public GameObject popup;

    public GameObject land2;
    MeshCollider land2col;

    public GameObject land3;
    MeshCollider land3col;

    private bool closeEnough, playerInBoat = false, firstTime = true;

    private void Start()
    {
        land2col = land2.GetComponent<MeshCollider>();
        land3col = land3.GetComponent<MeshCollider>();
    }

    void Update()
    {
        closeEnough = false;
        if (Vector3.Distance(player.transform.position, transform.position) <= 6)
        {
            closeEnough = true;
        }

        // FOR PHONE

        if (Input.touchCount > 0 && closeEnough && !EnterShop.playerInShop && !getxp.playerIsInInv)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "fixedboat" && !playerInBoat)
                        {
                            fixedBoat.GetComponent<NavMeshAgent>().isStopped = false;

                            trashSpawners.SetActive(true);
                            camera.GetComponent<CameraFollow>().enabled = true;
                            fixedBoat.GetComponent<clickMove>().enabled = true;

                            player.transform.localScale = new Vector3(0.184354f, 0.184354f, 0.184354f);
                            player.SetActive(false);
                            playerInBoat = true;

                            FindObjectOfType<AudioManager>().Stop("theme");
                            FindObjectOfType<AudioManager>().Stop("trashISL");
                            FindObjectOfType<AudioManager>().Stop("cityISL");
                            FindObjectOfType<AudioManager>().Play("boat");

                            getOutOfBoat.playerIsOnMain = false;

                            land2col.enabled = true;
                            land3col.enabled = true;

                            if (firstTime)
                            {
                                firstTime = false;
                                popup.SetActive(true);
                                FindObjectOfType<AudioManager>().Play("clicking");
                                StartCoroutine(RemovePopup());
                            }
                        }
                    }
                }
            }
        }

        /*
        
        // FOR PC

        if (Input.GetMouseButtonDown(0) && closeEnough && !EnterShop.playerInShop && !getxp.playerIsInInv)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "fixedboat" && !playerInBoat)
                {
                    fixedBoat.GetComponent<NavMeshAgent>().isStopped = false;

                    trashSpawners.SetActive(true);
                    camera.GetComponent<CameraFollow>().enabled = true;
                    fixedBoat.GetComponent<clickMove>().enabled = true;

                    player.transform.localScale = new Vector3(0.184354f, 0.184354f, 0.184354f);
                    player.SetActive(false);
                    playerInBoat = true;

                    FindObjectOfType<AudioManager>().Stop("theme");
                    FindObjectOfType<AudioManager>().Stop("trashISL");
                    FindObjectOfType<AudioManager>().Stop("cityISL");
                    FindObjectOfType<AudioManager>().Play("boat");

                    getOutOfBoat.playerIsOnMain = false;

                    land2col.enabled = true;
                    land3col.enabled = true;

                    if (firstTime)
                    {
                        firstTime = false;
                        popup.SetActive(true);
                        FindObjectOfType<AudioManager>().Play("clicking");
                        StartCoroutine(RemovePopup());
                    }
                }
            }
        }
        */
    }

    private IEnumerator RemovePopup()
    {
        yield return new WaitForSeconds(8);
        popup.SetActive(false);
        yield return null;
    }

    public bool getPlayerInBoat()
    {
        return playerInBoat;
    }

    public void setPlayerInBoat(bool p)
    {
        playerInBoat = p;
    }
}