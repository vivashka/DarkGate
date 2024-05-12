
using System.Diagnostics;
using System.IO;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Help : MonoBehaviour
{

    private void Start()
    {
        
    }

    public void OnClick()
    {
        Application.OpenURL("https://docs.google.com/document/d/1uMaF01aMjymAaV12Um5P0WS4f4zoJB1p-7vfp-l2ZRw/edit#bookmark=id.gjdgxs");
        print("click!");
    }
}
