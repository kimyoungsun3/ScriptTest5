using UnityEngine;
using System.Collections;

namespace NetworkManagerK6{
	public class Msg  {
		public const string CROP_UPGRADE_COMPLETE = "업그레이드 완료!!";
		public const string LV = "Lv.{0}";
		public const string UPGRADE_FAIL = "업그레이드 실패";

		public const string NET_NOT_FOUND_ERR = "알 수 없는 오류";
		public const string NET_RESULT_SUCCESS = "정상 처리되었습니다.";
		public const string NET_RESULT_ERROR_ID_DUPLICATE = "아이디가 중복되었습니다.";
		public const string NET_RESULT_NEWVERION_CLIENT_DOWNLOAD = "신규 버전이 출시 되었습니다.\n다운로드 페이지로 이동합니다.";
		public const string NET_RESULT_ERROR_SERVER_CHECKING = "시스템 점검중 입니다.";
		public const string NET_RESULT_ERROR_BLOCK_USER = "블럭처리된 유져 입니다.";
		public const string NET_RESULT_ERROR_NOT_FOUND_GAMEID = "아이디가 틀렸습니다.";
		public const string NET_RESULT_ERROR_NOT_FOUND_PASSWORD = "비밀번호가 틀렸습니다.";
		public const string NET_RESULT_ERROR_GIFTITEM_NOT_FOUND = "선물 아이템이 존재하지 않습니다.";
		public const string NET_RESULT_ERROR_GIFTITEM_ALREADY_GAIN = "아이템을 이미 지급받았습니다.";
		public const string NET_RESULT_ERROR_NOT_SUPPORT_MODE = "지원하지 않는 모드 입니다.";
		public const string NET_RESULT_ERROR_NOT_FOUND_ITEMCODE = "아이템 코드를 찾을 수 없습니다.";
		public const string NET_RESULT_ERROR_UPGRADE_FULL = "업그레이드가 최대치 입니다.";
		public const string NET_RESULT_ERROR_PARAMETER = "파라미터 오류";
		public const string NET_RESULT_ERROR_CASHCOST_LACK = "다이아가 부족합니다.";
		public const string NET_RESULT_ERROR_LISTIDX_NOT_FOUND = "해당 아이템 존재하지 않습니다.";

		public const string NET_CONNECTION_TRY = "연결을 다시 시도합니다.";
		public const string NET_CONNECTION_TRY_2 = "네트워크 연결이 끊어졌습니다.\n랜이나 무선인터넷 연결상태를 확인하여 주세요.\n\n연결을 다시 시도합니다.";
		public const string NET_CONNECTION_TRY_WITH_OUT_RETRY = "네트워크 연결이 끊어졌습니다.\n랜이나 무선인터넷 연결상태를 확인하여 주세요.";

		public const string SYSINQUIRE_TITLE = "고객 센터";
		public const string SYSINQUIRE_TOP_TEXT_01 = "문의 내용을 상세히 적어주세요.";
		public const string SYSINQUIRE_TOP_TEXT_02 = "( 고객 센터 운영 시간:평일 10:00 ~ 19:00 )";
		public const string SYSINQUIRE_CATOGORY_DEFAULT = "카테고리";
		public const string SYSINQUIRE_TEXT_DEFAULT = "문의 사항을 작성해 주세요.";
		
		public const string SYSINQUIRE_CHECK_MSG = "작성하신 내용으로 문의 하시겠습니까?";
		public const string SYSINQUIRE_NET_SUCCESS = "문의 하기를 보냈습니다.";
		public const string SYSINQUIRE_NET_FAIL = "문의 하기를 보내지 못했습니다.\n잠시 후 다시 시도해 주세요.";

	}
}
