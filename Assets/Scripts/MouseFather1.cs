using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MouseFather1 : MonoBehaviour
{
public void start(){
  //  print("test start");
}

 public void Father1() {
    SceneManager.LoadScene("MouseFather2");
 //   Debug.Log("Button clicked");
}
}