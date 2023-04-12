
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Char_inv : MonoBehaviour {

  const int INVENTORY_WINDOW_ID = 1; //id окна инвентаря

  public float ButtonWidth = 20; //высота ячейки
  public float ButtonHeight = 20; //ширина ячейки

  int invRows = 3; //количество колонок
  int invColumns = 12; //количество столбцов
  Rect inventoryWindowRect = new Rect(10, 150,
  850, 250); //область окна
  bool isDraggable; //перемещается ли айтем?
  Item selectItem; //вспомогательная переменная куда заносим предмет инвентаря
  Texture2D dragTexture; //текстура которая отображается при перетягивании предмета в инвентаре

  Dictionary<int, Item> InventoryPlayer = new Dictionary<int, Item>(); //словарь содержащий предметы инвентаря

    void Start () {
  }
   
  // Update is called once per frame
  void Update () {
   
  }

  void OnGUI()
  {
  inventoryWindowRect = GUI.Window(INVENTORY_WINDOW_ID, inventoryWindowRect, firstInventory, "INVENTORY"); //создаем окно
  }

  void firstInventory(int id)
  {
  for (int i = 0; i < 30; i++)
  {
  for (int y = 0; y < invRows; y++)
  {
  for (int x = 0; x < invColumns; x++)
  {
  if (InventoryPlayer.ContainsKey(x + y * invColumns))//проверяем содеоржится ли ключ с данным значением
  {
  if (GUI.Button(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), new GUIContent(InventoryPlayer[x + y * invColumns].Textura), "button"))
  {
  if (!isDraggable)
  {
  dragTexture = InventoryPlayer[x + y * invColumns].Textura;//присваиваем нашой текстуре которая должна отображаться при перетаскивании, текстуру предмета
  isDraggable = true;//возможность перемещать предмет
  selectItem = InventoryPlayer[x + y * invColumns];//присваиваем вспомогательной переменной наш предмет
  InventoryPlayer.Remove(x + y * invColumns);//удаляем из словаря предмет
  }
  }
  }
  else
  {
  if (isDraggable)
  {
  if (GUI.Button(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), "", "button"))
  {
  InventoryPlayer.Add(x + y * invColumns, selectItem);//добавляем предмет который перетаскиваем в словарь
  //обнуляем переменные
  isDraggable = false;
  selectItem = null;
  }
  }
  else
  {
  GUI.Label(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), "", "button");
  }
  }
  }
  }
  }
   
  }
}
