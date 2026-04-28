//
// Copyright (c) 2025, 合同会社玉木栄三郎事務所.
// All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosIfGUI.Constants
{
    public static class ElementNameConstants
    {
        // モーダルエリア
        // モーダルタイトル VI
        public static readonly string[] TitleCandidates = { "tvTitle", "title" };

        // モーダルで使われる画像 VI
        public static readonly string[] ImageElementCandidates = { "lottieDecorView", "img_brand" };

        // モーダルメッセージ VI
        public static readonly string[] MessageCandidates = { "tvMessage", "tvContent", "TextView_dialog_message" };

        // 店員呼出表示 VI
        public const string CallStaffLabelId = "tvCallStaff";


        // 通常画面エリア
        // 0行目: ステータスアイコンエリア VI
        public static readonly HashSet<string> StatusIconIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "imgServer", "img_ic_server", "img_ic_report", "imgReport"
        };

        // 1行目: ヘッダエリア VI
        public static readonly HashSet<string> HeaderButtonIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "btnBackspace", "backbtn", "btnCancel", "btn_cancel", "btnImgCancel"
        };

        // 2行目: タイトルエリア VI
        public static readonly HashSet<string> PathAndTitleIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "pathScreen", "title"
        };

        // 3行目: 指示文エリア VI
        public static readonly HashSet<string> GuideAndMessageIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "tvGuide", "message", "tvWarningCredit", "tvGuidePayment"
        };

        public static readonly HashSet<string> WarningLikeVIs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "tvWarningCredit", "tvGuidePayment"
        };

        public static readonly HashSet<string> SimplePaymentButtonIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "btnAeonCard",
            "btnDigitalTicket"
        };

        // 8行目: アニメエリア VI
        public static readonly HashSet<string> AnimationGuideIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "aminGuide", "animGuide"
        };

        // 9行目: ブランドとかのロゴ  VI
        public static readonly HashSet<string> LogoImageIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "imgLogo", "logoView", "imgAeonCard"
        };

        // 10行目: ロゴとかの説明  VI
        public static readonly HashSet<string> MessageElementIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "txt_customer", "tvNotice", "txt_errmessage"
        };

        // 12行目: WAON 系 エリア VI
        public static readonly HashSet<string> WaonElementIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "btnWaonPoint", "btWaonPoint", "imgWaonpoint", "btnScanBarCode", "btConfirm",
            "btnOther", "btnInputBC", "btnSubmit", "btnUseAllPoint",
            "btSubmit", "txt_ok_button", "btnKeyboard", "btnOpenKeyboard", "btnScanQr", "btnConfirm", "btnClear", "btnPen"
        };

        // WAON エリアのボタン群
        public static readonly HashSet<string> WaonSubmitButtonIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "btnSubmit",
            "btConfirm",
            "btnConfirm",
            "btSubmit",
            "txt_ok_button",
            "btnConfirm",
            "btnClear",
        };

        // 13行目: フッタエリア VI
        public static readonly HashSet<string> FooterElementIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "tvCurrentDateTime", "tvVersion", "tvTerminalNumber", "tvStoreName",
            "viewBottom", "businessValue", "terminalNumberLabel", "versionNumberLabel", "shopnameLabel"
        };
    }
}
