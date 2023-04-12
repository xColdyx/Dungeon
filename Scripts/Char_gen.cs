using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_gen : MonoBehaviour
{
public GameObject bodyModel;
public Material[] mat;
public Sprite[] faceSprites;

private GameObject bodyInstance;
private SpriteRenderer faceRenderer;

void Start()
{
// Создание 3D модели тела
int randomSkinIndex = Random.Range(0, 10);
bodyModel.GetComponent<MeshRenderer>().material = mat[randomSkinIndex];
bodyInstance = Instantiate(bodyModel, transform);


// Подбор случайного рисунка лица
int randomFaceIndex = Random.Range(0, faceSprites.Length);
Sprite randomFaceSprite = faceSprites[randomFaceIndex];

// Создание рисунка лица
GameObject faceObject = new GameObject("Face");
faceRenderer = faceObject.AddComponent<SpriteRenderer>();
faceRenderer.sprite = randomFaceSprite;
faceObject.transform.SetParent(bodyInstance.transform);
faceObject.transform.localPosition = new Vector3(0f, 1f, 0f);
}

// Метод для изменения рисунка лица
public void ChangeFace()
{
int randomFaceIndex = Random.Range(0, faceSprites.Length);
Sprite randomFaceSprite = faceSprites[randomFaceIndex];
faceRenderer.sprite = randomFaceSprite;
}
}