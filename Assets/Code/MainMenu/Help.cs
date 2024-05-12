
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
        Application.OpenURL("file:./Assets/Help/FQU.chm");
        print("click!");
    }
}
