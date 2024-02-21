using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeFunction : MonoBehaviour
{
    ItemRecipeSO recipe;
    public ItemSO item1, item2;

    public void AddRecipe(ItemRecipeSO newRecipe)
    {
        recipe = newRecipe;
    }

    public void CraftItem()
    {
        if (getOutOfBoat.playerIsOnMain)
        {
            if (RefinedMatSystem.InventoryCurr == RefinedMatSystem.InventorySpace)
            {
                FindObjectOfType<AudioManager>().Play("alert");
                FindObjectOfType<PopupController>().InventoryFull();
            }
            else
            {
                int pl = FindObjectOfType<RefinedMatSystem>().getPlAmount();
                int pa = FindObjectOfType<RefinedMatSystem>().getPaAmount();
                int me = FindObjectOfType<RefinedMatSystem>().getMeAmount();

                switch (recipe.type)
                {
                    case ItemRecipeSO.Type.Umbrella:
                        if ((pl - 2) < 0 || (pa - 2) < 0)
                        {
                            FindObjectOfType<AudioManager>().Play("alert");
                            FindObjectOfType<PopupController>().NotEnoughMat();
                        }
                        else
                        {
                            ItemManager.Instance.Add(item1);
                            FindObjectOfType<RefinedMatSystem>().addPlastic(-1);
                            FindObjectOfType<RefinedMatSystem>().addPaper(-2);
                            RefinedMatSystem.InventoryCurr++;
                            FindObjectOfType<AudioManager>().Play("craft");
                            FindObjectOfType<PopupController>().SwirlUmbrella();
                        }
                        break;

                    case ItemRecipeSO.Type.Suitcase:
                        if (me == 0 || (pl - 3) < 0 || (pa - 2) < 0)
                        {
                            FindObjectOfType<AudioManager>().Play("alert");
                            FindObjectOfType<PopupController>().NotEnoughMat();
                        }
                        else
                        {
                            ItemManager.Instance.Add(item2);
                            FindObjectOfType<RefinedMatSystem>().addMetal(-1);
                            FindObjectOfType<RefinedMatSystem>().addPlastic(-3);
                            FindObjectOfType<RefinedMatSystem>().addPaper(-2);
                            RefinedMatSystem.InventoryCurr++;
                            FindObjectOfType<AudioManager>().Play("craft");
                            FindObjectOfType<PopupController>().SwirlSuitcase();
                        }
                        break;
                }
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("alert");
            FindObjectOfType<PopupController>().RCF();
        }
    }
}
