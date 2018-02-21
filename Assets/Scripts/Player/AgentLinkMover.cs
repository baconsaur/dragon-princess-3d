﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentLinkMover : MonoBehaviour
{
	IEnumerator Start()
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.autoTraverseOffMeshLink = false;
		while (true)
		{
			if (agent.isOnOffMeshLink)
			{
				yield return StartCoroutine(Parabola(agent, 2.0f, 0.5f));
				agent.CompleteOffMeshLink();
			}
			yield return null;
		}
	}

	IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
	{
		OffMeshLinkData data = agent.currentOffMeshLinkData;
		Vector3 startPos = agent.transform.position;
		Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
		float normalizedTime = 0.0f;
		while (normalizedTime < 1.0f)
		{
			float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
			agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
			normalizedTime += Time.deltaTime / duration;
			yield return null;
		}
	}
}