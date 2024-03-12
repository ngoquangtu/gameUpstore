using UnityEngine;
public class ShopDialog : MonoBehaviour
{
    public Transform gridRoot;
    public ShopUI itemPb;

/*    int idex;*/

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        var items = ShopManager.Instance.items;
        if (items == null || items.Length <= 0 || !gridRoot || !itemPb)
        {
            return;
        }
        ClearChilds();
        for (int i = 0; i < items.Length; i++)
        {
            int  idex = i;
            var item = items[i];
            if (item != null)
            {

                var itemClone = Instantiate(itemPb, Vector3.zero, Quaternion.identity);
                itemClone.transform.SetParent(gridRoot);
                itemClone.transform.localPosition = Vector3.zero;
                itemClone.transform.localScale = Vector3.one;
                itemClone.UpdateUI(item, idex);
                if(itemClone.btn)
                {
                    itemClone.btn.onClick.RemoveAllListeners();
                    itemClone.btn.onClick.AddListener(()=>ItemEvent(item, idex));
                }
            }
        }
    }
    void ItemEvent(ShopItem item ,int shopItemId)
    {
        if (item==null)
        {
            return;
        }
        bool isUnlocked = Pref.GetBool(PrefConst.Player_Index + shopItemId);
        if (isUnlocked)
        {
            if (shopItemId == Pref.CurPlayerId)
            {
                return;
            }
            Pref.CurPlayerId= shopItemId;
            PlayerSelection.Instance.SelectPlayer(Pref.CurPlayerId);
            UpdateUI();
        }
        else
        {
            if(Pref.Coins>=item.price)
            {
                Pref.Coins-= item.price;
                Pref.SetBool(PrefConst.Player_Index + shopItemId, true);
                Pref.CurPlayerId = shopItemId;
                GUIManager.Instance.UpdateCoins();
                PlayerSelection.Instance.SelectPlayer(Pref.CurPlayerId);
                UpdateUI();
                Debug.Log("Current"+Pref.CurPlayerId);

            }
            else
            {
                Debug.Log("You don't have enough coins to buy it");
            }
        }
    }
    public void ClearChilds()
    {
        if(!gridRoot || gridRoot.childCount<=0)
        {
            return;
        }
        for(int i=0;i<gridRoot.childCount;i++)
        {
            var child = gridRoot.GetChild(i);
            if (child != null)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
