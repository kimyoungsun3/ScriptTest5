using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeTest2 : MonoBehaviour {
	[SerializeField] UILabel[] labels;
	public bool lockTime;
	public DateTime timeAtLock;
	public TimeSpan intervalTime;

	//현재 서버 시간 2014-11-14 10:49:57.
	public string strServerTime;
	public DateTime dateServerTime;
	public string strServerTime2;
	public DateTime dateServerTime2;

	public DateTime clientTime
	{
		get
		{
			if (lockTime)
				return timeAtLock - intervalTime;
			else
				return DateTime.Now - intervalTime;
		}
	}

	public void SetServerTime(DateTime _serverDate)
	{
		intervalTime = DateTime.Now - _serverDate;
	}

	public void RealTimeLock(bool _lock)
	{
		if (_lock)
		{
			if (lockTime)
				return;

			lockTime = true;
			timeAtLock = DateTime.Now;
		}
		else
		{
			lockTime = false;
		}
	}

	private void Start()
	{
		strServerTime	= DateTime.Now.ToString();
		dateServerTime	= DateTime.Parse(strServerTime);

		strServerTime2 = "2019-11-11 12:34:56";
		dateServerTime2 = DateTime.Parse(strServerTime2);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SetServerTime(DateTime.Now);
			Display();
		}		
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			SetServerTime(DateTime.Parse(strServerTime));
			Display();
		}
	}

	void Display()
	{
		labels[0].text = "" + intervalTime.ToString()
			+ "\n" + intervalTime.Seconds
			+ "\n" + intervalTime.TotalSeconds
			+ "\n" + intervalTime.Ticks;

		Debug.Log("strServerTime:" + strServerTime);
		Debug.Log("dateServerTime:" + dateServerTime.ToString());

		Debug.Log("strServerTime2:" + strServerTime2);
		Debug.Log("dateServerTime2:" + dateServerTime2.ToString());


		Debug.Log("clientTime:" + clientTime.ToString());
		Debug.Log("ToLongDateString:" + clientTime.ToLongDateString());
		Debug.Log("ToLongTimeString:" + clientTime.ToLongTimeString());
		Debug.Log("ToShortDateString:" + clientTime.ToShortDateString());
		Debug.Log("ToShortTimeString:" + clientTime.ToShortTimeString());

	}
}
