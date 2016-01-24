using UnityEngine;
using System.Collections;

public class MirrorCamera : MonoBehaviour {
	GameObject go_Main_Camera;
	GameObject go_Mirror_Camera;
	GameObject go_TargetAvatar;
	GameObject go_Floor;

	Transform tr_Main_Camera;
	Transform tr_Mirror_Camera;
	Transform tr_TargetAvatar;
	Transform tr_Floor;

	void Start () {
		go_Main_Camera = GameObject.Find("Main Camera");
		go_Mirror_Camera = GameObject.Find("Mirror_Camera");
		go_TargetAvatar = GameObject.Find("SD_unitychan_humanoid");
		go_Floor = GameObject.Find("Plane_Floor");

		tr_Main_Camera = go_Main_Camera.transform;
		tr_Mirror_Camera = go_Mirror_Camera.transform;
		tr_TargetAvatar = go_TargetAvatar.transform;
		tr_Floor = go_Floor.transform;
	}

	void Update () {
		Vector3 pos = go_Main_Camera.transform.position;
		pos.y = -pos.y;
		tr_Mirror_Camera.position = pos;

		tr_Main_Camera.LookAt(go_TargetAvatar.transform);
		tr_Mirror_Camera.LookAt(go_TargetAvatar.transform);

		Quaternion tgt = tr_Main_Camera.rotation;
		Vector3 deg = tgt.eulerAngles;
		deg.x = 0f;
		deg.z = 0f;

		tr_Floor.rotation = Quaternion.Euler(deg);

	}
}
