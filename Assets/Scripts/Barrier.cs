using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setTextState(false);
    }

   private void OnTriggerEnter(Collider other)
   {
        if (other.name == "Player")
        {
            Time.timeScale = 0;
            setTextState(true);
        }
   }
   void setTextState(bool state)
  {
       GameObject canvas = GameObject.Find("Canvas");
       canvas.transform.Find("WinPanel").gameObject.SetActive(false);
       canvas.transform.Find("LosePanel").gameObject.SetActive(state);
  }

}
