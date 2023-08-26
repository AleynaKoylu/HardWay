using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject Coin;
    [SerializeField]
    GameObject Log;
    [SerializeField]
    GameObject Magnet;
    [SerializeField]
    GameObject Ston;
    [SerializeField]
    GameObject Car;

    List<GameObject> Coins = new List<GameObject>();
    List<GameObject> Others = new List<GameObject>();

    [SerializeField]
    GameObject Child;

    [SerializeField]
    ChildScript childScript;
    int score;

   
    void Start()
    {
        instantiate(Coin,30, Coins);
        instantiate(Log, 5, Others);
        instantiate(Magnet, 5, Others);
        instantiate(Ston, 5, Others);
        instantiate(Car, 5, Others);
        InvokeRepeating("ShowCoin", 0, .5f);
        InvokeRepeating("ShowObstacles", 0, 5f);    
    }
    void instantiate(GameObject gObject, int count,List<GameObject> list)
    {

        for (int i = 0; i < count; i++)
        {
            GameObject nGObject = Instantiate(gObject);
            nGObject.SetActive(false);
            list.Add(nGObject);
        }
    }
   
    void ShowCoin()
    {
        foreach (var c in Coins)
        {
            if (c.activeSelf == false)
            {
                
                
                c.SetActive(true);
                int transformx = Random.Range(0, 2);
                if (transformx == 0)
                {
                    c.transform.position = new Vector3(-1.3f, .75f, Child.transform.position.z + 10f);
                }
                if (transformx == 1)
                {
                    c.transform.position = new Vector3(1.5f, .75f, Child.transform.position.z + 10f);
                }
                return;
            }
        }
    }
    void ShowObstacles()
    {

            int oID = Random.Range(0, Others.Count);
        
            if (Others[oID].activeSelf == false)
            {
                 Others[oID].SetActive(true);
                 int transformx = Random.Range(0, 2);
                 if (transformx == 0)
                 {
                     Others[oID].transform.position = new Vector3(-1.3f, Others[oID].transform.position.y, Child.transform.position.z +10f);
                 }
                 if (transformx == 1)
                 {
                     Others[oID].transform.position = new Vector3(1.5f, Others[oID].transform.position.y, Child.transform.position.z + 10f);
                 }
                 if (childScript.takeMagnet == true)
                 {
                    if (Others[oID].CompareTag("Magnet"))
                    {
                        Others[oID].SetActive(false);
                    }
                 }  
           
                  
            }
            else
            {
                int oID2 = Random.Range(0, Others.Count);
                Others[oID2].SetActive(true);
                int transformx = Random.Range(0, 2);
                if (transformx == 0)
                {
                    Others[oID2].transform.position = new Vector3(-1.3f, Others[oID2].transform.position.y, Child.transform.position.z + 5f);
                }
                if (transformx == 1)
                {
                    Others[oID2].transform.position = new Vector3(1.5f, Others[oID2].transform.position.y, Child.transform.position.z + 5f);
                }
                
            
                if (childScript.takeMagnet == true)
                {
                    if (Others[oID2].CompareTag("Magnet"))
                    {
                        Others[oID2].SetActive(false);
                    }
                }
            return;
            }
    }
    
    public void AddScore(int value)
    {
        score += value;
        ReturnScore();
        Debug.Log(score);
    }
    public int ReturnScore()
    {
        return score;
    }

    void Update()
    {
        
    }
}
