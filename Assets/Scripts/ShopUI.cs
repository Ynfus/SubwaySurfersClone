using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] Button astronautButton;
    [SerializeField] Button homelessButton;
    [SerializeField] Button cyclistButton;
    [SerializeField] TextMeshProUGUI cyclistButtonText;
    [SerializeField]  TextMeshProUGUI astronautButtonText;
    [SerializeField] TextMeshProUGUI homelessButtonText;
    [SerializeField] TextMeshProUGUI coinsAmount;

    private const string ASTRONAUT = "astronaut";
    //private const string HOMELESS = "homeless";
    //private const string CYCLIST = "cyclist";
    //private const int ASTRONAUT_COST = 10;
    //private const int HOMELESS_COST = 20;
    //private const int CYCLIST_COST = 20;

    struct Skin
    {
        public string name;
        public int cost;
        public Button button;
        public TextMeshProUGUI buttonText;
        public Skin(string name, int cost, Button button, TextMeshProUGUI buttonText)
        {
            this.name = name;
            this.cost = cost;
            this.button = button;
            this.buttonText = buttonText;
        }
    }
    private List<Skin> skins = new List<Skin>();
  
    
    private void Start()
    {
        skins.AddRange(new List<Skin> {
            new Skin("astronaut", 10, astronautButton, astronautButtonText),
            new Skin("homeless", 20, homelessButton, homelessButtonText),
            new Skin("cyclist", 30, cyclistButton, cyclistButtonText)
        });
        //PlayerPrefs.DeleteKey("OwnedSkins");
        coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();

        foreach (Skin skin in skins)
        {
            skin.button.onClick.AddListener(() => BuySkin(skin));
        }

        UpdateSkinButtons();
    }
    private void BuySkin(Skin skin)
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
        string[] ownedSkins = ownedSkinsString.Split(',');
        if (!ownedSkins.Contains(skin.name))
        {
            if (coins >= skin.cost)
            {
                coins -= skin.cost;

                ownedSkinsString = ownedSkinsString + skin.name + ",";
                PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);
            }
            else
            {
                // Not enough coins
                return;
            }
        }

        PlayerPrefs.SetString("SkinInUse", skin.name);
        PlayerPrefs.SetInt("Coins", coins);
        UpdateSkinButtons();
    }
    private void UpdateSkinButtons()
    {
        string skinInUse = PlayerPrefs.GetString("SkinInUse", ASTRONAUT);
        string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
        string[] ownedSkins = ownedSkinsString.Split(',');

        foreach (Skin skin in skins)
        {
            if (ownedSkins.Contains(skin.name))
            {
                if (skin.name == skinInUse)
                {
                    skin.buttonText.text = "In use";
                }
                else
                {
                    skin.buttonText.text = "Choose";
                }
            }
            else
            {
                skin.buttonText.text = "Unlock for: " + skin.cost.ToString();
            }
        }
    }








    //private void Start()
    //{
    //    PlayerPrefs.DeleteKey("OwnedSkins");
    //    UpdateSkinButtons();
    //    astronautButton.onClick.AddListener(BuyAstronautSkin);
    //    homelessButton.onClick.AddListener(BuyHomelessSkin);
    //    cyclistButton.onClick.AddListener(BuyCyclistSkin);
    //    //astronautButtonText.transform.parent.GetComponent<Button>().onClick.AddListener(SelectAstronautSkin);
    //    //homelessButtonText.transform.parent.GetComponent<Button>().onClick.AddListener(SelectHomelessSkin);
    //}

    //private void UpdateSkinButtons()
    //{
    //    string skinInUse = PlayerPrefs.GetString("SkinInUse", ASTRONAUT);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');

    //    Dictionary<string, (TextMeshProUGUI, int)> buttonMap = new Dictionary<string, (TextMeshProUGUI, int)>()
    //{
    //    { ASTRONAUT, (astronautButtonText, ASTRONAUT_COST) },
    //    { HOMELESS, (homelessButtonText, HOMELESS_COST) },
    //    { CYCLIST,(cyclistButtonText, CYCLIST_COST)}
    //};
    //    coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    //    foreach (string skin in buttonMap.Keys)
    //    {
    //        if (ownedSkins.Contains(skin))
    //        {
    //            if (skin == skinInUse)
    //            {
    //                buttonMap[skin].Item1.text = "In use";
    //            }
    //            else
    //            {
    //                buttonMap[skin].Item1.text = "Choose";
    //            }
    //        }
    //        else
    //        {
    //            buttonMap[skin].Item1.text = "Unlock for: " + buttonMap[skin].Item2.ToString();
    //        }
    //    }
    //}

    //private void BuyAstronautSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(ASTRONAUT))
    //    {
    //        if (coins >= ASTRONAUT_COST)
    //        {
    //            coins -= ASTRONAUT_COST;




    //            ownedSkinsString = ownedSkinsString + ASTRONAUT + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //            PlayerPrefs.SetInt("Coins", coins);
    //            UpdateSkinButtons();

    //        }
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //        UpdateSkinButtons();
    //    }
    //}
    //private void BuyCyclistSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(CYCLIST))
    //    {
    //        if (coins >= CYCLIST_COST)
    //        {
    //            coins -= CYCLIST_COST;




    //            ownedSkinsString = ownedSkinsString + CYCLIST + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", CYCLIST);
    //            PlayerPrefs.SetInt("Coins", coins);
    //            UpdateSkinButtons();

    //        }
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetString("SkinInUse", CYCLIST);
    //        UpdateSkinButtons();
    //    }
    //}

    //private void BuyHomelessSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(HOMELESS))
    //    {
    //        if (coins >= HOMELESS_COST)
    //        {
    //            coins -= HOMELESS_COST;




    //            ownedSkinsString = ownedSkinsString + HOMELESS + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", HOMELESS);
    //            PlayerPrefs.SetInt("Coins", coins);
    //            UpdateSkinButtons();

    //        }
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetString("SkinInUse", HOMELESS);
    //        UpdateSkinButtons();
    //    }
    //}





























































    //private void BuyAstronautSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(ASTRONAUT))
    //    {
    //        if (coins >= 50)
    //        {
    //            coins -= 50;




    //            ownedSkinsString = ownedSkinsString + ASTRONAUT + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //            PlayerPrefs.SetInt("Coins", coins);
    //        }
    //    }
    //}

    //private void BuyHomelessSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(HOMELESS))
    //    {
    //        if (coins >= 100)
    //        {
    //            coins -= 100;




    //            ownedSkinsString = ownedSkinsString + HOMELESS + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", HOMELESS);
    //            PlayerPrefs.SetInt("Coins", coins);
    //        }
    //    }
    //}
    //public void SelectAstronautSkin()
    //{
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", ""); 
    //    string[] ownedSkins = ownedSkinsString.Split(',');

    //    if (ownedSkins.Contains(ASTRONAUT))
    //    {
    //        PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //        UpdateSkinButtons(); 
    //    }
    //    else
    //    {
    //        int coins = PlayerPrefs.GetInt("Coins", 0);
    //        if (coins >= ASTRONAUT_COST)
    //        {
    //            coins -= ASTRONAUT_COST;
    //            PlayerPrefs.SetInt("Coins", coins); 
    //            ownedSkinsString += (ownedSkinsString == "" ? "" : ",") + ASTRONAUT; 
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);
    //            PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //            UpdateSkinButtons(); 
    //            coinsAmount.text = coins.ToString();
    //        }
    //        else
    //        {
    //            Debug.Log("Not enough coins to buy skin");
    //        }
    //    }
    //}

    //public void SelectHomelessSkin()
    //{
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');

    //    if (ownedSkins.Contains(HOMELESS))
    //    {
    //        PlayerPrefs.SetString("SkinInUse", HOMELESS);
    //        UpdateSkinButtons();
    //    }
    //    else
    //    {
    //        int coins = PlayerPrefs.GetInt("Coins", 0);
    //        if (coins >= HOMELESS_COST)
    //        {
    //            coins -= HOMELESS_COST;
    //            PlayerPrefs.SetInt("Coins", coins); 
    //            ownedSkinsString += (ownedSkinsString == "" ? "" : ",") + HOMELESS; 
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString); 
    //            PlayerPrefs.SetString("SkinInUse", HOMELESS); 
    //            UpdateSkinButtons(); 
    //            coinsAmount.text = coins.ToString(); 
    //        }
    //        else
    //        {
    //            Debug.Log("Not enough coins to buy skin");
    //        }
    //    }
    //}

    /////////////////////////////////////////////////////////////////////
    //[SerializeField] TextMeshProUGUI homelessButtonText;
    //    [SerializeField] TextMeshProUGUI coinsAmount;

    //private const string ASTRONAUT = "astronaut";
    //private const string HOMELESS = "homeless";

    //private void Start()
    //{

    //    string skinInUse = PlayerPrefs.GetString("SkinInUse", ASTRONAUT); // ustawienie domyœlnego skina w przypadku braku zapisu
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", ""); // ustawienie pustego stringa w przypadku braku zapisu
    //    string[] ownedSkins = ownedSkinsString.Split(',');

    //    Dictionary<string, TextMeshProUGUI> buttonMap = new Dictionary<string, TextMeshProUGUI>()
    //    {
    //        { ASTRONAUT, astronautButtonText },
    //        { HOMELESS, homelessButtonText }
    //    };

    //    foreach (string skin in buttonMap.Keys)
    //    {
    //        if (ownedSkins.Contains(skin))
    //        {
    //            if (skin == skinInUse)
    //            {
    //                buttonMap[skin].text = "In use";
    //            }
    //            else
    //            {
    //                buttonMap[skin].text = "Choose";
    //            }
    //        }
    //        else
    //        {
    //            buttonMap[skin].text = "Unlock";
    //        }
    //    }
    //}
    //private void Update()
    //{
    //    coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    //}






}
