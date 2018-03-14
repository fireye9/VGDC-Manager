using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMember : MonoBehaviour
{
    // all these objects will be randomly assigned publicly with the random generator(s)
    // Yes, I know that name is not used yet...

    public string name;
    public string role;
    public Team team;
    public bool isLead = false;
}
