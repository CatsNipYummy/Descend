using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public const string WIN_STATE = "winState";

	static string m_sPlayerSetting;

	public static void setPlayerSetting (string playerSetting) {
		m_sPlayerSetting = playerSetting;
		PlayerPrefs.SetString(WIN_STATE, playerSetting);
	}

	public static string playerSetting() {
		return m_sPlayerSetting;
	}
}
