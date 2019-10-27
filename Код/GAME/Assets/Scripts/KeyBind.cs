using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyBind : MonoBehaviour
{
    private Dictionary<string, KeyCode> dict = new Dictionary<string, KeyCode>();
    public Text left, right, jump, teleport, block, attack;
    private GameObject inputKey;
    void Start()
    {
        InitializeDictionary();
    }

    public void InitializeDictionary()
    {
        dict.Add("MoveLeft", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeft", "A")));
        dict.Add("MoveRight", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRight", "D")));
        dict.Add("Jump", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
        dict.Add("Teleport", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Teleport", "F")));
        dict.Add("Block", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Block", "R")));
        dict.Add("Attack", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack", "Mouse0")));
        left.text = dict["MoveLeft"].ToString();
        right.text = dict["MoveRight"].ToString();
        jump.text = dict["Jump"].ToString();
        teleport.text = dict["Teleport"].ToString();
        block.text = dict["Block"].ToString();
        attack.text = dict["Attack"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if (inputKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                dict[inputKey.name] = e.keyCode; 
                inputKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                inputKey = null;
            }
            if (e.isMouse)
            {
                //Наговнокодил, потому что e.keyCode не считывает код клавиш мыши
                switch(e.button)
                {
                    case 0:
                        dict[inputKey.name] = KeyCode.Mouse0;
                        inputKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse0.ToString();
                        inputKey = null;
                        break;
                    case 1:
                        dict[inputKey.name] = KeyCode.Mouse1;
                        inputKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse1.ToString();
                        inputKey = null;
                        break;
                    case 2:
                        dict[inputKey.name] = KeyCode.Mouse2;
                        inputKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse2.ToString();
                        inputKey = null;
                        break;
                    case 3:
                        dict[inputKey.name] = KeyCode.Mouse3;
                        inputKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse3.ToString();
                        inputKey = null;
                        break;
                    case 4:
                        dict[inputKey.name] = KeyCode.Mouse4;
                        inputKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse4.ToString();
                        inputKey = null;
                        break;
                    case 5:
                        dict[inputKey.name] = KeyCode.Mouse5;
                        inputKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse5.ToString();
                        inputKey = null;
                        break;
                    case 6:
                        dict[inputKey.name] = KeyCode.Mouse6;
                        inputKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.Mouse6.ToString();
                        inputKey = null;
                        break;
                }
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        inputKey = clicked;
    }

    public void SaveControls()
    {
        foreach(var key in dict)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }

    public bool GetKeyDown(string key)
    {
        return Input.GetKeyDown(dict[key]);
    }

    public bool GetKey(string key)
    {
        return Input.GetKey(dict[key]);
    }
}
