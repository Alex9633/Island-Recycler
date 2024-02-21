using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static getxp;

public class RawMatSystem : MonoBehaviour
{
    private int plAmount = 0, paAmount = 0, glAmount = 0, meAmount = 0;
    public Text plasticCounter, paperCounter, glassCounter, metalCounter;

    public Button refinePlasticBtn, refinePaperBtn, refineGlassBtn, refineMetalBtn;

    public GameObject craftPopup;
    private bool firstTime = true;
    
    private void Awake()
    {
        plasticCounter.text = plAmount.ToString();
        paperCounter.text = paAmount.ToString();
        glassCounter.text = glAmount.ToString();
        metalCounter.text = meAmount.ToString();

        Button b1 = refinePlasticBtn.GetComponent<Button>();
        b1.onClick.AddListener(refinePlastic);

        Button b2 = refinePaperBtn.GetComponent<Button>();
        b2.onClick.AddListener(refinePaper);

        Button b3 = refineGlassBtn.GetComponent<Button>();
        b3.onClick.AddListener(refineGlass);

        Button b4 = refineMetalBtn.GetComponent<Button>();
        b4.onClick.AddListener(refineMetal);
    }

    private void refinePlastic()
    {
        if (getOutOfBoat.playerIsOnMain)
        {
            if (plAmount > 0)
            {
                FindObjectOfType<AudioManager>().Play("Refine");
                if (getxp.hasUpgrade3) FindObjectOfType<RefinedMatSystem>().addPlastic(plAmount * 2);
                else FindObjectOfType<RefinedMatSystem>().addPlastic(plAmount);
                addPlastic(-plAmount);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("alert");
                FindObjectOfType<PopupController>().NoMatRefine();
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("alert");
            FindObjectOfType<PopupController>().RCF();
        }
    }

    private void refinePaper()
    {
        if (getOutOfBoat.playerIsOnMain)
        {
            if (getxp.hasUpgrade1)
            {
                if (paAmount > 0)
                {
                    FindObjectOfType<AudioManager>().Play("Refine");
                    if (getxp.hasUpgrade3) FindObjectOfType<RefinedMatSystem>().addPaper(paAmount * 2);
                    else FindObjectOfType<RefinedMatSystem>().addPaper(paAmount);
                    addPaper(-paAmount);
                }
                else
                {
                    FindObjectOfType<PopupController>().NoMatRefine();
                    FindObjectOfType<AudioManager>().Play("alert");
                }
            }
            else
            {
                FindObjectOfType<PopupController>().NoPaperRefine();
                FindObjectOfType<AudioManager>().Play("alert");
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("alert");
            FindObjectOfType<PopupController>().RCF();
        }
    }

    private void refineGlass()
    {
        if (getOutOfBoat.playerIsOnMain)
        {
            if (glAmount > 0)
            {
                FindObjectOfType<AudioManager>().Play("Refine");
                if (getxp.hasUpgrade3) FindObjectOfType<RefinedMatSystem>().addGlass(glAmount * 2);
                else FindObjectOfType<RefinedMatSystem>().addGlass(glAmount);
                addGlass(-glAmount);
            }
            else
            {
                FindObjectOfType<PopupController>().NoMatRefine();
                FindObjectOfType<AudioManager>().Play("alert");
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("alert");
            FindObjectOfType<PopupController>().RCF();
        }
    }

    private void refineMetal()
    {
        if (getOutOfBoat.playerIsOnMain)
        {
            if (getxp.hasUpgrade2)
            {
                if (meAmount > 0)
                {
                    FindObjectOfType<AudioManager>().Play("Refine");
                    if (getxp.hasUpgrade3) FindObjectOfType<RefinedMatSystem>().addMetal(meAmount * 2);
                    else FindObjectOfType<RefinedMatSystem>().addMetal(meAmount);
                    addMetal(-meAmount);
                }
                else
                {
                    FindObjectOfType<PopupController>().NoMatRefine();
                    FindObjectOfType<AudioManager>().Play("alert");
                }
            }
            else
            {
                FindObjectOfType<PopupController>().NoMetalRefine();
                FindObjectOfType<AudioManager>().Play("alert");
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("alert");
            FindObjectOfType<PopupController>().RCF();
        }
    }
    


    public void addPlastic(int a)
    {
        if (plAmount < 99)
        {
            plAmount+=a;
            plasticCounter.text = plAmount.ToString();
        }

        if(glAmount >= 2 && firstTime)
        {
            firstTime = false;
            craftPopup.SetActive(true);
            FindObjectOfType<AudioManager>().Play("clicking");
            StartCoroutine(RemovePopup());
        }
    }

    private IEnumerator RemovePopup()
    {
        yield return new WaitForSeconds(8);
        craftPopup.SetActive(false);
        yield return null;
    }

    public void addPaper(int a)
    {
        if (paAmount < 99)
        {
            paAmount+=a;
            paperCounter.text = paAmount.ToString();
        }
    }

    public void addGlass(int a)
    {
        if (glAmount < 99)
        {
            glAmount+=a;
            glassCounter.text = glAmount.ToString();
        }

        if (glAmount >= 2 && plAmount >= 1 && firstTime)
        {
            firstTime = false;
            craftPopup.SetActive(true);
            FindObjectOfType<AudioManager>().Play("clicking");
            StartCoroutine(RemovePopup());
        }
    }

    public void addMetal(int a)
    {
        if (meAmount < 99)
        {
            meAmount+=a;
            metalCounter.text = meAmount.ToString();
        }
    }

    public int getPlAmount() { return plAmount; }
    public int getPaAmount() { return paAmount; }
    public int getGlAmount() { return glAmount; }
    public int getMeAmount() { return meAmount; }
}
