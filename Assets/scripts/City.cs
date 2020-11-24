using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Sentiment
{
    Pushover,
    Chill,
    Proud,
    Psycho
}

public enum ReachDir
{
    NORTH,
    SOUTH,
    EAST,
    WEST,
    NORTHEAST,
    NORTHWEST,
    SOUTHEAST,
    SOUTHWEST
}

public struct Reach
{
    public ReachDir reachDir;
    public Vector2 reachPos;

    public Reach(ReachDir _rd, Vector2 _rp)
    {
        reachDir = _rd;
        reachPos = _rp;
    }
}

public class City
{
    public Reach reachStr;

    public Vector2 cityPos;
    public List<Reach> reach;
    public Sentiment sentiment;
    public int currentReachCount;

    public City()
    {
        cityPos = new Vector2(0, 0);
        reach = new List<Reach>();
        sentiment = Sentiment.Proud;

        Vector2[] startReach = new Vector2[]
        {
            cityPos + new Vector2 (0,1),
            cityPos + new Vector2(0, -1),
            cityPos + new Vector2(1, 0),
            cityPos + new Vector2(-1, 0),
        };


        for (int i = 0; i < startReach.Length; i++)
        {
            reachStr = new Reach((ReachDir)i, startReach[i]);
            reach.Add(reachStr);

        }
    }

    public City(Vector2 _cityPos, int initialReach, Sentiment _sentiment)
    {
        cityPos = _cityPos;
        reach = new List<Reach>();
        sentiment = _sentiment;

        Vector2[] startReach = new Vector2[]
       {
            cityPos + new Vector2 (0,initialReach),
            cityPos + new Vector2(0, -initialReach),
            cityPos + new Vector2(initialReach, 0),
            cityPos + new Vector2(-initialReach, 0),
       };


        for (int i = 0; i < startReach.Length; i++)
        {
            reachStr = new Reach((ReachDir)i, startReach[i]);
            reach.Add(reachStr);

        }

    }

    public void ChatUp()
    {
        Debug.Log("City position: " + cityPos);

        for (int i = 0; i < reach.Count; i++)
        {
            Debug.Log("Reach Direction" + i + ": " + reach[i].reachDir);
            Debug.Log("Reach Position" + i + ": " + reach[i].reachPos);


        }
        Debug.Log("Sentiment: " + sentiment);
    }

    public List<Vector2> addReach()//right now all cities get reach regardless. Not good tho
    {
        currentReachCount = reach.Count;
        /*
         * The problem is somewhere here, because you are adding reach to every single instance of reach instead of just those on the outside
         * You need to store all the last spawned reach (and eventually find a way to go back through it when it gets destroyed) and use that
         * as the basis point for calculating new reach
         * 
         * */
        List<Vector2> newReach = new List<Vector2>();
        for (int i = 0; i < currentReachCount; i++)
        {
            Vector2 newReachPos = addReachPosition(reach[i]);
            reachStr = new Reach(reach[i].reachDir, newReachPos);
            reach.Add(reachStr);
            newReach.Add(reachStr.reachPos);
        }
        foreach (var thing in newReach)
        {
            Debug.Log(thing);
        }

        return newReach;

    }

    Vector2 addReachPosition(Reach reach)
    {
        Vector2 pos;

        switch (reach.reachDir)
        {
            case ReachDir.NORTH:
                pos = reach.reachPos + new Vector2(0, 1);
                break;
            case ReachDir.SOUTH:
                pos = reach.reachPos + new Vector2(0, -1);
                break;
            case ReachDir.EAST:
                pos = reach.reachPos + new Vector2(1, 0);
                break;
            case ReachDir.WEST:
                pos = reach.reachPos + new Vector2(-1, 0);
                break;
            default:
                pos = new Vector2(0, 0);
                break;
        }

        return pos;

    }






}
