using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [System.Serializable]
    public class InventoryItem
    {
        public string itemName;
        public int quantity;
        public Sprite itemImage; // Reference to the image representing the item
    }

    [Header("UI Elements")]
    [SerializeField] private Image itemImageDisplay;
    [SerializeField] private TextMeshProUGUI inventoryText;
    [SerializeField] private TextMeshProUGUI messageText;

    public List<InventoryItem> initialItems = new List<InventoryItem> ();
    public Dictionary<string, InventoryItem> inventory = new Dictionary<string, InventoryItem>();
    public string selectedItem;

    private void Start()
    {
        foreach (InventoryItem item in initialItems) {
            AddItem(item.itemName, item.quantity, item.itemImage);
        }

        UpdateInventoryUI();
    }


    public void AddOne(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName].quantity += 1;
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemImage)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName].quantity += quantity;
        }
        else
        {
            var newItem = new InventoryItem
            {
                itemName = itemName,
                quantity = quantity,
                itemImage = itemImage
            };

            inventory.Add(itemName, newItem);
        }
    }

    public void RemoveItem(string itemName, int quantity)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName].quantity -= quantity;

            if (inventory[itemName].quantity <= 0)
            {
                inventory.Remove(itemName);
            }

            UpdateInventoryUI();
        }
    }

    public void UpdateInventoryUI()
    {
        itemImageDisplay.sprite = inventory[selectedItem].itemImage;
        inventoryText.text = inventory[selectedItem].quantity.ToString();
        messageText.text = inventory[selectedItem].itemName;
    }
}
