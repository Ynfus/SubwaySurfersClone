using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] Button cyclistButton;
    [SerializeField] Button actionHeroButton;
    [SerializeField] Button explorerButton;  
    [SerializeField] Button constructionWorkerButton;
    [SerializeField] Button clownButton;
    [SerializeField] Button eskimoButton;    
    [SerializeField] Button farmerButton;
    [SerializeField] Button paramedicButton;
    [SerializeField] Button policeButton;    
    [SerializeField] Button businessButton;
    [SerializeField] Button astronautButton;
    [SerializeField] Button clausButton;
    [SerializeField] Button cowboyButton;
    [SerializeField] Button firefighterButton;
    [SerializeField] Button hazardButton;  
    [SerializeField] Button mechanicButton;
    [SerializeField] Button mummyButton;
    [SerializeField] Button navalOfficerButton;    
    [SerializeField] Button pilotButton;
    [SerializeField] Button pirateButton;
    [SerializeField] Button raceDriverButton;    
    [SerializeField] Button skateButton;
    [SerializeField] Button skeletonButton;
    [SerializeField] Button skiManButton;
    [SerializeField] Button superHeroButton;
    [SerializeField] Button vikingButton;    
    [SerializeField] Button wizardButton;
    [SerializeField] Button yetiButton;
    [SerializeField] Button zombieButton;

    [SerializeField] TextMeshProUGUI cyclistButtonText;
    [SerializeField] TextMeshProUGUI actionHeroButtonText;
    [SerializeField] TextMeshProUGUI explorerButtonText;
    [SerializeField] TextMeshProUGUI constructionWorkerButtonText;
    [SerializeField] TextMeshProUGUI clownButtonText;
    [SerializeField] TextMeshProUGUI eskimoButtonText;
    [SerializeField] TextMeshProUGUI farmerButtonText;
    [SerializeField] TextMeshProUGUI paramedicButtonText;
    [SerializeField] TextMeshProUGUI policeButtonText;
    [SerializeField] TextMeshProUGUI businessButtonText;
    [SerializeField] TextMeshProUGUI astronautButtonText;
    [SerializeField] TextMeshProUGUI clausButtonText;
    [SerializeField] TextMeshProUGUI cowboyButtonText;
    [SerializeField] TextMeshProUGUI firefighterButtonText;
    [SerializeField] TextMeshProUGUI hazardButtonText;
    [SerializeField] TextMeshProUGUI mechanicButtonText;
    [SerializeField] TextMeshProUGUI mummyButtonText;
    [SerializeField] TextMeshProUGUI navalOfficerButtonText;
    [SerializeField] TextMeshProUGUI pilotButtonText;
    [SerializeField] TextMeshProUGUI pirateButtonText;
    [SerializeField] TextMeshProUGUI raceDriverButtonText;
    [SerializeField] TextMeshProUGUI skateButtonText;
    [SerializeField] TextMeshProUGUI skeletonButtonText;
    [SerializeField] TextMeshProUGUI skiManButtonText;
    [SerializeField] TextMeshProUGUI superHeroButtonText;
    [SerializeField] TextMeshProUGUI vikingButtonText;
    [SerializeField] TextMeshProUGUI wizardButtonText;
    [SerializeField] TextMeshProUGUI yetiButtonText;
    [SerializeField] TextMeshProUGUI zombieButtonText;
    
    
    [SerializeField] TextMeshProUGUI coinsAmount;


    private const string CYCLIST = "cyclist";
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
            new Skin("cyclist", 10, astronautButton, astronautButtonText),
            new Skin("actionHero", 10, actionHeroButton, actionHeroButtonText),
            new Skin("explorer", 10, explorerButton, explorerButtonText),
            new Skin("constructionWorker", 10, constructionWorkerButton, constructionWorkerButtonText),
            new Skin("clown", 10, clownButton, clownButtonText),
            new Skin("eskimo", 10, eskimoButton, eskimoButtonText),
            new Skin("farmer", 10, farmerButton, farmerButtonText),
            new Skin("paramedic", 10, paramedicButton, paramedicButtonText),
            new Skin("police", 10, policeButton, policeButtonText),
            new Skin("business", 10, businessButton, businessButtonText),
            new Skin("astronaut", 10, astronautButton, astronautButtonText),
            new Skin("claus", 10, clausButton, clausButtonText),
            new Skin("cowboy", 10, cowboyButton, cowboyButtonText),
            new Skin("fireFighter", 10, firefighterButton, firefighterButtonText),
            new Skin("hazard", 10, hazardButton, hazardButtonText),
            new Skin("mechanic", 10, mechanicButton, mechanicButtonText),
            new Skin("mummy", 10, mummyButton, mummyButtonText),
            new Skin("navalOfficer", 10, navalOfficerButton, navalOfficerButtonText),
            new Skin("pilot", 10, pilotButton, pilotButtonText),
            new Skin("pirate", 10, pirateButton, pirateButtonText),
            new Skin("raceDriver", 10, raceDriverButton, raceDriverButtonText),
            new Skin("skate", 10, skateButton, skateButtonText),
            new Skin("skeleton", 10, skeletonButton, skeletonButtonText),
            new Skin("skiMan", 10, skiManButton, skiManButtonText),
            new Skin("superHero", 10, superHeroButton, superHeroButtonText),
            new Skin("viking", 10, vikingButton, vikingButtonText),
            new Skin("wizard", 10, wizardButton, wizardButtonText),
            new Skin("yeti", 10, yetiButton, yetiButtonText),
            new Skin("zombie", 10, zombieButton, zombieButtonText),

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
        string skinInUse = PlayerPrefs.GetString("SkinInUse", CYCLIST);
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
        foreach (var item in ownedSkins)
        {
            Debug.Log(item);
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
