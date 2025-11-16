using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMissionButton : MonoBehaviour
{

public void start(){
  //  print("test start");
}

 public void StartMission() {
    SceneManager.LoadScene("SampleScene");
 //   Debug.Log("Button clicked");
}
}
