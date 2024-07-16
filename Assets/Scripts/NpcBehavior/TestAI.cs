using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TestAI : MonoBehaviour
{
    public Transform testDestination;
    public NavMeshAgent agent;
    public Vector3 testOffset;

    public List<GameObject> roomZones;
    public Dictionary<string, string> timeTable = new Dictionary<string, string>
    {
        {"1:00 AM", "Morning Routine"}, {"2:00 AM", "Food"},
        {"3:00 AM", "Morning Routine"}, {"4:00 AM", "Food"},
        {"5:00 AM", "Morning Routine"}, {"6:00 AM", "Food"}
    };

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    string ParseTimeInfo(bool isDay, int currentHour, int currentMinute)
    {
        string amOrPm = "???";
        if(isDay)
        {
            amOrPm = "AM";
        }
        else
        {
            amOrPm = "PM";
        }
        string currentMinWithLeadingZero = "???";
        if(currentMinute < 10)
        {
            currentMinWithLeadingZero = $"0{currentMinute}";
        }
        else
        {
            currentMinWithLeadingZero = $"{currentMinute}";
        }
        return $"{currentHour}:{currentMinWithLeadingZero} {amOrPm}";
    }

    void EvaluateTime(bool isDay, int currentHour, int currentMinute)
    {
        //time format: "1:00 PM"
        string currentTime = ParseTimeInfo(isDay, currentHour, currentMinute);
        //Debug.Log($"current time is {currentTime}");
        if(timeTable.ContainsKey(currentTime))
        {
            ScheduleLogic(timeTable[currentTime]);
        }
    }

    void ScheduleLogic(string currentScheduledEvent)
    {
        GameObject targetRoom = null;
        bool roomTargeted = false;
        if(currentScheduledEvent == "Morning Routine")
        {
            targetRoom = roomZones.Find(obj => obj.name == "Bedroom1");
            roomTargeted = true;
        }
        else if(currentScheduledEvent == "Food")
        {
            targetRoom = roomZones.Find(obj => obj.name == "Kitchen1");
            roomTargeted = true;
        }
        if(roomTargeted == true)
        {
            MoveToCoords(targetRoom.GetComponent<RoomZoneLogic>().GetRandomPoint());
        }
    }

    void MoveToCoords(Vector3 targetDestination)
    {
        agent.destination = targetDestination;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = testDestination.position;
        agent.Move(testOffset);
    }

    private void OnEnable()
    {
        TimeClock.timePass += EvaluateTime;
    }
    private void OnDisable()
    {
        
    }
}
