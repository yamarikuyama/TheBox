using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    public const int COLOR_GREEN = 0;
    public const int COLOR_RED = 1;
    public const int COLOR_BLUE = 2;
    public const int COLOR_WHITE = 3;

    public GameObject panelWalls;

    public GameObject buttonHammer;
    public GameObject buttonKey;

    public GameObject imageHammerIcon;
    public GameObject imageKeyIcon;

    public GameObject buttonPig;

    public GameObject buttonMessage;
    public GameObject buttonMessageText;

    public GameObject[] buttonLamp = new GameObject[3];

    public Sprite[] buttonPicture = new Sprite[4];

    public Sprite hammerPicture;
    public Sprite keyPicture;

    private int wallNo;
    private bool doesHaveHammer;
    private bool doesHaveKey;
    private int[] buttonColor = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT;
        doesHaveHammer = false;
        doesHaveKey = false;

        buttonColor[0] = COLOR_GREEN;
        buttonColor[1] = COLOR_RED;
        buttonColor[2] = COLOR_BLUE;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pushButtonBox()
    {
        if (doesHaveKey == false)
        {
            DisplayMessage("鍵がかかっている。");
        }
        else
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    public void pushButtonLamp1()
    {
        ChangeButtonColor(0);
    }

    public void pushButtonLamp2()
    {
        ChangeButtonColor(1);
    }

    public void pushButtonLamp3()
    {
        ChangeButtonColor(2);
    }

    void ChangeButtonColor(int buttonNo)
    {
        buttonColor[buttonNo]++;

        if(buttonColor[buttonNo] > COLOR_WHITE)
        {
            buttonColor[buttonNo] = COLOR_GREEN;
        }

        buttonLamp[buttonNo].GetComponent<Image>().sprite =
            buttonPicture[buttonColor[buttonNo]];

        if((buttonColor[0]==COLOR_BLUE)&&
            (buttonColor[1]==COLOR_WHITE)&&
            (buttonColor[2] == COLOR_RED))
        {
            if (doesHaveHammer == false)
            {
                DisplayMessage("金庫の中にトンカチが入っていた。");
                buttonHammer.SetActive(true);
                imageHammerIcon.GetComponent<Image>().sprite = hammerPicture;

                doesHaveHammer = true;
            }
        }
    }

    public void PushButtonMemo()
    {
        DisplayMessage("エッフェル塔と書いてある。");
    }

    public void pushButtonPig()
    {
        if (doesHaveHammer == false)
        {
            DisplayMessage("素手では触れない。");
        }
        else
        {
            DisplayMessage("貯金箱が割れて中から鍵が出てきた。");

            buttonPig.SetActive(false);
            buttonKey.SetActive(true);
            imageKeyIcon.GetComponent<Image>().sprite = keyPicture;

            doesHaveKey = true;
        }
    }

    public void pushButtonHammer()
    {
        buttonHammer.SetActive(false);
    }

    public void pushButtonKey()
    {
        buttonKey.SetActive(false);
    }

    public void PushButtonMessage()
    {
        buttonMessage.SetActive(false);
    }

    public void PushButtonRight()
    {
        wallNo++;

        if (wallNo > WALL_LEFT)
        {
            wallNo = WALL_FRONT;
        }
        DisplayWall();
        ClearButtons();
    }

    public void PushButtonLeft()
    {
        wallNo--;

        if (wallNo < WALL_FRONT)
        {
            wallNo = WALL_LEFT;
        }
        DisplayWall();
        ClearButtons();
    }

    void ClearButtons()
    {
        buttonHammer.SetActive(false);
        buttonKey.SetActive(false);
        buttonMessage.SetActive(false);
    }

    void DisplayMessage(string mes)
    {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }

    void DisplayWall()
    {
        switch (wallNo)
        {
            case WALL_FRONT:
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK:
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEFT:
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;

        }
    }
}
