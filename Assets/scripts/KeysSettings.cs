using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class KeysSettings : MonoBehaviour
{
    //Сюда лучше не лазить это ваще шок ебаный(я предупреждал)
    #region Var
    private Config conf = new Config();
    private string path;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right =  KeyCode.D;
    public KeyCode Jump = KeyCode.Space;
    public bool IsPaused;
    public Text txtLeft;
    public Text txtJump;
    public Text txtRight;
    public Button ButtonLeft;
    public Button ButtonJump;
    public Button ButtonRight;
    public Button ButtonSave;
    public bool lbClicked = false;
    public bool rbClicked = false;
    public bool jbClicked = false;

    #endregion
    void Awake()
    {     
        path = Path.Combine(Application.dataPath,"Config.json");
        ControlIni();  
        conf = JsonUtility.FromJson<Config>(File.ReadAllText(path));       
    }
    void ControlIni()
    {   
        if(!File.Exists(path))
            Defaults();           
    }
    void Start()
    {      
        txtLeft.text = Left.ToString();
        txtRight.text = Right.ToString();
        txtJump.text = Jump.ToString();
        ButtonLeft.onClick.AddListener(onClickLeft);
        ButtonRight.onClick.AddListener(onClickRight);
        ButtonJump.onClick.AddListener(onClickJump);
        ButtonSave.onClick.AddListener(onClickSave);
        Left = conf.Left;
        Right = conf.Right;
        Jump = conf.Jump;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
            Defaults();
        }   
        txtLeft.text = Left.ToString();
        txtRight.text = Right.ToString();
        txtJump.text = Jump.ToString();        
    }
    void Defaults()
    {
        conf.Left = Left;
        conf.Right =  Right;
        conf.Jump = Jump;
        File.WriteAllText(path, JsonUtility.ToJson(conf));
    }
    public void changes(KeyCode left,KeyCode right,KeyCode jump)
    {
        conf.Left = left;
        conf.Right = right;
        conf.Jump = jump;
        File.WriteAllText(path, JsonUtility.ToJson(conf));
    }
    public void onClickLeft()
    {
        lbClicked = true;
    }
    public void onClickRight()
    {
        rbClicked = true;
    }
    public void onClickJump()
    {
        jbClicked = true;
    }
    public void onClickSave()
    {
        changes(Left,Right,Jump);
    }
    public void OnGUI()
    {
        if(lbClicked)
        {
            Left = KeyCode.None;
            if(Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
            {
                Left = Event.current.keyCode;                
                lbClicked = false;
            }           
        }
        if(rbClicked)
        {
            Right = KeyCode.None;
            if(Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
            {
                Right = Event.current.keyCode;                 
                rbClicked = false;
            }           
        }
        if(jbClicked)
        {
            Jump = KeyCode.None;
            if(Event.current.keyCode != KeyCode.Escape && Event.current.keyCode != KeyCode.None)
            {
                Jump = Event.current.keyCode;                
                jbClicked = false;
            }           
        }
    }
    public class Config
    {
        public KeyCode Right;
        public KeyCode Left;
        public KeyCode Jump;
    }
}
