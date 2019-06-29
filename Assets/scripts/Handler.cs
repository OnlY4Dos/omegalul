using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Handler : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed;
    private Config conf = new Config();
    private string path;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;
    public bool jump;
    public float MS;
    private float maxHp = 100f;
    public float currHp;
    public Image img;

    void Awake()
    {
        path = Path.Combine(Application.dataPath,"Config.json");
        configChanged();
    }
    void Update()
    {
        HPBAR(maxHp, currHp);
        if(Input.GetKeyDown(Jump))
            jump = true;
        if(Input.GetKey(Right))
            MS = speed;
        else if(Input.GetKey(Left)) 
            MS = -1*speed;
        else MS = 0;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            configChanged();
        }
    }
    void FixedUpdate()
    {
        controller.Move(MS * Time.fixedDeltaTime,false,jump);
        jump = false;
    }
    void configChanged()
    {
        conf = JsonUtility.FromJson<Config>(File.ReadAllText(path));
        Right = (KeyCode)conf.Right;
        Left = (KeyCode)conf.Left;
        Jump = (KeyCode)conf.Jump;   
    }
    void HPBAR(float maxhp,float currhp)
    {
        img.fillAmount = currhp/maxhp;
    }
    [Serializable]
    public class Config
    {
        public KeyCode Right;
        public KeyCode Left;
        public KeyCode Jump;
    }

}
