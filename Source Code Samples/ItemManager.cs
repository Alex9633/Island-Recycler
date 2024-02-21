using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public List<ItemSO> items;

    public Transform ItemContent;
    public GameObject ItemPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(ItemSO item)
    {
        items.Add(item);
    }

    public void Remove(ItemSO item)
    {
        items.Remove(item);
    }

    public void RemoveAll()
    {
        items.Clear();
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent) 
        { 
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(ItemPrefab, ItemContent);

            var itemIcon = obj.transform.Find("CImage").GetComponent<Image>();

            itemIcon.sprite = item.icon;            
        }
    }

    public List<ItemSO> getItems()
    {
        return items;
    }
}
