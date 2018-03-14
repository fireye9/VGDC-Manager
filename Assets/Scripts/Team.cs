using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public string currentProject;

    // Integer objects
    int pastProjects = 0;
    int maxTeamMembers = 6;

    // float objects. Used when a random event has occurred or a decision has been made that affects the team. That's why they're public.
    public float buffs;
    public float debuffs;
    public List<TeamMember> memberList = new List<TeamMember>(new TeamMember[] { });
    public RandomNumberIndex ran;


    public void assignNames()
    {
        foreach (TeamMember member in memberList)
        {
            member.name = ran.generateRandomName();
        }
    }

    // made a member a lead. I'm not sure how the player is supposed to make a member a lead yet...
    void makeLead(TeamMember member)
    {
        member.isLead = true;
    }


    void assignLead()
    {
        int ranIndex = Random.Range(0, memberList.Count);
        memberList[ranIndex].isLead = true;
    }

    void Update()
    {
        assignNames();
    }

}
