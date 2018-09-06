#define NETDEBGU_MODEx

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NetworkManagerK4{
public class NetworkManager : MonoBehaviour {

		/*
	public static NetworkManager ins;

	private string url, urlbase;
	private WWW www;

	[HideInInspector]
	public static string strCreateID,
				  		 strCreatePW,
				 		 strGuestPWOriginal = "-1",
				 		 strPhoneNumber 	= null,
				 		 strPhoneNumberC = null,
				 		 strPushID 		= null;
	private int pushKind = Protocol.PUSH_MODE_MSG;
	private string pushMsgTitle = "";
	private string pushMsgMsg = "";

	private string strDebug2 = "";
	private string strDebugMsg = "";

	public static int send_giftIdx;
	public static int send_giftKind;
	public static int send_idx;

	public static int send_bestAnimalCode;
	public static int send_adpopcorn_val;

	public static string send_couponValue;
	public static string send_nickName;
	public static string send_kakaouseridfd;

	public static int rev_giftItemCode;
	public static long rev_giftItemValue;
	
	public static string send_friendId;
	public static string send_userId;

	public static int send_saveMode;

	// 룰렛.
	public static int send_bbopgiMode;

	// 강화.
	public static int send_uptr_mode;		// 강화 모드.
	public static int send_uptr_itemCode;	// 강화 아이템 코드.
	public static int send_uptr_step;		// 강화수치.
	public static int send_uptr_result;		// 강화 성공 여부.성공(1), 실패(-1).
	public static long send_uptr_cashCost; 	// 강화 사용한 결정.
	public static long send_uptr_heart;		// 강화 사용한 하트.

	//룰렛.
	public static int send_rouletteMode;		// 룰렛 모드.
	public static long send_rouletteCostCash; 	// 룰렛 사용한 비용.

	//패키지.
	public static int send_packageIdx; // 패지키 상품 정보.

	//고객문의.
	public static string send_sysInquire; // 고객 문의 정보.


	void Awake()
	{	
		ins = this;
		urlbase = Protocol.SERVER;
		
		if ( Protocol.BUILD_MODE != Protocol.BUILD_MODE_REAL )
		{
			Debug.LogWarning(" 현재 디버그 모드입니다.");
		}
	}

	void readAndroidInfo(){
		if(strPhoneNumber == null || strPhoneNumber.Equals("")){
			strPhoneNumber 	= SSUtil.getCheckPhoneNum( CashBuy.ins.getPhoneNumber());
			strPhoneNumberC	= SSUtil.setEncode4(strPhoneNumber);
			strPushID 		= CashBuy.ins.getPushID();
		}		
	}

	
	//--------------------------------------------
	//[C -> S]
	// 1. Client -> Server 데이타 요청
	// 호출방법 : NetworkManager.Ins.sendCode
	// 멀티 호출이 가능함.
	//
	// _code		: 코드.
	// DELEGATE_INT	: 응답후 함수(delegate).
	// _bPopup		: 팝업을 띄울것인가?
	//--------------------------------------------
	public bool sendCode( int _code, VOID_FUN_INTINT _onResult )
	{
		WWWForm _form = new WWWForm();
		
		switch(_code)
		{

			//@@@@ start 0076
			case Protocol.PTC_SYSINQUIRE:
			{
				#if NETDEBGU_MODE
				Debug.Log("[C -> S] PTC_SYSINQUIRE");
				#endif
				//1. make URL
				url = urlbase + Protocol.PTG_SYSINQUIRE;

				//2. setting form
				_form.AddField("gameid", strCreateID );
				_form.AddField("password", strCreatePW );
				_form.AddField("message", send_sysInquire );					
				
				//3. sending
				#if NETDEBGU_MODE
				Debug.Log(" _form:" + SSUtil.getString(_form.data));
				#endif
				StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			}
			break;
			//@@@@ end

			//@@@@ start 0033
		case Protocol.PTC_WHEEL:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_WHEEL");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_WHEEL;
			
			//2. setting form
			_form.AddField("gameid", strCreateID );
			_form.AddField("password", strCreatePW);
			_form.AddField("mode", send_rouletteMode);// Protocol.MODE_WHEEL_NORMAL);
			//MODE_WHEEL_NORMAL				= 20,		//일일회전판(20)
			//MODE_WHEEL_PREMINUM			= 21,		//황금회전판(21)
			//MODE_WHEEL_PREMINUMFREE		= 22,		//황금무료(22)
			_form.AddField("cashcost", "" + send_rouletteCostCash);							//사용한 결정비용.
			_form.AddField("savedata", GameManager.ins.GetSaveData() );	//세이브 데이타.
			_form.AddField("sid", GameData.sid );
			_form.AddField("randserial", "" + GameData.serial_uptr);	// 랜덤 씨리얼 여기서 호출하지 마세요. 콜하는 쪽에서 호출하세요.
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;
			//@@@@ end
			//@@@@ start 0032
		case Protocol.PTC_TSUPGRADE:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_TSUPGRADE");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_TSUPGRADE;
			
			//2. setting form
			_form.AddField("gameid", strCreateID );
			_form.AddField("password", strCreatePW);
			_form.AddField("mode", send_uptr_mode);
			//MODE_TSUPGRADE_NORMAL				= 1,		//일반강화(1).
			//MODE_TSUPGRADE_PREMIUM			= 2,		//결정강화(2).
			_form.AddField("itemcode", "" + send_uptr_itemCode);						//강화할 아이템 코드.
			_form.AddField("step", "" + send_uptr_step);								//강화단계 1 -> 2 (1를 전송해줌).
			_form.AddField("results", "" + send_uptr_result);							//결과  성공(1), 실패(-1).
			_form.AddField("cashcost", "" + send_uptr_cashCost);							//사용한 결정비용.
			_form.AddField("heart", "" + send_uptr_heart);							//       하트비용.
			_form.AddField("savedata", GameManager.ins.GetSaveData() );	//세이브 데이타.
			_form.AddField("sid", GameData.sid );
			_form.AddField("randserial", "" + GameData.serial_uptr);	// 랜덤 씨리얼 여기서 호출하지 마세요. 콜하는 쪽에서 호출하세요.

			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;
			//@@@@ end
			//@@@@ start 0030
		case Protocol.PTC_TREASURE:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_TREASURE");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_TREASURE;
			
			//2. setting form
			_form.AddField("gameid", strCreateID );
			_form.AddField("password", strCreatePW);
			_form.AddField("mode", send_bbopgiMode); //Protocol.MODE_ROULETTE_GRADE1);
			//MODE_ROULETTE_GRADE1					= 1,	// 일반뽑기 (D, C).
			//MODE_ROULETTE_GRADE2					= 2,	// 결정뽑기 (B, A).
			//MODE_ROULETTE_GRADE3					= 3,	// 결정뽑기 (A, S).
			//MODE_ROULETTE_GRADE4					= 4,   	// 결정뽑기 (A, S (3 + 1)).
			//MODE_ROULETTE_GRADE2_FREE				= 12,	// 결정뽑기(무료).(B, A).
			//MODE_ROULETTE_GRADE3_FREE				= 13,	// 결정뽑기(무료).(A, S).
			//MODE_ROULETTE_GRADE4_FREE				= 14,	// 결정뽑기(무료).(A, S (3 + 1)).
			_form.AddField("savedata", GameManager.ins.GetSaveData() );	//세이브 데이타.
			_form.AddField("sid", GameData.sid );
			_form.AddField("randserial", "" + SSUtil.getRandSerial());			// 랜덤 씨리얼 여기서 호출하지 마세요. 콜하는 쪽에서 호출하세요.
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;
			//@@@@ end

		case Protocol.PTC_PACKBUY:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_PACKBUY");
			#endif

			//1. make URL
			url = urlbase + Protocol.PTG_PACKBUY;
			
			//2. setting form
			_form.AddField("gameid", strCreateID );
			_form.AddField("password", strCreatePW);
			_form.AddField("idx", "" + send_packageIdx);									//패키지에 있는 idx번호.
			_form.AddField("savedata", GameManager.ins.GetSaveData() );	//세이브 데이타.
			_form.AddField("sid", GameData.sid );
			_form.AddField("randserial", "" + GameData.serial_package);	// 랜덤 씨리얼 여기서 호출하지 마세요. 콜하는 쪽에서 호출하세요.
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;
			//@@@@ end

			//@@@@ start 0040
		case Protocol.PTC_REBIRTH:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_REBIRTH");
			#endif
			
			//1. make URL
			url = urlbase + Protocol.PTG_REBIRTH;
			
			//2. setting form
			_form.AddField("gameid", strCreateID );
			_form.AddField("password", strCreatePW);
			_form.AddField("rebirthpoint", "" + GameData.reborn_PlusPoint );	//환생포인트(클라이언트가 결정해서 서버에서는 기록만 해둠.
			_form.AddField("savedata", GameManager.ins.GetSaveData() );		//환생이 적용된 세이브 데이타.
			_form.AddField("sid", GameData.sid );
			_form.AddField("randserial", "" + GameData.serial_rebirth );	// 랜덤 씨리얼 여기서 호출하지 마세요. 콜하는 쪽에서 호출하세요.
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;
			//@@@@ end

			//@@@@ start 0028
		case Protocol.PTC_FKINFO:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_FKINFO");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_FKINFO;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);		//strCreateID
			_form.AddField("password", strCreatePW);	//strCreatePW
			StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
		}
			break;
			//@@@@ end
			//@@@@ start 0024	
		case Protocol.PTC_FREECASHCOST:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_FREECASHCOST");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_FREECASHCOST;
			
			//2. setting form
			_form.AddField("gameid", strCreateID );
			_form.AddField("password", strCreatePW);
			_form.AddField("bestani", send_bestAnimalCode);			//최고동물.
			_form.AddField("cashcost", send_adpopcorn_val);			//무료충전으로 충전된금액(단순로고용).
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;
			//@@@@ end
			//@@@@ start 0019
		case Protocol.PTC_NICKNAME:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_NICKNAME");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_NICKNAME;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);
			_form.AddField("password", strCreatePW);
			_form.AddField("nickname", send_nickName);		//영어(20), 한글(10)자까지만 지원함.
			_form.AddField("kakaouseridfd", send_kakaouseridfd);
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
		}
			break;
			//@@@@ end

			//@@@@ start 0018
		case Protocol.PTC_NOTICE:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_NOTICE");
			#endif
			
			//1. make URL
			url = urlbase + Protocol.PTG_NOTICE;
			
			//2. setting form
			_form.AddField("market", "" + Protocol.MARKET);
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
		}
			break;
			//@@@@ end
			//@@@@ start 0016
		case Protocol.PTC_SERVERTIME:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_SERVERTIME");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_SERVERTIME;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);
			_form.AddField("password", strCreatePW);
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
		}
			break;
			//@@@@ end
			//@@@@ start 0013
		case Protocol.PTC_CHANGEINFO:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_CHANGEINFO");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_CHANGEINFO;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);					//strCreateID
			_form.AddField("password", strCreatePW);				//strCreatePW
			_form.AddField("mode", "" + Protocol.USERMASTER_CHANGEINOF_MODE_KKOMSGBLOCKED );
			//카카오톡 메세지블럭	Protocol.USERMASTER_CHANGEINOF_MODE_KKOMSGBLOCKED
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
		}
			break;
			//@@@@ end
			//@@@@ start 0010
		case Protocol.PTC_FHEART:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_FHEART");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_FHEART;
			
			//2. setting form
			_form.AddField("gameid", strCreateID );						//나의 게임아이디.
			_form.AddField("password", strCreatePW);
			_form.AddField("friendid", send_friendId);					//친구의 게임아이디.

			_form.AddField("savedata", GameManager.ins.GetSaveData() );	//세이브 데이타.
			_form.AddField("sid", GameData.sid );
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;
			//@@@@ end

		case Protocol.PTC_FRETURN:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_FRETURN");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_FRETURN;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);
			_form.AddField("password", strCreatePW);
			_form.AddField("friendid", send_friendId );					//삭제할 친구아이디.
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
		}
			break;


		case Protocol.PTC_NEWSTART:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_NEWSTART");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_NEWSTART;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);
			_form.AddField("password", strCreatePW);
			
			//kakaouserid 얻어오는 방법.

			//_form.AddField("kakaouserid",  	_my.userId);						//userID			"91188455545412240"
			if (GuestPlayData.guestPlay)
			{
				_form.AddField("kakaouserid", "");
			}
			else 
			{
				tagKakaoLocalUser _my = KakaoManager.ins.stKakaoLocalUser;
				_form.AddField("kakaouserid", _my.userId);
			}

			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
		}
			break;
			//@@@@ start 0009
		case Protocol.PTC_KFINVITE:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_KFINVITE");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_KFINVITE;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);
			_form.AddField("password", strCreatePW);
			_form.AddField("kakaouserid", send_userId );		//초대할 친구 userid.
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
		}
			break;
			//@@@@ end
			//@@@@ start 0003
		case Protocol.PTC_KFADD:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_KFADD");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_KFADD;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);
			_form.AddField("password", strCreatePW);

			_form.AddField("kakaofriendlist", LoginManager.GetKakaoFiendListToUpdateServer());// "0:kakaouseridxxxx;1:kakaouseridxxxx3;2:8898989898798;");
			
			//카톡친구 ~~~ 게임친구 비교(talkId)
			//카톡친구 	: a, b, c, d
			//게임친구 	: a, b
			//string[] gameFriend = {"a", "b",};				//	> true,		"0:AO5x6elx7gA;"
			//string[] gameFriend = {"a", "b", "AO5x6elx7gA"};	//	> false, 	""
			//bool _bFind = false;
			//string _str = KakaoManager.ins.stListKakaoFriends.checkKakaoFriend(gameFriend, ref _bFind);
			//Debug.Log(_bFind +":" + _str);
			//if(_bFind){
			//	//이와 같이 빠진 친구들이 추가되어서 나옴.
			//	_str = "0:c;1:d;";
			//	NetworkManager.Ins.sendCode(PTC_KFADD);
			//}			
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
		}
			break;
			//@@@@ end
			//@@@@ start 0001	
		case Protocol.PTC_CREATEGUEST:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_CREATEGUEST");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_CREATEGUEST;


			//Debug.Log(strCreateID);
			//2. setting form
			//strCreateID : farm라고 보내주면 서버에서 만들어준다.
			//strCreatePW : 패스워드는 클라이언트에서 생성.
			string _baseId = null;

			if (GuestPlayData.createGuest)
			{
				strCreateID = "iuest";

				strCreatePW = SSUtil.setPassword( strGuestPWOriginal );
				
				_form.AddField("gameid", strCreateID);
				_form.AddField("password", strCreatePW);
				_form.AddField("market", "" + Protocol.MARKET);
				_form.AddField("buytype", "" + Protocol.BUYTYPE);
				_form.AddField("platform", "" + Protocol.PLATFORM);
				_form.AddField("ukey", "xxxxx");
				_form.AddField("version", "" + Protocol.VERSION);
				
				readAndroidInfo();
				_form.AddField("phone", strPhoneNumberC);
				_form.AddField("pushid", strPushID);
				_form.AddField("kakaotalkid", 	"");//_my.talkId);			//토크ID				"BElyGxtySQQ"
				_form.AddField("kakaouserid",  "");//	_my.userId);			//userID			"91188455545412240"
				
				_form.AddField("kakaonickname", SSUtil.EncryptString(""));//_my.nickName);			//닉네임. 			"mynickname"
				_form.AddField("kakaoprofile",  SSUtil.EncryptString(""));//	_my.profile);			//사진 URL			"http://th-p.talk.kakao.co.kr/th/talkp/wke3o4tbAc/z5Zr5k02IhSrmU4NvTyxf1/kx19xk_110x110_c.jpg"
				
				_form.AddField("kakaomsgblocked", "");//_my.messageBlocked);	//메세지 블럭여부		KakaoProtocol.KAKAO_MESSAGE_BLOCKED_TRUE
				//					KakaoProtocol.KAKAO_MESSAGE_BLOCKED_FALSE
				_form.AddField("kakaofriendlist", "");// KakaoManager.ins.stListKakaoFriends.getFriendsTalkId());	
				//appFriend talkId	"0:kakaotalkidxxxx;1:kakaotalkidxxxx3;"
				//					번호:talkId
			}
			else 
			{
//				if (Protocol.MARKET == Protocol.IPHONE) {
//					_baseId = "iuest";
//				} else {
//					_baseId = "farm";
//				}

				if (GuestPlayData.HasGuestIdPw() && GuestPlayData.guest2Kakao)
					strCreateID = GuestPlayData.id;
				else 
					strCreateID = "farm";

				strGuestPWOriginal = SSUtil.getGuestPassword();
				strCreatePW = SSUtil.setPassword( strGuestPWOriginal );
				
				_form.AddField("gameid", strCreateID);
				_form.AddField("password", strCreatePW);
				_form.AddField("market", "" + Protocol.MARKET);
				_form.AddField("buytype", "" + Protocol.BUYTYPE);
				_form.AddField("platform", "" + Protocol.PLATFORM);
				_form.AddField("ukey", "xxxxx");
				_form.AddField("version", "" + Protocol.VERSION);
				
				readAndroidInfo();
				_form.AddField("phone", strPhoneNumberC);
				_form.AddField("pushid", strPushID);
				
				//아하 카톡 부분의 정보는 전송안함.
				tagKakaoLocalUser _my = KakaoManager.ins.stKakaoLocalUser;
				tagKakaoFriend _stFriend;
				_form.AddField("kakaotalkid", 	_my.talkId);						//토크ID				"BElyGxtySQQ"
				_form.AddField("kakaouserid",  	_my.userId);						//userID			"91188455545412240"
				_form.AddField("kakaomsgblocked", _my.messageBlocked);				//메세지 블럭여부		KakaoProtocol.KAKAO_MESSAGE_BLOCKED_TRUE
				//					KakaoProtocol.KAKAO_MESSAGE_BLOCKED_FALSE
				_form.AddField("kakaofriendlist", KakaoManager.ins.stListKakaoFriends.getFriendsUserId());
				//appFriend userId	"0:kakaouseridxxxx;1:kakaouseridxxxx3;"
				//					번호:talkId
				//없으면				""
			}

			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
		}
			break;
			//@@@@ end
		case Protocol.PTC_RGAME:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_RGAME");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_RGAME;

			//2. setting form
			_form.AddField("gameid", strCreateID );	//메일주소.
			_form.AddField("password", strCreatePW);
			_form.AddField("idx", send_idx );						//추천 인덱스 > 아이템코드, 개수.
			_form.AddField("randserial", GameData.serial_appPlay );				// 랜덤 씨리얼 여기서 호출하지 마세요. 콜하는 쪽에서 호출하세요.
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif

			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;

		case Protocol.PTC_FVSAVE:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_FVSAVE");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_FVSAVE;

			//2. setting form
			_form.AddField("gameid", strCreateID );	
			_form.AddField("password", strCreatePW);

			_form.AddField("mode", send_saveMode);

			_form.AddField("userinfo", MakeSaveData_FVSAVE_userInfo());
			//_form.AddField("userinfo", "0:123456789012;   1:500;");
			//게임중 판매금액(전송후 클리어함)	Protocol.SAVE_USERINFO_SALEMONEY(0)
			//동물중에 최고동물아이템코드 		Protocol.SAVE_USERINFO_BESTANI(1)
			_form.AddField("randserial", "" + SSUtil.getRandSerial());			// 랜덤 씨리얼 여기서 호출하지 마세요. 콜하는 쪽에서 호출하세요.
			// SSUtil.getRandSerial()
			
			
			// 사용 금지.
			// < , > , 
			_form.AddField("savedata", GameManager.ins.GetSaveData() );	//세이브 데이타.
			_form.AddField("sid", GameData.sid );
//			Debug.Log(SaveServer.GetSaveData());
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;

		case Protocol.PTC_CERTNO:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_CERTNO");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_CERTNO;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);
			_form.AddField("password", strCreatePW);			
			_form.AddField("certno", send_couponValue );			//쿠폰번호.
			_form.AddField("randserial", GameData.serial_coupon );					// 랜덤 씨리얼 여기서 호출하지 마세요. 콜하는 쪽에서 호출하세요.
			// SSUtil.getRandSerial()
			//3384F1C244B74633	A2E48F58A0BD49E0	54D4897FDAE74E4D	8AB88B599BDB4923	E344259F1D0B4FE7
			//EDD5684215554EA6	7395573615274188	39726A53C6D24224	8623420F22014F87	57E5CA5F7E504412
			//CF3EE2DA00FF4E16	168B6A75D3804F47	E2731C6EA8B24DF4	CB459BDD12EA4B71	1F087E6589454902
			//D91A6D951F214DB6	00CB45F02DBB4E83	158324B8DACF41A7	952B787000EA4583	3D40DC75FD67489B
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			break;

		case Protocol.PTC_GIFTGAIN:
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_GIFTGAIN");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_GIFTGAIN;
			
			//2. setting form
			_form.AddField("gameid", strCreateID);
			_form.AddField("password", strCreatePW);			
			_form.AddField("giftkind", "" + send_giftKind );
			//메세지 삭제(-1).				Protocol.GIFTLIST_GIFT_KIND_MESSAGE_DEL
			//선물 삭제(안받고 삭제)(-2)		Protocol.GIFTLIST_GIFT_KIND_GIFT_DEL
			//선물 받기(해당템만 전송)(-3)		Protocol.GIFTLIST_GIFT_KIND_GIFT_GET
			//선물 바로판매.					Protocol.GIFTLIST_GIFT_KIND_GIFT_SELL
			//리스트만 옴.					Protocol.GIFTLIST_GIFT_KIND_LIST
			_form.AddField("idx", "" + send_giftIdx);				//선물번호 인덱스.			
			
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			break;

		case Protocol.PTC_LOGIN:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_LOGIN");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_LOGIN;
			
			//2. setting form
			//Social.localUser.
			//Debug.Log ( strCreateID );

			_form.AddField("gameid", strCreateID);		//strCreateID
			_form.AddField("password", strCreatePW);	//strCreatePW
			#if NETDEBGU_MODE
			Debug.Log("id:" + strCreateID + " pw:" + strCreatePW);
			#endif

//			_form.AddField("gameid", "farm75591");		//strCreateID
//			_form.AddField("password", "4029599r4x0h9s174282");	//strCreatePW

			_form.AddField("market", "" + Protocol.MARKET);
			_form.AddField("version", "" + Protocol.VERSION);

			tagKakaoLocalUser _my = KakaoManager.ins.stKakaoLocalUser;
			_form.AddField("kakaomsgblocked", _my.messageBlocked);
			//카톡(수락)	게임(수락)		=> ok (수락유지).
			//			게임(거부)		=> ok (거부유지).
			//카톡(거부)	게임(거부)		=> ok.
			//			게임(수락=> 거부)	=> (로그인시 보내준 거부로 변경).
			//			변경팝			=> 짜요 목장 이야기에서는 메시지를 받으시려면 카카오톡>더보기>카카오계정>연결된 앱관리에서 짜요 목장 이야기를 선택하여 '카카오톡으로 메시지를 수신'을 체크해주세요.
			
			
			//readAndroidInfo();									//삭제.
			//_form.AddField("phone", strPhoneNumberC);				//삭제.
			//_form.AddField("concode", "" + Protocol.GetContry () );//삭제.
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			
			StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
		}
			break;

		case Protocol.PTC_CASHBUY:
			
			#if NETDEBGU_MODE
			Debug.Log("[C -> S] PTC_CASHBUY");
			#endif
			//1. make URL
			url = urlbase + Protocol.PTG_CASHBUY;
			
			//2. setting form
			//암호화를 2중.3중으로 한다.
			string _gameid 		= strCreateID;
			int _itemcode		= GameData.lastBuyCashCode;			

			//7000	5000
			//7001	10000
			//7002	30000
			//7003	55000
			//7004	99000
			//7005	5000
			//7006	10000
			//7007	30000
			//7008	55000
			//7009	99000

			//구매한 정보를 호출하기.
			CashBuy.ins.getItemBuyMessage ();

			if(Protocol.MARKET == Protocol.IPHONE){
				_form.AddField("ikind", CashBuy.strIPhoneItemBuyEnvironment);
				_form.AddField("acode", CashBuy.strIPhoneItemBuyReceipt);
			}else if(Protocol.MARKET == Protocol.GOOGLE){
				_form.AddField("ikind", "googlekw");
				_form.AddField("acode", CashBuy.strBuyOrderId);
			}else if(Protocol.MARKET == Protocol.SKT){
				_form.AddField("ikind", "skt");
				_form.AddField("acode", CashBuy.strBuyOrderId);
			}else if ( Protocol.MARKET == Protocol.NHN ){
				_form.AddField("ikind", "nhn");
				_form.AddField("acode", CashBuy.strBuyOrderId);
			}else if ( Protocol.MARKET == Protocol.LGT ){
				_form.AddField("ikind", "lgt");
				_form.AddField("acode", CashBuy.strBuyOrderId);
			}else if ( Protocol.MARKET == Protocol.KT ) {
				_form.AddField("ikind", "kt");
				_form.AddField("acode", CashBuy.strBuyOrderId);
			}


			_form.AddField("gameid", _gameid);
			_form.AddField("password", strCreatePW);	
			_form.AddField("itemcode", "" + _itemcode);

			//@@@@ start 0023
			Debug.Log(NetworkManager.send_friendId);
			_form.AddField("giftid", NetworkManager.send_friendId);
			//@@@@ end

			//Debug.Log(" _form:" + SSUtil.getString(_form.data));
			//3. sending
			#if NETDEBGU_MODE
			Debug.Log(" _form:" + SSUtil.getString(_form.data));
			#endif
			StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			break;

		default:
			Debug.LogError("[error][C -> S] #### error");	
			if ( _onResult != null )
			{
				_onResult ( Protocol.CONNECT_STATE_FAIL , Protocol.CONNECT_STATE_FAIL );
			}
			break;
		}
		
		return true;
	}
	

	//--------------------------------------------
	//[C <- S]
	// 2. 보내온 데이타는 data, fun으로 구성됨.
	//
	// queue[_idx].data 	: 서버메세지.
	// queue[_idx].fun 		: callback Funtion.
	// queue[_idx].popup 	: is Popup
	//--------------------------------------------
	public int parseCode( string _xml ){
		
		//1. 변수 선언 및 할당.
		SSParser parser = new SSParser ();

		//Debug.Log ( _xml );

		parser.parsing(_xml, "result");
		parser.next();
		
		int _code 		= parser.getInt("code");	
		int _resultcode = parser.getInt("resultcode");
		string _msg 	= parser.getString("resultmsg");


		//3. 내부 코드.
		switch(_code)
		{
			//@@@@ start 0076			
			case Protocol.PTS_SYSINQUIRE:
			{
				#if NETDEBGU_MODE
				Debug.Log("[C <- S] PTS_SYSINQUIRE _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
				#endif
				
				switch(_resultcode){
				case Protocol.RESULT_SUCCESS:
					#if NETDEBGU_MODE
					Debug.Log(" > 게임 문의를 등록했습니다.");
					#endif
					break;
				default:
					#if NETDEBGU_MODE
					Debug.Log(" > 팝업처리.");
					#endif
					break;
				}
			}
			break;
			//@@@@ end

			//@@@@ start 0033
		case Protocol.PTS_WHEEL:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_WHEEL _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_WHEEL > success");
				#endif

			    GameData.ChangeSerial_Roulette();
				
				////////////////////////////////////////////////////////////
				// 회전판.
				//
				// * 관리사이트 > 뽑기/강화/회전판	> 회전판무료돌리기.
				// * 관리사이트 > 유저정보 > (탭)회전판.
				//
				///////////////////////////////////////////////////////////
				//1. 1일 1회.
				UserData.ins.rouletteData.rouletteState = parser.getInt ("roulette");
				//parser.getInt("roulette");					//1:돌릴수있음, -1:이미돌림	<= 기존에 구현된것임.
				
				//2.결정회전판 이벤트.
				ServerData.Roulette.Pasrse_Event(parser.getInt("wheelgauageflag"), parser.getInt("wheelgauage"), parser.getInt("wheelfree"));
				//parser.getInt("wheelgauageflag");			//활성(1), 비활성(-1)
				//parser.getInt("wheelgauage");				//게이지정보.
				//parser.getInt("wheelfree");					//1이면 돌릴수 있도록 표시.
				
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_WHEEL > error > 아이디를 확인해라.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:
				#if NETDEBGU_MODE
				Debug.Log("PTS_WHEEL > error > 지원하지 않는 모드입니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_DAILY_REWARD_ALREADY:
				#if NETDEBGU_MODE
				Debug.Log("PTS_WHEEL > error > 이미 회전판을 돌렸다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_WHEEL > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ end
			//@@@@ start 0032
		case Protocol.PTS_TSUPGRADE:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_TSUPGRADE _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_TSUPGRADE > success");
				#endif

				GameData.ChangeSeiral_UpgradeTreasure();
				////////////////////////////////////////////////////////////
				// 보물강화할인.
				// 캐쉬와 하트 둘다 할인한다.
				//
				// * 관리사이트 > 뽑기부가상품 > (탭)보물강화할인.
				///////////////////////////////////////////////////////////
				ServerData.TreasureUpgrade.ParseEvent_Sale(parser.getInt("tsupgradesaleflag"),parser.getInt("tsupgradesalevalue"));
				
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_TSUPGRADE > error > 아이디를 확인해라.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:
				#if NETDEBGU_MODE
				Debug.Log("PTS_TSUPGRADE > error > 지원하지 않는 모드입니다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_TSUPGRADE > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ end
			//@@@@ start 0030
		case Protocol.PTS_TREASURE:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_TREASURE _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:

				GameData.ChangeSeiral_Bbopgi();
				#if NETDEBGU_MODE
				Debug.Log("PTS_TREASURE > success");
				#endif
				
				////////////////////////////////////////////////////////////
				//방금 뽑은정보 (선물함으로 전달됨).
				//뽑기로 나옴 보물 80010  ~ 80314.
				//                 -1 : 없음.
				////////////////////////////////////////////////////////////
				ServerData.TreasureBbopgi.ParseGainItems(parser.getInt("roul1"),
				                                         parser.getInt("roul2"),
				                                         parser.getInt("roul3"),
				                                         parser.getInt("roul4"),
				                                         parser.getInt("roul5")
				                                         );
				
				////////////////////////////////////////////////////////////
				//보물할인.
				// 캐쉬와 하트 둘다 할인한다.
				//
				// * 관리사이트 > 뽑기부가상품 > (탭)보물할인.
				///////////////////////////////////////////////////////////
				ServerData.TreasureBbopgi.ParseEvent_Sale(parser.getInt("roulsaleflag"), parser.getInt("roulsalevalue"));
				
				////////////////////////////////////////////////////////////
				//특정 상품이 나오면 선물로 템을 보상해주기.
				//checkani (이것을 뽑아서 ) > checkreward (이것을 지급했다.).
				//                           -1이면 없다는 뜻임.
				//
				// * 관리사이트 > 뽑기부가상품 > (탭)보물보상.
				///////////////////////////////////////////////////////////
				///  이벤트 3개다 뽑으면 제일 높은것 기준으로 온다.
				ServerData.TreasureBbopgi.ParseEvent_TargetBbopgi(parser.getInt("roulrewardflag"));

				// 보상 결과.
				ServerData.TreasureBbopgi.ParseReward_EventTarget(parser.getInt("checktreasure"), parser.getInt("checkreward"), parser.getInt("checkrewardcnt"));
				
				
				////////////////////////////////////////////////////////////
				// 시간이벤트 : 12, 18, 23
				//
				// * 관리사이트 > 뽑기부가상품 > (탭)보물할인.
				///////////////////////////////////////////////////////////
				ServerData.TreasureBbopgi.ParseEvent_DropRate( parser.getInt("roultimeflag"), parser.getInt("roultimetime1"), parser.getInt("roultimetime2"), parser.getInt("roultimetime3") );
				
				////////////////////////////////////////////////////////////
				// 보물무료뽑기 : 10회당 1회 무료뽑기.
				//
				// * 관리사이트 > 뽑기부가상품 > (탭)보물할인.
				//   point 10 / max 100 > 1회 뽑을때마다 10포인트씩 누적.
				//   100이되면 하나가 채워져서 서버에서 온다.
				///////////////////////////////////////////////////////////
				ServerData.TreasureBbopgi.ParseEvent_FreeCharge( parser.getInt("tsgauageflag"),
				                                                parser.getInt("tsgrade2gauage"),
				                                                parser.getInt("tsgrade3gauage"),
				                                                parser.getInt("tsgrade4gauage"),
				                                                parser.getInt("tsgrade2free"),
				                                                parser.getInt("tsgrade3free"),
				                                                parser.getInt("tsgrade4free") );			

				//선물정보.
				GameData.ReadGiftItem ( parser , _xml , "giftitem" );
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_TREASURE > error > 아이디를 확인해라.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_ITEMCODE:
				#if NETDEBGU_MODE
				Debug.Log("PTS_TREASURE > error > 아이템 코드를 찾을수 없습니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:
				#if NETDEBGU_MODE
				Debug.Log("PTS_TREASURE > error > 지원하지 않는 모드입니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_ITEM_LACK:
				#if NETDEBGU_MODE
				Debug.Log("PTS_TREASURE > error > 무료 게이지가 부족합니다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_TREASURE > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ endPTS_PACKBUY

			//@@@@ start 0035
		case Protocol.PTS_PACKBUY:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_PACKBUY _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif

			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				GameData.ChangeSerial_Package();
				#if NETDEBGU_MODE
				Debug.Log("PTS_PACKBUY > success");
				#endif
				
				//선물정보.
				GameData.ReadGiftItem ( parser , _xml , "giftitem" );
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_PACKBUY > error > 아이디를 확인해라.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_ITEMCODE:
				#if NETDEBGU_MODE
				Debug.Log("PTS_PACKBUY > error > 아이템 코드를 찾을수 없습니다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_PACKBUY > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ end

			//@@@@ start 0040
		case Protocol.PTS_REBIRTH:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_REBIRTH _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_REBIRTH > success");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_REBIRTH > error > 아이디를 확인해라.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_REBIRTH > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ end

			//@@@@ start 0028
		case Protocol.PTS_FKINFO:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_FKINFO _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode)
			{
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FKINFO > success");
				#endif
				
				//유져인포.
				parser.parsing ( _xml , "userinfo" );
				if (parser.next ())
				{
					UserData.battleRnk_my.Parser(parser.getInt("rkteam"),					//1 : 홀수팀.		//0 : 짝수팀.		//내가소속한팀 > 관리사이트 유저정보 > 6번째 탭에 있음.
					                             parser.getInt64("rksalemoney"),			//		나의  판매수익.
					                             parser.getInt64("rkproductcnt"),			//     	생산수량.
					                             parser.getInt64("rkfarmearn"),				//		목장수익.
					                             parser.getInt64("rkwolfcnt"),				//		늑대사냥.
					                             parser.getInt64("rkfriendpoint"),			// 		친구포인트.
					                             parser.getInt64("rkroulettecnt"),			//		룰렛.
					                             parser.getInt64("rkplaycnt")				//		플레이타임.
					                             );
				}
				
//				// 로칼 정보와 합치기전 친구 정보.
//				if (GuestPlayData.guestPlay == false)
//				{
//					ServerData.ServerFriend.ReadServerFriend(parser, _xml, "frank");
//					GameData.MergeAndSort_FriendRank();
//				}
//				
				
//				//전체랭킹 [랭킹, 게임아이디, 동물, 판매금액].
//				//                닉네임, 사진(안나옴)
//				if (GuestPlayData.guestPlay == false)
//				{
//					ServerData.TotalRank.ReadServerData(parser, _xml, "trank");
//					GameData.MakeTotalRank();
//				}
				
				//현재대전내용(1건).
				UserData.battleRnk_current.Parser(parser, _xml, "rkcurrank");
				
				//지난 대전내용(1건). > 지난내용 보기 위해서.
				UserData.battleRnk_last.Parser(parser, _xml, "rklaterank");
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FKINFO > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ end
			//@@@@ start 0024
		case Protocol.PTS_FREECASHCOST:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_FREECASHCOST _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FREECASHCOST > success");
				#endif
				//정상저장처리.
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FREECASHCOST > error > 아이디를 확인해라.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FREECASHCOST > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ end
			//@@@@ start 0019
		case Protocol.PTS_NICKNAME:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_NICKNAME _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log(" > 닉네임 변경 > 성공.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log(" > 닉네임 변경. > 팝업처리.");
				#endif
				break;
			}
		}
			break;
			//@@@@ end
			//@@@@ start 0018
		case Protocol.PTS_NOTICE:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_NOTICE _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_NOTICE > success:" + parser.getString("serial"));
				#endif

				ServerData.Notice.Parse(parser, _xml, "notice");

				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_NOTICE > error > not found error");
				#endif

				break;
			}
		}
			break;
			//@@@@ end
			//@@@@ start 0016
		case Protocol.PTS_SERVERTIME:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_SERVERTIME _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log(" > 서버시간 > 성공.");
				#endif
				
				//현재 서버 시간 2014-11-14 10:49:57.
				Callendar.SetServerTime( DateTime.Parse( parser.getString("curdate") ) );
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log(" > 서버시간 실패. > 팝업처리.");
				#endif
				break;
			}
		}
			break;
			//@@@@ end
			//@@@@ start 0013
		case Protocol.PTS_CHANGEINFO:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_CHANGEINFO _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CHANGEINFO > success");
				#endif
				
				//유저 정보.
				parser.parsing(_xml, "userinfo");
				if(parser.next()){
					GameData.msgBlocked = parser.getInt("kakaomsgblocked");	//카톡 자신의 정보 수신거부/수락.
					//수신수락		Protocol.KAKAO_MESSAGE_BLOCKED_FALSE
					//수신거부		Protocol.KAKAO_MESSAGE_BLOCKED_TRUE
				}
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CHANGEINFO > 아이디를 확인해라.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CHANGEINFO > 지원하지 않는 모드입니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_ALREADY_REWARD:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CHANGEINFO > 이미 지급했다..");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CHANGEINFO > not found error");
				#endif
				break;
			}
		}
			break;
			//@@@@ end
			//@@@@ start 0010
		case Protocol.PTS_FHEART:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_FHEART _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FHEART > success");
				#endif
				//Debug.Log ("정상 저장 > 판매금액 클리어.");
				parser.parsing ( _xml , "userinfo" );
				
				if (parser.next ())
				{
					GameData.gainedNewHeartPoint += parser.getInt ("heartget");
					GameData.heartGetPoint_Sever.AddValue(parser.getInt ("heartget"));			
				}
				//userinfo > heartget : 친구들에게 받은 하트량(heartget) > 클라이언트 데이타에 Plus.
				//						(서버에서는 받은 하트는 초기화 됨).
				//@@@@ end
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FHEART > error > 아이디를 확인해라.");
				#endif
				break;				
				//@@@@ start 0014
			case Protocol.RESULT_ERROR_KAKAO_MESSAGE_BLOCK:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FHEART > error > 메세지 수신거부상태입니다.");
				#endif
				break;	
				//@@@@ end	
			case Protocol.RESULT_ERROR_NOT_FOUND_OTHERID:
				#if NETDEBGU_MODE
				Debug.Log(" > 친구의 계정이 없습니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_TIME_REMAIN:
				#if NETDEBGU_MODE
				Debug.Log(" > 시간이 남아있습니다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FHEART > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ end

			//@@@@ start 0034
		case Protocol.PTS_FRETURN:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_FHEART _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log(" > 친구하트주기 > 성공.");
				#endif
				
				//유저 정보.
				parser.parsing ( _xml , "userinfo" );
				if (parser.next ())
				{
					GameData.gainedNewHeartPoint += parser.getInt ("heartget");
					GameData.heartGetPoint_Sever.AddValue(parser.getInt ("heartget"));			
				}
				//userinfo > heartget : 친구들에게 받은 하트량(heartget) > 클라이언트 데이타에 Plus.
				//						(서버에서는 받은 하트는 초기화 됨).
				//@@@@ end
				
				if (GuestPlayData.guestPlay == false)
					ServerData.ServerFriend.ReadServerFriend(parser, _xml, "frank");
				
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log(" > 친구하트주기 > 아이디를 찾을 수 없습니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_OTHERID:
				#if NETDEBGU_MODE
				Debug.Log(" > 친구하트주기 > 친구의 정보를 찾을수 없습니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:
				#if NETDEBGU_MODE
				Debug.Log(" > 친구하트주기 > 신청 받은 사람만이 승인 처리 할 수 있습니다");
				#endif
				break;
			case Protocol.RESULT_ERROR_ALIVE_USER:
				#if NETDEBGU_MODE
				Debug.Log(" > 현재 활동하는 유저입니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_WAIT_RETURN:
				#if NETDEBGU_MODE
				Debug.Log(" > 현재 요청 대기중입니다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log(" > 팝업처리.");
				#endif
				break;
			}
		}
			break;
			//@@@@ end


		case Protocol.PTS_NEWSTART:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_NEWSTART _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log(" > 삭제성공 > 성공.");
				#endif
				//초기 인트로로 보내면 된다.
				
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log(" > 삭제 실패. > 내아이디를 찾을 수 없습니다. > 팝업처리.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log(" > 삭제 실패. > 팝업처리.");
				#endif
				break;
			}
		}
			break;

		case Protocol.PTS_KFINVITE:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_KFINVITE _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log(" > 친구추가 > 성공.");
				#endif

				GameData.ReadKakaoInviteState(parser);
//				parser.getInt("kakaomsginvitecnt");				//전체 초대인원수. > 상품 표시.
//				parser.getInt("kakaomsginvitetodaycnt");		//1일 초대 인원수.
//				parser.getString("kakaomsginvitetodaydate");	//1일 초대 인원수 초기화 날짜.(표시안해되됨)

				ServerData.InvitedKakaoFriend.ReadServerData(parser, _xml, "kakaoinvite");

				if ( GameInfo_InviteGift.HasKey( GameData.kakaoMsgInviteCnt ) )
				{
					//선물정보.
					GameData.ReadGiftItem ( parser , _xml , "giftitem" );
				}

				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log(" > 아이디가 존재하지 않는다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_TIME_REMAIN:
				#if NETDEBGU_MODE
				Debug.Log(" > 시간이 남아있습니다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log(" > 기타오류.");
				#endif
				break;
			}
		}
			break;
			//@@@@ start 0003
		case Protocol.PTS_KFADD:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_KFADD _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log(" > 친구추가 > 성공.");
				#endif
				

				// 로칼 정보와 합치기전 친구 정보.
				ServerData.ServerFriend.ReadServerFriend(parser, _xml, "frank");
				//친구정보(나 + 친구) + 랭킹.
//				parser.parsing(_xml, "frank");
//				while(parser.next()){
//					parser.getInt("rank");				//랭킹번호.
//					parser.getString("friendid");		//친구아이디(자기 아이디도 포함해서 옴).
//					parser.getInt("bestani");			//최고 동물.
//					parser.getInt64("totalsalemoney");	//실제 1주일간 상인에게 판매한 누적금액(스케쥴에 의해서 자동 초기화됨).
//					parser.getString("senddate");		//하트선물 보낸날짜.
//					
//					parser.getString("kakaotalkid");	//카톡 talkid(유일한 식별값 > 이걸로 친구를 찾음.)		"BElyGxtySQQ"
//					parser.getString("kakaouserid");	//카톡 userid(보이는 용도)							"91188455545412240" > 이것으로 생성.
//					parser.getString("kakaomsgblocked");//카톡 메세지 거절		KakaoProtocol.KAKAO_MESSAGE_BLOCKED_TRUE
//					//	   메세지 수락		KakaoProtocol.KAKAO_MESSAGE_BLOCKED_FALSE
//					parser.getString("kakaofriendkind");//카톡 친구들(talkid -> 친구를 찾음)
//					//게임친구 > 메세지(X)	KakaoProtocol.KAKAO_FRIEND_KIND_GAME
//					//카톡친구 > 메세지(O)	KakaoProtocol.KAKAO_FRIEND_KIND_KAKAO
//					//////////////////////////////////////////////////////////
//					// 게임친구에게는 카톡 메세지를 절대로 보내지 말아야한다.
//					//////////////////////////////////////////////////////////
//				}
				
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log(" > 친구추가 실패. > 내아이디를 찾을 수 없습니다. > 팝업처리.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log(" > 친구추가 실패. > 팝업처리.");
				#endif
				break;
			}
		}
			break;
			//@@@@ end
			//@@@@ start 0001
		case Protocol.PTS_CREATEGUEST:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_CREATEGUEST _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CREATEGUEST > success");
				#endif
				//1. 서버에서 생성된 게스트 아이디 받기.
				strCreateID = parser.getString("gameid");
				strCreatePW = parser.getString("password");			//패스워드를 보내준것으로 새팅해야한다.

				if (GuestPlayData.createGuest)
				{
					GuestPlayData.SaveIdPwToLocalDB( strCreateID, strCreatePW );
					ClearIdPw();
				}
				else 
				{
					SaveIdPwToLocalDB(strCreateID, strCreatePW);
					GuestPlayData.ClearIdPw();
				}

				break;
			case Protocol.RESULT_ERROR_ID_DUPLICATE:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CREATEGUEST > error > 아이디 중복");
				#endif
				break;
			case Protocol.RESULT_ERROR_ID_CREATE_MAX:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CREATEGUEST > error > phone당 생성 가능한 아이디개수초과.");
				#endif
				break;
			case Protocol.RESULT_ERROR_JOIN_WAIT:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CREATEGUEST > error > 일정시간동안 가입이 불가합니다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CREATEGUEST > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ end

		case Protocol.PTS_RGAME:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_CERTNO _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_RGAME > success");
				#endif
				
				//3. 선물 리스트.
				GameData.ReadGiftItem ( parser , _xml , "giftitem" );
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_RGAME > error > 아이디를 확인해라.");
				#endif
				break;
			case Protocol.RESULT_ERROR_ALREADY_REWARD:
				#if NETDEBGU_MODE
				Debug.Log("PTS_RGAME > error > 이미 보상을 받았습니다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_RGAME > error > not found error");
				#endif
				break;
			}
			break;

		case Protocol.PTS_FVSAVE:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_FVSAVE _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FVSAVE > success");
				#endif

				parser.parsing ( _xml , "userinfo" );
				
				if (parser.next ())
				{
					GameData.gainedNewHeartPoint += parser.getInt ("heartget");
					GameData.heartGetPoint_Sever.AddValue(parser.getInt ("heartget"));			
				}


				if (send_saveMode == 1 && GuestPlayData.guestPlay == false)
				{
					ServerData.TotalRank.ReadServerData(parser, _xml, "trank");

					ServerData.RebirthRank.ReadServerData(parser, _xml, "rebitrhrank");

					GameData.MakeTotalRank();
				}

				//@@@@ start 0027
				//현재대전내용(1건).
				UserData.battleRnk_current.Parser(parser, _xml, "rkcurrank");
				
				
				//지난 대전내용(1건). > 지난내용 보기 위해서.
				UserData.battleRnk_last.Parser(parser, _xml, "rklaterank");

				GameData.cashRoulette = 0;
				UserData.ins.rouletteData.ticketRouletteUseCount = 0;
				//@@@@ end

				//@@@@ start 0031
				ServerData.TreasureBbopgiAdd.Parse(parser, _xml, "adlist");
				//@@@@ end
				//정상저장처리.
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FVSAVE > error > 아이디를 확인해라.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_FVSAVE > error > not found error");
				#endif
				break;
			}
			break;

		case Protocol.PTS_CERTNO:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_CERTNO _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode)
			{
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CERTNO > success");
				#endif
				//////////////////////////////////////
				//	코인 or 유제품을 반영해주세요.
				//
				//////////////////////////////////////
				
				//3. 선물 리스트.
				GameData.ReadGiftItem ( parser , _xml , "giftitem" );
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CERTNO > error > 아이디를 확인해라.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_CERTNO:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CERTNO > error > 인증번호가 존재안합니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_ALREADY_REWARD_COUPON:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CERTNO > error > 쿠폰은 1인 1매.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CERTNO > error > not found error");
				#endif
				break;
			}
			break;

		case Protocol.PTS_GIFTGAIN:
		{
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_GIFTGAIN _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_GIFTGAIN > success");
				#endif
				rev_giftItemCode = parser.getInt("itemcode");
				rev_giftItemValue = parser.getInt64("cnt");

//				Debug.Log ( "rev_giftItemCode ("+rev_giftItemCode+") , rev_giftItemValue ("+rev_giftItemValue+")" );
				
				//3. 선물 리스트.
				GameData.ReadGiftItem ( parser , _xml, "giftitem" );
				
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_GIFTGAIN > error > 아이디를 확인해라.");
				#endif
				break;
			case Protocol.RESULT_ERROR_GIFTITEM_NOT_FOUND:
				#if NETDEBGU_MODE
				Debug.Log("PTS_GIFTGAIN > error > 선물아이템 존재자체를 안함.");
				#endif
				break;
			case Protocol.RESULT_ERROR_GIFTITEM_ALREADY_GAIN:
				#if NETDEBGU_MODE
				Debug.Log("PTS_GIFTGAIN > error > 지급 및 삭제되었습니다.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:
				#if NETDEBGU_MODE
				Debug.Log("PTS_GIFTGAIN > error > 지원하지 않는 모드값입니다.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_GIFTGAIN > error > not found error");
				#endif
				break;
			}
		}
			break;
		case Protocol.PTS_LOGIN:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_LOGIN _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif

			switch(_resultcode)
			{
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_LOGIN > success");
				#endif

				GameData.pathUrl = parser.getString("patchurl");	//패치URLDebug.Log ( parser.getString("patchurl") );.
				GameData.recurl  = parser.getString("recurl");		//패치URLDebug.Log ( parser.getString("patchurl") );.
				parser.getInt("curversion");						//버젼이 낮으면 패치URL로 보냄.

				//현재 서버 시간 2014-11-14 10:49:57.
				Callendar.SetServerTime( DateTime.Parse( parser.getString("curdate") ) );

				GameData.ntcomment = parser.getString("ntcomment");							//텍스쳐 공지사항.

				//유져인포.
				parser.parsing ( _xml , "userinfo" );

				if (parser.next ())
				{
					//@@@@ start 0041
					// 장기 미접속 단계.
					GameData.pausetick = parser.getInt ( "pausetick" );
					//@@@@ end
					GameData.sameweek = parser.getInt ( "sameweek" );
					//Debug.Log(GameData.sameweek);

					GameData.sid = parser.getInt ( "sid" );
					//Debug.Log(GameData.sid);

					//@@@@ start 0025
					//-1 :      돌렸음.
					//1  : 아직 안돌림.
					UserData.ins.rouletteData.rouletteState = parser.getInt ( "roulette" );
					//@@@@ end

					GameData.attendnewday_booster = parser.getInt ( "attendnewday" );
					GameData.attendnewday_stimPack = GameData.attendnewday_booster;
					SaveServer.InitServerData ( parser.getString ( "savedata" ) );

					//@@@@ start 0002
					KakaoManager.ins.kakaoInviteId 	= parser.getInt ( "kakaoinviteid" );	//초대번호.
					KakaoManager.ins.kakaoProudId 	= parser.getInt ( "kakaoproudid" );	//초대번호.
					KakaoManager.ins.kakaoHeartId 	= parser.getInt ( "kakaoheartid" );	//초대번호.
					KakaoManager.ins.kakaoReturnId 	= parser.getInt ( "kakaoreturnid" );	//초대번호.

					GameData.ReadKakaoInviteState(parser);										// 카카오 초대 현황.					
					GameData.bestAnimalCode = parser.getInt ( "bestani" );						//제일좋은 동물.
					GameData.totalSaleCoin.SetValue(parser.getInt64 ( "totalsalemoney" ));		//지금까지 판매한 수익.(1주일 단위기록, 서버에서 초기화함)

					GameData.gainedNewHeartPoint += parser.getInt ("heartget");
					GameData.heartGetPoint_Sever.AddValue(parser.getInt ( "heartget" ));	

					GameData.msgBlocked = parser.getInt("kakaomsgblocked");
					//@@@@ end


					//@@@@ start 0015
					ServerData.LastRanker.Parse_Visible( parser.getInt("rankresult") );			//(1)	랭킹을 보여주세요.
																								//(0)	랭킹을 보여줬습니다.

					ServerData.LastRanker.Parse_RankMy( parser.getInt64 ( "lmsalemoney" ),		//나의 점수 포인트.
														parser.getInt("lmrank"),				//나의 랭킹.
					                                   parser.getInt("lmcnt") );				//나의 친구들 수 (3명중 2위했다는 의미).

					ServerData.LastRanker.Parse_Rank1( 	parser.getString("l1gameid"),			//친구랭킹 1위 (gameid > 사진정보와 닉네임을 클라이언트에서 찾으세요.)
														parser.getInt("l1bestani"),				//대표동물.
														parser.getInt64 ( "l1salemoney" ) );	//점수 포인트.

					ServerData.LastRanker.Parse_Rank2(	parser.getString("l2gameid"),			//친구랭킹 2위.
														parser.getInt("l2bestani"),				//대표동물.
														parser.getInt64 ( "l2salemoney" ) );	//점수 포인트.

					ServerData.LastRanker.Parse_Rank2(	parser.getString("l3gameid"),			//친구랭킹 1위.
														parser.getInt("l3bestani"),				//대표동물.
														parser.getInt64 ( "l3salemoney" ) );	//점수 포인트.	

					GameData.nickName = parser.getString("nickname");

					GameData.rankInitTime = DateTime.Parse(parser.getString("userrankinitdate"));
					//@@@@ end

					//@@@@ start 0027
					UserData.battleRnk_my.Parser(parser.getInt("rkteam"),					//1 : 홀수팀.		//0 : 짝수팀.		//내가소속한팀 > 관리사이트 유저정보 > 6번째 탭에 있음.
	                                             parser.getInt64("rksalemoney"),			//		나의  판매수익.
	                                             parser.getInt64("rkproductcnt"),			//     	생산수량.
	                                             parser.getInt64("rkfarmearn"),				//		목장수익.
	                                             parser.getInt64("rkwolfcnt"),				//		늑대사냥.
	                                             parser.getInt64("rkfriendpoint"),			// 		친구포인트.
	                                             parser.getInt64("rkroulettecnt"),			//		룰렛.
	                                             parser.getInt64("rkplaycnt")				//		플레이타임.
	                                             );
					//@@@@ end

					UserData.ins.attendNewDayData.attendNewDay = parser.getInt( "attendnewday" );
					//attendnewday :  1 		> 신규출석, 일정확률로 해당되면 지급
					//attendnewday : -1 		> 이미 적용했다. 계속로그인하면 -1로 온다.

					//@@@@ start 0030
					////////////////////////////////////////////////////////////
					//보물할인.
					// 캐쉬와 하트 둘다 할인한다.
					//
					// * 관리사이트 > 뽑기부가상품 > (탭)보물할인.
					///////////////////////////////////////////////////////////
					ServerData.TreasureBbopgi.ParseEvent_Sale(parser.getInt("roulsaleflag"), parser.getInt("roulsalevalue"));
					//parser.getInt("roulsaleflag");		//활성(1), 비활성(-1)
					//parser.getInt("roulsalevalue");		//활성(x%할인)
					
					////////////////////////////////////////////////////////////
					//특정 상품이 나오면 선물로 템을 보상해주기.
					//checkani (이것을 뽑아서 ) > checkreward (이것을 지급했다.).
					//                           -1이면 없다는 뜻임.
					//
					// * 관리사이트 > 뽑기부가상품 > (탭)보물보상.
					///////////////////////////////////////////////////////////
					/// 보상은 우편함으로 온다.
					ServerData.TreasureBbopgi.ParseEvent_TargetBbopgi(parser.getInt("roulrewardflag"));
					//활성(1), 비활성(-1)
					//뽑기에서와 달리 무엇을 보상해주었는지는 없음.
					
					////////////////////////////////////////////////////////////
					// 시간이벤트 : 12, 18, 23
					//
					// * 관리사이트 > 뽑기부가상품 > (탭)보물 확률 상승.
					///////////////////////////////////////////////////////////
					ServerData.TreasureBbopgi.ParseEvent_DropRate( parser.getInt("roultimeflag"), parser.getInt("roultimetime1"), parser.getInt("roultimetime2"), parser.getInt("roultimetime3") );
					//parser.getInt("roultimeflag");		//활성(1), 비활성(-1)
					//parser.getInt("roultimetime1");
					//parser.getInt("roultimetime2");
					//parser.getInt("roultimetime3");
					
					////////////////////////////////////////////////////////////
					// 보물무료뽑기 : 10회당 1회 무료뽑기.
					//
					// * 관리사이트 > 뽑기부가상품 > (탭)보물할인.
					//   point 10 / max 100 > 1회 뽑을때마다 10포인트씩 누적.
					//   100이되면 하나가 채워져서 서버에서 온다.
					///////////////////////////////////////////////////////////
					ServerData.TreasureBbopgi.ParseEvent_FreeCharge( parser.getInt("tsgauageflag"),
					                                             parser.getInt("tsgrade2gauage"),
					                                             parser.getInt("tsgrade3gauage"),
					                                             parser.getInt("tsgrade4gauage"),
					                                             parser.getInt("tsgrade2free"),
					                                             parser.getInt("tsgrade3free"),
					                                             parser.getInt("tsgrade4free") );
					//parser.getInt("tsgauageflag");		//활성(1), 비활성(-1)
					// (D, C) 없음.

					//parser.getInt("tsgrade2gauage");	// (B, A) x 1
					//parser.getInt("tsgrade3gauage");	// (A, S) x 1
					//parser.getInt("tsgrade4gauage");	// (A, S) x (3 + 1)
					// ((D, C) 없음.
					//parser.getInt("tsgrade2free");		// (B, A) x 1 		> 무료1회.
					//parser.getInt("tsgrade3free");		// (A, S) x 1 		> 무료1회.
					//parser.getInt("tsgrade4free");		// (A, S) x (3 + 1) > 무료1회.
					//@@@@ end

					//@@@@ start 0032
					////////////////////////////////////////////////////////////
					// 보물강화할인.
					// 캐쉬와 하트 둘다 할인한다.
					//
					// * 관리사이트 > 뽑기부가상품 > (탭)보물강화할인.
					///////////////////////////////////////////////////////////
					ServerData.TreasureUpgrade.ParseEvent_Sale(parser.getInt("tsupgradesaleflag"),parser.getInt("tsupgradesalevalue"));
					//parser.getInt("tsupgradesaleflag");		//활성(1), 비활성(-1)
					//parser.getInt("tsupgradesalevalue");	//활성(x%할인)
					//@@@@ end

					//@@@@ start 0033
					////////////////////////////////////////////////////////////
					// 회전판.
					//
					// * 관리사이트 > 뽑기/강화/회전판	> 회전판무료돌리기.
					// * 관리사이트 > 유저정보 > (탭)회전판.
					//
					///////////////////////////////////////////////////////////
					//1. 1일 1회.
					//parser.getInt("roulette");				//1:돌릴수있음, -1:이미돌림	<= 기존에 구현된것임.
					
					//2.결정회전판 이벤트.
					ServerData.Roulette.Pasrse_Event(parser.getInt("wheelgauageflag"), parser.getInt("wheelgauage"), parser.getInt("wheelfree"));
					//parser.getInt("wheelgauageflag");			//활성(1), 비활성(-1)
					//parser.getInt("wheelgauage");				//게이지정보.
					//parser.getInt("wheelfree");					//1이면 돌릴수 있도록 표시.
					//@@@@ end

					// 유저 복귀 이벤트.
					//@@@@ start 0034

					GameData.comebackStep = parser.getInt ( "rtnstep" );

					// 패키지 상품 정보.
					ServerData.Package.Parse ( parser , _xml , "syspack" );

				}

				// 친구 정보 <-(Kakao).
				if (GuestPlayData.guestPlay == false){
					//Debug.Log(" friend info ==== start");
					GameData.ReadFriendInfoFromKakao ( parser , _xml , "" );
					//Debug.Log(" friend info ==== end");
				}

				//선물정보.
				GameData.ReadGiftItem ( parser , _xml , "giftitem" );

				//추천게임.
				GameData.ReadRecomendApp ( parser , _xml , "sysrecommend" );

				// 로칼 정보와 합치기전 친구 정보.
				if (GuestPlayData.guestPlay == false)
				{
					ServerData.ServerFriend.ReadServerFriend(parser, _xml, "frank");
				}
				
				//@@@@ start 0002
				//카톡 초대 토크ID, 전송일.
				//ServerData.ServerFriend
				ServerData.InvitedKakaoFriend.ReadServerData(parser, _xml, "kakaoinvite");
				//@@@@ end

				//@@@@ start 0012
				//전체랭킹 [랭킹, 게임아이디, 동물, 판매금액].
				//                닉네임, 사진(안나옴)
				if (GuestPlayData.guestPlay == false)
				{
					ServerData.TotalRank.ReadServerData(parser, _xml, "trank");

					ServerData.RebirthRank.ReadServerData(parser, _xml, "rebitrhrank");
				}
				//@@@@ end

				//@@@@ start 0027
				//현재대전내용(1건).
				UserData.battleRnk_current.Parser(parser, _xml, "rkcurrank");
				
				//지난 대전내용(1건). > 지난내용 보기 위해서.
				UserData.battleRnk_last.Parser(parser, _xml, "rklaterank");
				//@@@@ end

				break;
			case Protocol.RESULT_ERROR_SERVER_CHECKING:
				#if NETDEBGU_MODE
				Debug.Log("PTS_LOGIN > error > 시스템 점검중입니다. > 게임 종료.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log("PTS_LOGIN > error > 아이디를 확인해라 > 다시 로그인.");
				#endif
				break;
			case Protocol.RESULT_NEWVERION_CLIENT_DOWNLOAD:		
//				Debug.Log ( parser.getString("patchurl") );

				GameData.pathUrl = parser.getString("patchurl");		//패치URL.
				#if NETDEBGU_MODE
				Debug.Log("PTS_LOGIN > error > 클라이언트가 새로나왔습니다. > 다시 받아주세요.");
				#endif
				break;
			case Protocol.RESULT_ERROR_BLOCK_USER:
				#if NETDEBGU_MODE
				Debug.Log("PTS_LOGIN > error > 블럭된 계정입니다. > 다시 로그인.");
				#endif

				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_LOGIN > error > not found error");
				#endif
				break;
			}
			break;

		case Protocol.PTS_CASHBUY:
			#if NETDEBGU_MODE
			Debug.Log("[C <- S] PTS_CASHBUY _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CASHBUY > success");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NETDEBGU_MODE
				Debug.Log(" > 캐쉬구매 > 아이디를 찾지 못했습니다. > 팝업처리.");
				#endif
				break;
			case Protocol.RESULT_ERROR_CASH_COPY:
				#if NETDEBGU_MODE
				Debug.Log(" > 캐쉬구매 > 캐쉬카피(블럭처리됩니다) > 팝업처리.");
				#endif
				break;
			default:
				#if NETDEBGU_MODE
				Debug.Log("PTS_CASHBUY > error > not found error");
				#endif
				break;
			}
			break;
		
		default:
			Debug.LogError("[error]:[C -> S] not define code\n" + _xml);
			break;
		}

		return _resultcode;
	}

	public int debug = 0;
	public float debugDelay = 0f;
	public int debugErrCode = 0;

	public IEnumerator Handle(WWW _www, VOID_FUN_INTINT _onResult )
	{
		if ( debug > 0 )
		{
			Debug.Log("test fail net("+debug+")");
			
			debug--;

			yield return new WaitForSeconds(debugDelay);

			if ( _onResult != null ) {
				_onResult ( Protocol.CONNECT_STATE_SUCCESS , debugErrCode );
			}

			StartCoroutine ( DealyKill ( _www ) );
		}
		else 
		{
			float _timeOut = Time.realtimeSinceStartup + Protocol.LIMIT_CONNECT_TIME;

			while( !_www.isDone && Time.realtimeSinceStartup < _timeOut && string.IsNullOrEmpty( _www.error ) ){
				yield return 0;
			}

			if( string.IsNullOrEmpty( _www.error ) && _www.isDone)
			{
				int _detail = parseCode ( _www.text.Trim() );

				if ( _onResult != null ) {
					_onResult ( Protocol.CONNECT_STATE_SUCCESS , _detail );
				}

				_www.Dispose();
			}
			else if(Time.realtimeSinceStartup >= _timeOut)
			{
				if ( _onResult != null ) {
					_onResult ( Protocol.CONNECT_STATE_FAIL , Protocol.CONNECT_STATE_FAIL );
				}

				StartCoroutine ( DealyKill ( _www ) );
			}
			else 
			{
				Debug.Log("err connect");

				if ( _onResult != null ) {
					_onResult ( Protocol.CONNECT_STATE_FAIL , Protocol.CONNECT_STATE_FAIL );
				}

				StartCoroutine ( DealyKill ( _www ) );
			}
		}
	}
	
	// 이렇게 하는 이유.
	// 수신 받지 못한 www를 죽일때 유니티에서 멈추는 버그가 있기때문에.
	// www가 완전히 작업이 끝날때까지 기다렸다가 죽인다. 
	private IEnumerator DealyKill ( WWW _www )
	{
		// 뭔가 에러가 있거나.
		// isDone 이 true이면 멈춘다.
		while ( _www.isDone == false  ) 
		{
			yield return null;
		}
		
		_www.Dispose ();
	}



	public static string GetErrMsg ( int _detail )
	{
		Debug.Log("_detail:" + _detail);
		switch ( _detail )
		{
		case Protocol.RESULT_SUCCESS:						return Msg.NET_RESULT_SUCCESS;
		case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:		return Msg.NET_FAIL_NOT_FOUND_GAME_ID;
		case Protocol.RESULT_ERROR_GIFTITEM_NOT_FOUND:		return Msg.NET_FAIL_GIFTITEM_NOT_FOUND;
		case Protocol.RESULT_ERROR_GIFTITEM_ALREADY_GAIN:	return Msg.NET_FAIL_GIFTITEM_ALREADY_GAIN;
		case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:		return Msg.NET_FAIL_NOT_SUPPORT_MODE;
		case Protocol.RESULT_ERROR_NOT_FOUND_CERTNO:		return Msg.NET_FAIL_NOT_COUPON_HAVE;
		case Protocol.RESULT_ERROR_ALREADY_REWARD_COUPON:	return Msg.NET_FAIL_ALREADY_COUPON_USE;
		case Protocol.RESULT_ERROR_ONE_PERSON_ONE_COUPON:	return Msg.NER_FAIL_COUPON_ONLY_ONETIME;
		case Protocol.RESULT_ERROR_ALREADY_REWARD:			return Msg.NET_FAIL_ALREADY_REWARD_PLAY_APP;

		default:											return string.Format(Msg.ERR_SERVER,_detail);
		}
	}


	private const string KEY_ID = "laDjeijfsS";
	private const string KEY_PW = "v209Z78as34S";

	public static void SaveIdPwToLocalDB( string _id, string _pw )
	{
		PlayerPrefs.SetString(KEY_ID, _id);
		PlayerPrefs.SetString(KEY_PW, _pw);
		PlayerPrefs.Save();
	}

	public static void SetIdPwFromLocalDB()
	{
		strCreateID = PlayerPrefs.GetString(KEY_ID, Constant.NULL_STRING);
		strCreatePW = PlayerPrefs.GetString(KEY_PW, Constant.NULL_STRING);
	}


	public static void SetIdPwFromLocalDB( string _id, string _pw )
	{
		strCreateID = _id;
		strCreatePW = _pw;
	}


	public static bool HasId_Pw()
	{
		string _idFromLocalDb = PlayerPrefs.GetString(KEY_ID, Constant.NULL_STRING);
		string _pwFromLocalDb = PlayerPrefs.GetString(KEY_PW, Constant.NULL_STRING);

		if (_idFromLocalDb.Equals(Constant.NULL_STRING))
		{
			return false;
		}

		if (_pwFromLocalDb.Equals(Constant.NULL_STRING))
		{
			return false;
		}

		return true;
	}

	public static void ClearIdPw()
	{
		PlayerPrefs.SetString(KEY_ID, Constant.NULL_STRING);
		PlayerPrefs.SetString(KEY_PW, Constant.NULL_STRING);
		PlayerPrefs.Save();
	}

	private string MakeSaveData_FVSAVE_userInfo()
	{
		System.Text.StringBuilder _sb = new System.Text.StringBuilder();

		// 판매 금액.
		_sb.Append( Protocol.SAVE_USERINFO_SALEMONEY );
		_sb.Append(':');
		_sb.Append( UserData.ins.serverCollectData.sellCoin.val );
		_sb.Append(';');

		// 최고 동물.
		_sb.Append( Protocol.SAVE_USERINFO_BESTANI );
		_sb.Append(':');
		_sb.Append( AnimalManager.ins.GetBestAnimalOnField() );
		_sb.Append(';');

		// 보유 캐쉬.
		_sb.Append(10);
		_sb.Append(':');
		_sb.Append( GameData.GetProductCnt( Constant.ITEMCODE_MILK_CRYSTAL ) );
		_sb.Append(';');

		// 보유 vip 포인트.
		_sb.Append(11);
		_sb.Append(':');
		_sb.Append(GameData.vip);
		_sb.Append(';');

		//@@@@ start 0025
		// 룰렛 돌리기.
//		_sb.Append(20);
//		_sb.Append(':');
//		_sb.Append( UserData.ins.rouletteData.rouletteState );
//		_sb.Append(';');
		//-1 :      돌렸음.
		// 1 : 아직 안돌림 or 현재 상태를 그대로 두세요.라는 의미로 작동함.
		//@@@@ end

		// 룰렛 상태 저장.
//		_sb.Append(21);
//		_sb.Append(':');
//		_sb.Append(GameData.cashRoulette);
//		_sb.Append(';');

		// 티켓 룰렛 사용 횟수.
//		_sb.Append(22);
//		_sb.Append(':');
//		_sb.Append(UserData.ins.rouletteData.ticketRouletteUseCount);
//		_sb.Append(';');

		// 생산수량.
		_sb.Append(30);
		_sb.Append(':');
		_sb.Append( UserData.ins.serverCollectData.createProductCount );
		_sb.Append(';');

		// 목장 수익.
		_sb.Append(31);
		_sb.Append(':');
		_sb.Append( UserData.ins.serverCollectData.mokjangIncome );
		_sb.Append(';');


		// 늑대 사냥 횟수.
		_sb.Append(32);
		_sb.Append(':');
		_sb.Append( UserData.ins.serverCollectData.wolfHitCount );
		_sb.Append(';');

		// 플레이 타임.
		_sb.Append(33);
		_sb.Append(':');
		_sb.Append( UserData.ins.serverCollectData.playTime );

		//Debug.Log(_sb.ToString());
		return _sb.ToString();
	}

*/
}
}
































