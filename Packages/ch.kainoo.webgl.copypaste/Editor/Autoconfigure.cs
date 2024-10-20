using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Autoconfigure
{
    static readonly string DEFINE_SYMBOL = "WEBGL_COPY_AND_PASTE_SUPPORT_TEXTMESH_PRO";

    static ListRequest listRequest;

    [InitializeOnLoadMethod]
    static void SubscribeToEvent()
    {
        CheckForTextMeshPro();
    }

    static void CheckForTextMeshPro()
    {
        // Request the list of installed packages
        listRequest = Client.List(); 
        EditorApplication.update += OnPackageListRequestUpdate;
    }

    static void OnPackageListRequestUpdate()
    {
        // Wait until the listRequest is complete
        if (listRequest.IsCompleted)
        {
            if (listRequest.Status == StatusCode.Success)
            {
                bool found = false;

                // Iterate through installed packages and check if TextMeshPro is installed
                foreach (var package in listRequest.Result)
                {
                    if (package.name == "com.unity.textmeshpro")
                    {
                        // Add scripting define symbol if TextMeshPro is installed
                        SetDefineSymbol(DEFINE_SYMBOL, true);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    SetDefineSymbol(DEFINE_SYMBOL, false);
                }
            }
            else if (listRequest.Status >= StatusCode.Failure)
            {
                Debug.LogError("Failed to list packages: " + listRequest.Error.message);
            }

            EditorApplication.update -= OnPackageListRequestUpdate;
        }
    }

    static void SetDefineSymbol(string symbol, bool enabled = true)
    {
        var defines = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.WebGL)
            .Split(';')
            .ToList();

        if (!defines.Contains(symbol) && enabled)
        {
            defines.Add(symbol);

            PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.WebGL, string.Join(';', defines));
        }
        else if (defines.Contains(symbol) && !enabled)
        {
            defines.Remove(symbol);
            PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.WebGL, string.Join(';', defines));
        }
    }
}
