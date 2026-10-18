using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float thoiGianChoPhepVeDich = 30f;
    public bool ketThucGame = false;
    public bool winGame = false;
    private static GameManager instance;
    public GameObject gameOverObject;
    public GameObject timeGameObject;
    public GameObject winGameObject;
    [SerializeField]
    private float thoiGianHoiKhiQuaCheckPoint = 31f;


    public static GameManager Instance
    {
        get
        {
            if(instance == null )
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject gameManagerGameOject = new GameObject("GameManager");
                    instance = gameManagerGameOject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private void Update()
    {
        if (!ketThucGame) 
            {
            thoiGianChoPhepVeDich -= Time.deltaTime;
            Debug.Log(thoiGianChoPhepVeDich);
            if(thoiGianChoPhepVeDich <=0)
            {
                timeGameObject.SetActive(false);
                gameOverObject.SetActive(true);
                KetThucGame();
            }
        }
        if (winGame)
        {
            timeGameObject.SetActive(false);
            winGameObject.SetActive(true);
        }
    }
    public void KetThucGame()
    {
        ketThucGame = true;
    }
    public void QuaCheckPoint()
    {
        if(!ketThucGame)
        {
            thoiGianChoPhepVeDich = thoiGianHoiKhiQuaCheckPoint;
        }
    }   
    public void QuaWinPoint()
    {
        if (!ketThucGame)
        {
            winGame = true;
        }
    }
}
