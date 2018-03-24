using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Newtonsoft.Json;

public static partial class MyPrefs
{
    static MyPrefs()
    {
        //If any prefs don't exsist, give them their default values

        if (!Exists(Prefs.RawToken))
            SetPref(Prefs.RawToken, "");
    }

    /// <summary>
    /// Gets a value from a given PlayerPref
    /// </summary>
    /// <typeparam name="T">The type of the object being gotten</typeparam>
    /// <param name="pref">The PlayerPref to read the value from</param>
    /// <returns>The found value of the PlayerPref</returns>
    public static T GetPref<T>(Prefs pref)
    {
        return JsonConvert.DeserializeObject<T>(PlayerPrefs.GetString(pref.ToString()));
    }

    /// <summary>
    /// Sets a value to a given PlayerPref
    /// </summary>
    /// <typeparam name="T">The type of the object being set</typeparam>
    /// <param name="pref">The PlayerPref to assign the value to</param>
    /// <param name="value">The value the PlayerPref is set to</param>
    public static void SetPref<T>(Prefs pref, T value)
    {
        PlayerPrefs.SetString(pref.ToString(), JsonConvert.SerializeObject(value));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Clears the value of a PlayerPref
    /// Note: It will still be in the pref Enum
    /// </summary>
    /// <param name="pref">The name of the PlayerPref</param>
    public static void Delete(Prefs pref)
    {
        PlayerPrefs.DeleteKey(pref.ToString());
    }

    /// <summary>
    /// Tests to see if a PlayerPref has a value
    /// </summary>
    /// <param name="pref">The name of the PlayerPref</param>
    /// <returns>True if it does have a value</returns>
    public static bool Exists(Prefs pref)
    {
        return PlayerPrefs.HasKey(pref.ToString());
    }
}
