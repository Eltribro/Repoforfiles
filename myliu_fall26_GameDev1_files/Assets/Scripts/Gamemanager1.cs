using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using TMPro;
public class GameManager1 : MonoBehaviour
{
    //veriables
    //create a number for the score
    private int score;

    //add input refereces for interacting with score and saving 
    public InputActionReference scoreplus;
    public InputActionReference save;
    public InputActionReference clear;
    //set the folder path
    private const string DIR_RES = "/Resources";
    //set a file to read
    private const string FILE_SAVE =DIR_RES + "/Saves.txt";
    //create tyhe file path
    private string FILE_PATH_SAVE;
    //make a veriable to hold the int as a string
    public string inputnum;

    //add text messt pro varible for previos scores and one current score
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI savedScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //declare the file path 
        FILE_PATH_SAVE = Application.dataPath + FILE_SAVE;

        //set the score 
        score = 0;

        //show all the saved scores
        savedScore.text = File.ReadAllText(FILE_PATH_SAVE);
    }

    // Update is called once per frame
    void Update()
    {
       // show the score 
       currentScore.text = "" + score;
        //if I press a buttom socre goes up by 1
        if(scoreplus.action.WasPressedThisFrame())
        {
            score++;
        }
        //if I press a button run the save function
        if(save.action.WasPressedThisFrame())
        {
            Savescore(score);
            score = 0;
            savedScore.text = File.ReadAllText(FILE_PATH_SAVE);
        }
        //if I press a button this frame clear all saves
        if(clear.action.WasPressedThisFrame())
        {
            Clearsaves();
        }
    }
        public void Savescore(int s)
{
    inputnum = s.ToString();
    string fileContents = File.ReadAllText(FILE_PATH_SAVE);
    fileContents += inputnum + "\n";
    File.WriteAllText(FILE_PATH_SAVE,fileContents);
}

public void Clearsaves()
{
  File.WriteAllText(FILE_PATH_SAVE,"");  
}



}



