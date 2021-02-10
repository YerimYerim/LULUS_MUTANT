using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
   public static ItemDatabase instance;
   public void Awake()
   {
      instance = this;
   }

   public List<Item> itemDB = new List<Item>();
}
