using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setter : MonoBehaviour
{
    public GameObject City;
    public GameObject Reach;
    City Steve;
    City Dave;
    List<City> Cities;
    List<GameObject> reachObjects;
    // Start is called before the first frame update
    void Start()
    {
        reachObjects = new List<GameObject>();
        Cities = new List<City>();
        Steve = new City();
        Dave = new City(new Vector2(5, 5), 1, Sentiment.Chill);

        //Steve.ChatUp();
        initializeCity(Steve);
        initializeCity(Dave);


    }



    void initializeCity(City city)
    {


        Instantiate(City, city.cityPos, Quaternion.identity);
        for (int i = 0; i < city.reach.Count; i++)
        {
            GameObject g = Instantiate(Reach, city.reach[i].reachPos, Quaternion.identity);
            reachObjects.Add(g);

        }

    }

    void UpdateCity(City city, List<Vector2> changes)
    {

        for (int i = 0; i < changes.Count; i++)
        {

            GameObject g = Instantiate(Reach, changes[i], Quaternion.identity);
            reachObjects.Add(g);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<Vector2> changes = Steve.addReach();
            UpdateCity(Steve, changes);
            List<Vector2> morechanges = Dave.addReach();
            UpdateCity(Dave, morechanges);


        }
    }


}
