using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Endpoint : MonoBehaviour, IEventSystemHandler
{
    // Start is called before the first frame update
    void Start()
    {
        setTextState(false);
    }

    private void OnTriggerEnter(Collider other)
   {
        setTextState(true);
   }

   void setTextState(bool state)
  {
      GameObject canvas = GameObject.Find("Canvas");
      canvas.transform.Find("WinPanel").gameObject.SetActive(state);
      canvas.transform.Find("LosePanel").gameObject.SetActive(false);
  }

}