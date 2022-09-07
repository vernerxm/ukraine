using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Shop : MonoBehaviour
{
    #region Singltor:Shop
    public static Shop instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #endregion
    [System.Serializable] public  class ShopItem
    {
        public Sprite image;
        public int price;
        public bool IsPurchased = false;
    }

    public List<ShopItem> ShopItemsList;
    [SerializeField] Animator noCoinsAnim;
    
    GameObject ItemTemplate;
    GameObject g;
    [SerializeField]  Transform ShopScrollView;
    Button BuyBtn;
    private void Start()
    {
        ItemTemplate=ShopScrollView.GetChild(0).gameObject;

        int len = ShopItemsList.Count;

        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate,ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].price.ToString();
            BuyBtn = g.transform.GetChild(2).GetComponent<Button>();
            BuyBtn.interactable = !ShopItemsList[i].IsPurchased;
            BuyBtn.AddEventListener(i,OnShopItemBtnClicked);

        }
        Destroy(ItemTemplate);
        
    }
    void OnShopItemBtnClicked(int itemIndex)
    {
        if (Game.instance.HasEnoughCoins(ShopItemsList[itemIndex].price))
        {
            Game.instance.UseCoins(ShopItemsList[itemIndex].price);


            ShopItemsList[itemIndex].IsPurchased = true;
            BuyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            BuyBtn.interactable = false;
            BuyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
            Game.instance.UpdateAllCoinsUIText();
        }
        else
        {
            noCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("You are Bum)");
        }
        
    } 
    
   
    public void OpenShop()
    {
        gameObject.SetActive(true);
    }
    public void CloseShop()
    {
        gameObject.SetActive(false);
    }




}
