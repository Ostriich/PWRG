using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    [SerializeField] private Country country;
    [SerializeField] private GameObject[] gallery;
    [SerializeField] private GameObject nameGallery, container;

    public void SetPhotos(string cityName)
    {
        container.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        for (int i = 0; i < 4; i++)
        {
            if (country.cities[i].name==cityName)
            {
                nameGallery.GetComponent<Text>().text = cityName;

                for (int j = 0; j < 5; j++)
                {
                    gallery[j].GetComponent<Image>().sprite = country.cities[i].photos[j].photo;
                }
                break;
            }
        }
    }

    public void CloseGallery()
    {
        gameObject.SetActive(false);
    }
}

[System.Serializable]
public class Country
{
    public List<City> cities;

    [System.Serializable]
    public class City
    {
        public string name;
        public List<Photo> photos;
    }

    [System.Serializable]
    public class Photo
    {
        public Sprite photo;
    }
}

