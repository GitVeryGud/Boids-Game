using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Pursuit")]
public class PursuitBehaviour : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        //add all points together and average
        Vector2 pursuitMove = Vector2.zero;
        int nPursuit = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            nPursuit++;
            pursuitMove -= (Vector2)(agent.transform.position - item.position);
        }
        if (nPursuit > 0)
            pursuitMove /= nPursuit;

        return pursuitMove;
    }
}
