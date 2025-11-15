using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

public void start(){
  //  print("test start");
}

 public void StartGame() {
    SceneManager.LoadScene("Martins Scene");
 //   Debug.Log("Button clicked");
}
}
