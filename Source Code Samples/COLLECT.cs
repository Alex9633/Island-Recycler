using System.Collections;
using System.Collections.Generic;
using static Trashspawner;
using UnityEngine.UI;
using UnityEngine;

class COLLECT : MonoBehaviour
{
    public GameObject Player;
    private bool closeEnough, playerIsInBoat = false;

    void FixedUpdate()
    {
        //no null errors
        if (Player.activeSelf) playerIsInBoat = FindObjectOfType<getInBoat>().getPlayerInBoat();


        // COLLECT FOR PHONE

        if (Input.touchCount > 0 && playerIsInBoat)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out hit))
                    {
                        BoxCollider b = hit.collider as BoxCollider;
                        if (b != null)
                        {
                            closeEnough = false;
                            if (Vector3.Distance(hit.transform.position, Player.transform.position) <= 5.25f)
                            {
                                closeEnough = true;
                            }

                            if (hit.transform.gameObject.CompareTag("Plastic") && closeEnough)
                            {
                                FindObjectOfType<AudioManager>().Play("Collect");
                                FindObjectOfType<RawMatSystem>().addPlastic(1);
                                Trashspawner.trashCountTotal -= 1;
                                Destroy(hit.transform.gameObject);
                            }

                            if (hit.transform.gameObject.CompareTag("Glass") && closeEnough)
                            {
                                FindObjectOfType<AudioManager>().Play("Collect");
                                FindObjectOfType<RawMatSystem>().addGlass(1);
                                Trashspawner.trashCountTotal -= 1;
                                Destroy(hit.transform.gameObject);
                            }

                            if (hit.transform.gameObject.CompareTag("Metal") && closeEnough)
                            {
                                FindObjectOfType<AudioManager>().Play("Collect");
                                FindObjectOfType<RawMatSystem>().addMetal(1);
                                Trashspawner.trashCountTotal -= 1;
                                Destroy(hit.transform.gameObject);
                            }

                            if (hit.transform.gameObject.CompareTag("Paper") && closeEnough)
                            {
                                FindObjectOfType<AudioManager>().Play("Collect");
                                FindObjectOfType<RawMatSystem>().addPaper(1);
                                Trashspawner.trashCountTotal -= 1;
                                Destroy(hit.transform.gameObject);
                            }
                        }
                    }
                }
            }
        }

        /*
        
        // COLLECT FOR PC

        if (Input.GetMouseButton(0) && playerIsInBoat)
        {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit))
                    {
                        BoxCollider b = hit.collider as BoxCollider;
                        if (b != null)
                        {
                            closeEnough = false;
                            if (Vector3.Distance(hit.transform.position, Player.transform.position) <= 5.25f)
                            {
                                closeEnough = true;
                            }

                            if (hit.transform.gameObject.CompareTag("Plastic") && closeEnough)
                            {
                                FindObjectOfType<AudioManager>().Play("Collect");
                                FindObjectOfType<RawMatSystem>().addPlastic(1);
                                Trashspawner.trashCountTotal -= 1;
                                Destroy(hit.transform.gameObject);
                            }

                            if (hit.transform.gameObject.CompareTag("Glass") && closeEnough)
                            {
                                FindObjectOfType<AudioManager>().Play("Collect");
                                FindObjectOfType<RawMatSystem>().addGlass(1);
                                Trashspawner.trashCountTotal -= 1;
                                Destroy(hit.transform.gameObject);
                            }

                            if (hit.transform.gameObject.CompareTag("Metal") && closeEnough)
                            {
                                FindObjectOfType<AudioManager>().Play("Collect");
                                FindObjectOfType<RawMatSystem>().addMetal(1);
                                Trashspawner.trashCountTotal -= 1;
                                Destroy(hit.transform.gameObject);
                            }

                            if (hit.transform.gameObject.CompareTag("Paper") && closeEnough)
                            {
                                FindObjectOfType<AudioManager>().Play("Collect");
                                FindObjectOfType<RawMatSystem>().addPaper(1);
                                Trashspawner.trashCountTotal -= 1;
                                Destroy(hit.transform.gameObject);
                            }
                        }
                    }
        }
        */
    }
}
