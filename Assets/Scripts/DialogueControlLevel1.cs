using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControlLevel1 : MonoBehaviour
{
    public RPGTalk rpgTalk;
    public GameObject PadReward;
    public GameObject MedicineReward;
    public GameObject Enemies;
    public GameObject Door;
    public GameObject Player;
    public TextMeshProUGUI SignText;
    public TextMeshProUGUI RedDudeText;
    public TextMeshProUGUI CrampDudeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.killCount == 1)
        {
            RedDudeText.text = "1/5";
        }

        if (Globals.killCount == 2)
        {
            RedDudeText.text = "2/5";
        }

        if (Globals.killCount == 3)
        {
            RedDudeText.text = "3/5";
        }

        if (Globals.killCount == 4)
        {
            RedDudeText.text = "4/5";
        }

        if (Globals.killCount == 5)
        {
            PadReward.SetActive(true);
            Player.GetComponent<MovementInput>().TakeControls();
            Globals.killCount = 6;
            rpgTalk.NewTalk("4", "4", rpgTalk.txtToParse);
            RedDudeText.text = "5/5";
        }

        if (Globals.killCount == 7)
        {
            CrampDudeText.text = "1/2";
        }

        if (Globals.killCount == 8)
        {
            MedicineReward.SetActive(true);
            Player.GetComponent<MovementInput>().TakeControls();
            Globals.killCount = 9;
            rpgTalk.NewTalk("8", "8", rpgTalk.txtToParse);
            CrampDudeText.text = "2/2";
        }
    }

    public void RewardPad()
    {
        PadReward.SetActive(false);
        Player.GetComponent<MovementInput>().GiveControls();
        Enemies.GetComponent<EnemySpawn>().EnemySpawnControlCramp();
        rpgTalk.NewTalk("6", "6", rpgTalk.txtToParse);
    }

    public void RewardMedicine()
    {
        MedicineReward.SetActive(false);
        Player.GetComponent<MovementInput>().GiveControls();
        rpgTalk.NewTalk("9", "9", rpgTalk.txtToParse);
        Door.SetActive(true);
    }

    public void Sign1Counter()
    {
        if (!Globals.Sign1)
        {
            Globals.Sign1 = true;
            if (SignText.text == "0/3")
            {
                SignText.text = "1/3";
                return;
            }
            if (SignText.text == "1/3")
            {
                SignText.text = "2/3";
            }
            else
            {
                SignText.text = "3/3";
            }
        }
    }

    public void Sign2Counter()
    {
        if (!Globals.Sign2)
        {
            Globals.Sign2 = true;
            if (SignText.text == "0/3")
            {
                SignText.text = "1/3";
                return;
            }
            if (SignText.text == "1/3")
            {
                SignText.text = "2/3";
            }
            else
            {
                SignText.text = "3/3";
            }
        }
    }

    public void Sign3Counter()
    {
        if (!Globals.Sign3)
        {
            Globals.Sign3 = true;
            if (SignText.text == "0/3")
            {
                SignText.text = "1/3";
                return;
            }
            if (SignText.text == "1/3")
            {
                SignText.text = "2/3";
            }
            else
            {
                SignText.text = "3/3";
            }
        }
    }
}
