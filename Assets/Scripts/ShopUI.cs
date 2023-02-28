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
    [SerializeField] TextMeshProUGUI astronautButtonText;
    [SerializeField] TextMeshProUGUI homelessButtonText;
    [SerializeField] TextMeshProUGUI coinsAmount;

    private const string ASTRONAUT = "astronaut";
    private const string HOMELESS = "homeless";
    private const int ASTRONAUT_COST = 10;
    private const int HOMELESS_COST = 20;

    private void Start()
    {
        string skinInUse = PlayerPrefs.GetString("SkinInUse", ASTRONAUT);
        string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
        string[] ownedSkins = ownedSkinsString.Split(',');
        //PlayerPrefs.DeleteKey("OwnedSkins");
        Dictionary<string, TextMeshProUGUI> buttonMap = new Dictionary<string, TextMeshProUGUI>()
        {
            { ASTRONAUT, astronautButtonText },
            { HOMELESS, homelessButtonText }
        };

        foreach (string skin in buttonMap.Keys)
        {
            if (ownedSkins.Contains(skin))
            {
                if (skin == skinInUse)
                {
                    buttonMap[skin].text = "In use";
                }
                else
                {
                    buttonMap[skin].text = "Choose";
                }
            }
            else
            {
                buttonMap[skin].text = "Unlock";
            }
        }


        astronautButton.onClick.AddListener(BuyAstronautSkin);
        homelessButton.onClick.AddListener(BuyHomelessSkin);
        //astronautButtonText.transform.parent.GetComponent<Button>().onClick.AddListener(SelectAstronautSkin);
        //homelessButtonText.transform.parent.GetComponent<Button>().onClick.AddListener(SelectHomelessSkin);
    }

    private void Update()
    {
        coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }

    private void BuyAstronautSkin()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
        string[] ownedSkins = ownedSkinsString.Split(',');
        if (!ownedSkins.Contains(ASTRONAUT))
        {
            if (coins >= 50)
            {
                coins += 5000;




                ownedSkinsString = ownedSkinsString + ASTRONAUT + ",";
                PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


                PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
                PlayerPrefs.SetInt("Coins", coins);
                UpdateSkinButtons();

            }
        }
        else
        {
            PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
            UpdateSkinButtons();
        }
    }

    private void BuyHomelessSkin()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
        string[] ownedSkins = ownedSkinsString.Split(',');
        if (!ownedSkins.Contains(HOMELESS))
        {
            if (coins >= 100)
            {
                coins -= 100;




                ownedSkinsString = ownedSkinsString + HOMELESS + ",";
                PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


                PlayerPrefs.SetString("SkinInUse", HOMELESS);
                PlayerPrefs.SetInt("Coins", coins);
                UpdateSkinButtons();

            }
        }
        else
        {
            PlayerPrefs.SetString("SkinInUse", HOMELESS);
            UpdateSkinButtons();
        }
    }

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
    private void UpdateSkinButtons()
    {
        string skinInUse = PlayerPrefs.GetString("SkinInUse", ASTRONAUT);
        string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
        string[] ownedSkins = ownedSkinsString.Split(',');

        Dictionary<string, TextMeshProUGUI> buttonMap = new Dictionary<string, TextMeshProUGUI>()
    {
        { ASTRONAUT, astronautButtonText },
        { HOMELESS, homelessButtonText }
    };

        foreach (string skin in buttonMap.Keys)
        {
            if (ownedSkins.Contains(skin))
            {
                if (skin == skinInUse)
                {
                    buttonMap[skin].text = "In use";
                }
                else
                {
                    buttonMap[skin].text = "Choose";
                }
            }
            else
            {
                buttonMap[skin].text = "Unlock";
            }
        }
    }

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
