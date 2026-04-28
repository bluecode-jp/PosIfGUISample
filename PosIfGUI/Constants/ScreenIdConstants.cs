//
// Copyright (c) 2025, 合同会社玉木栄三郎事務所.
// All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PosIfGUI.Constants
{
    public static class ScreenIdConstants
    {
        public const string mainMenuScreenId = "A0061FPP";
        public const string paymentOptionsScreenId = "A0007FPS";
        public const string confirmPaymentScreenId = "A1111FAC";
        public const string loadingScreenId = "A0002DCV";
        public const string readAeonGiftCardScreenId = "E0000FRC";
        public const string readCreditCardScreenId = "D0000FRC";
        public const string creditCardPaymentOptionsScreenId = "D0002FC";
        public const string executeSinglePaymentCreditCardPaymentScreenId = "D0003FPR";
        public const string executeAeonGiftPaymentScreenId = "E0001FCP";
        public const string paymentSuccessful = "A0025DSV";

        public const string defaultPackageId = "jp.aeon.launcher2";
        public const string aeonGiftPackageName = "jp.aeon.aeongift2";
        public const string creditCardPackageName = "jp.aeon.credit2";
        // モーダル扱いの SI
        public static readonly HashSet<string> ModalScreenIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "A0002DCV",
            "A0002LOADING",
            "A0002WAIT",
            "A0003DA",
            "C0002CYT2",
            "A0026DANA",
            "A0025DSV",
            "C0001CDB",
            "A3333DARM",
            "C0005CDRT1",
            "C0006CDRL"
        };

        // テンキー画面のID
        public static readonly HashSet<string> TenkeyScreenIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "I0004FIB",
            "I0005FIP",
            "F0002FECV",
            "F0001FAIA"
        };

        // PI（ポーリングインターバル）未定義だが100msを返すべきSI(恐らく不具合なので暫定)
        public static readonly HashSet<string> PollingDelay100ScreenIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "D0000FRC", "H0000FUPRC", "E0000FRC", "G0001FPR",
            "I0002FRB", "H0002FUPEP", "I0001FRCN", "D0006FEP"
        };
    }
}
