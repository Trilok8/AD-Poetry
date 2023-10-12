using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class optionsController : MonoBehaviour
{
    public Image correctImage;
    public Image wrongImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        correctImage.gameObject.SetActive(false);
        wrongImage.gameObject.SetActive(false);
    }

    public void resetOptions()
    {
        correctImage.gameObject.SetActive(false);
        wrongImage.gameObject.SetActive(false);
    }

    public void setCorrect()
    {
        correctImage.gameObject.SetActive(true);
    }

    public void setWrong()
    {
        wrongImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
