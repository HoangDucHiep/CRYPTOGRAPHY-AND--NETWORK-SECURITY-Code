using Atbmtt.ClassicalEncription;

namespace AtbmttTest
{
    [TestClass]
    public sealed class TestExtendedVigenereCipher
    {
        #region TEST CONSTRUCTOR EXCEPTIONS
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_VigenereCipher_Constructor_EmptyKey()
        {
            _ = new ExtendedVinegereCipher("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_VigenereCipher_Constructor_NullKey()
        {
            _ = new ExtendedVinegereCipher(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_VigenereCipher_Constructor_InvalidKey()
        {
            _ = new ExtendedVinegereCipher("key123"); // Contains numbers
        }
        #endregion

        #region TEST ENCODE

        [TestMethod]
        public void Test_VigenereCipher_Encode_Repeat()
        {
            string plainText = "";
            string key = "cryptii";
            string expected = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Repeat1()
        {
            string plainText = "The quick brown fox jumps over 13 lazy dogs.";
            string key = "cryptii";
            string expected = "Vyc fnqkm spdpv nqo hjfxa qmcg 13 eiha umvl.";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Repeat2()
        {
            string plainText = "MONEYISAGOODSER";
            string key = "EVERYONE";
            string expected = "QJRVWWFEKJSUQSE";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Repeat3()
        {
            string plainText =
                "Pleased him another was settled for. Moreover end horrible endeavor entrance any families. Income appear extent on of thrown in admire. Stanhill on we if vicinity material in. Saw him smallest you provided ecstatic supplied. Garret wanted expect remain as mr. Covered parlors concern we express in visited to do. Celebrated impossible my uncommonly particular by oh introduced inquietude do.";
            string key = "ThisIsKey";
            string expected =
                "Ismsawn lgf hvgbzov utz awblvib yvz. Ewjostxy mfl zyvpbitw mfniyovz wvlbelvl ifg xkqgepmk. Qfmskx hxhmsb ivmlvl wf yj raywov ax ebfpzw. Alkrfbst gv oo md opkavadc ktamjqsv ml. Lhe zqe cqyesmkb qyy nkvdalwn ialailqu cynisqwl. Ykvpxa esvloh cqwmub joqybu ik uj. Mstxymv xsbpmkz kgvuovl pl mpxjowq bu daaadib mv lg. Kwvizkhbwl awtmlzqttw wc sgjweugxpw ihzlquepyk ig gp axxphkcumv sronpmlcvo hm.";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Repeat4()
        {
            string plainText =
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate";
            string key = "ThisIsKey";
            string expected =
                "Evzwu azwsf kwdwj cmr ttml, kgxwcvamlcwb ebbwqkkaxk cepb. Smfoel vvuewvy pgzbts myox bhswj. Iwxiyg tikas. Myk lvkaqk xerhxcw xwxerbick ml weegpa vqk zepmbzamfd qmgamk, vscgcmbz jqvsgseba eck. Nslxj ymie pijbz, cdbjsggxz vwk, hopjxubwaiei cn, wzwbaeq onpa, kme. Xyjeh kgvkousta usakk usbz mfqe. Nslxj xwlw tyqmv, njqfqmjeh dwt, svmonlb fmu, fyjibbsbw";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Repeat5()
        {
            string plainText = "asdhHK 123asldk SDJ123jSD dasd asdAS@$d123123";
            string key = "longcoMpLicAtEDpROvJpkEy";
            string expected = "lgqnJY 123mhwlm SWN123mHU rvbs kwbLG@$q123123";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Repeat6()
        {
            string plainText = "Thử thuật toán Vinegere repeatkey với alphabet tiếng việt";
            string key = "đâylakey";
            string expected = "Zjử rtuậđ amár Ygzerlpk tdbekaika uớu avvêđdde ttếse âkệr";
            string alphabet = "aăâbcdđeêghijklmnoôơpqrstuưvxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Autokey()
        {
            string plainText = "";
            string key = "cryptii";
            string expected = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Autokey1()
        {
            string plainText = "The quick brown fox jumps over 13 lazy dogs.";
            string key = "cryptii";
            string expected = "Vyc fnqkd iveqv hyy aiicx csnl 13 xprm ysxd.";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Autokey2()
        {
            string plainText = "MONEYISAGOODSER";
            string key = "EVERYONE";
            string expected = "QJRVWWFESCBHQMJ";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Autokey3()
        {
            string plainText =
                "Pleased him another was settled for. Moreover end horrible endeavor entrance any families. Income appear extent on of thrown in admire. Stanhill on we if vicinity material in. Saw him smallest you provided ecstatic supplied. Garret wanted expect remain as mr. Covered parlors concern we express in visited to do. Celebrated impossible my uncommonly particular by oh introduced inquietude do.";
            string key = "ThisIsKey";
            string expected =
                "Ismsawn lgb lrollhy ems fsmapvz fgj. Qhkpsyjf vzr ysfmmspr hurvrdpc irguenxs rrl yrmvnmef. Gscaup ithmnt sjxeci sn fj qavbpb vb fwtzfa. Fbnnkutc sf pe vm dtnwaexg rvbgzvie gz. Sta yqm dundlazb kgg pczzawcr yrjhvblg vyrheixl. Islgte eeqzeu vbiacg kipefc eu fi. Gavmeev brtzjvj grccvcb nw glctijf er zfhzxwv bb yw. Umeiekowsf mxtpjsbfom yn ifuwnxszjs ccffuqhwyg bp hp kherfesqll vghilyvygm qe.";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Autokey4()
        {
            string plainText =
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate";
            string key = "ThisIsKey";
            string expected =
                "Evzwu azwsx rfpaz han mpse, qffaxcfimwse shkimlwmeg htxb. Sgvrgr nwfmsqs lviixm sjse lufzr. Ekrxdb xojse. Pym facaas pufgewm xwaamwrow tx zazvjm vml baxgcjlmfi mfgnva, rnlosgnv jvdaeyeoj dcv. Lqhpw igue isymu, kftdngtmk hpv, gmntifgiufyp py, ckilyoq uoxj, wxu. Hgbfi ugrerkflt oofke goil qnae. Dehmu trlq mifxq, uvlrpcdeo avt, nrqbfeo rpc, gcbjymnxg";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Autokey5()
        {
            string plainText = "asdhHK 123asldk SDJ123jSD dasd asdAS@$d123123";
            string key = "longcoMpLicAtEDpROvJpkEy";
            string expected = "lgqnJY 123mhwlm SWN123mHU rvbs kwbAK@$g123123";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test_VigenereCipher_Encode_Autokey6()
        {
            string plainText = "Thử thuật toán Vinegere repeatkey với alphabet tiếng việt";
            string key = "đâylakey";
            string expected = "Zjử rtuậđ amág Đcưăâaês ôôdlgaclp bớa elkseăbc tuếdơ vlệa";
            string alphabet = "aăâbcdđeêghijklmnoôơpqrstuưvxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Encode(plainText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region TEST DECODE

        #region REPEAT

        [TestMethod]
        public void Test_VigenereCipher_Decode_Repeat()
        {
            string cipherText = "";
            string key = "cryptii";
            string expected = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Repeat1()
        {
            string cipherText = "Vyc fnqkm spdpv nqo hjfxa qmcg 13 eiha umvl.";
            string key = "cryptii";
            string expected = "The quick brown fox jumps over 13 lazy dogs.";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Repeat2()
        {
            string cipherText = "QJRVWWFEKJSUQSE";
            string key = "EVERYONE";
            string expected = "MONEYISAGOODSER";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Repeat3()
        {
            string cipherText =
                "Ismsawn lgf hvgbzov utz awblvib yvz. Ewjostxy mfl zyvpbitw mfniyovz wvlbelvl ifg xkqgepmk. Qfmskx hxhmsb ivmlvl wf yj raywov ax ebfpzw. Alkrfbst gv oo md opkavadc ktamjqsv ml. Lhe zqe cqyesmkb qyy nkvdalwn ialailqu cynisqwl. Ykvpxa esvloh cqwmub joqybu ik uj. Mstxymv xsbpmkz kgvuovl pl mpxjowq bu daaadib mv lg. Kwvizkhbwl awtmlzqttw wc sgjweugxpw ihzlquepyk ig gp axxphkcumv sronpmlcvo hm.";
            string key = "ThisIsKey";
            string expected =
                "Pleased him another was settled for. Moreover end horrible endeavor entrance any families. Income appear extent on of thrown in admire. Stanhill on we if vicinity material in. Saw him smallest you provided ecstatic supplied. Garret wanted expect remain as mr. Covered parlors concern we express in visited to do. Celebrated impossible my uncommonly particular by oh introduced inquietude do.";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Repeat4()
        {
            string cipherText =
                "Evzwu azwsf kwdwj cmr ttml, kgxwcvamlcwb ebbwqkkaxk cepb. Smfoel vvuewvy pgzbts myox bhswj. Iwxiyg tikas. Myk lvkaqk xerhxcw xwxerbick ml weegpa vqk zepmbzamfd qmgamk, vscgcmbz jqvsgseba eck. Nslxj ymie pijbz, cdbjsggxz vwk, hopjxubwaiei cn, wzwbaeq onpa, kme. Xyjeh kgvkousta usakk usbz mfqe. Nslxj xwlw tyqmv, njqfqmjeh dwt, svmonlb fmu, fyjibbsbw";
            string key = "ThisIsKey";
            string expected =
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate";

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Repeat5()
        {
            string cipherText = "lgqnJY 123mhwlm SWN123mHU rvbs kwbAK@$g123123";
            string key = "longcoMpLicAtEDpROvJpkEy";
            string expected = "asdhHK 123asldk SDJ123jSD dasd asdPW@$t123123";

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Repeat6()
        {
            string cipherText = "Zjử rtuậđ amár Ygzerlpk tdbekaika uớu avvêđdde ttếse âkệr 123";
            string key = "đâylakey";
            string expected = "Thử thuật toán Vinegere repeatkey với alphabet tiếng việt 123";

            string alphabet = "aăâbcdđeêghijklmnoôơpqrstuưvxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AUTOKEY

        [TestMethod]
        public void Test_VigenereCipher_Decode_Autokey()
        {
            string cipherText = "";
            string key = "cryptii";
            string expected = "";

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Autokey1()
        {
            string cipherText = "Vyc fnqkd iveqv hyy aiicx csnl 13 xprm ysxd.";
            string key = "cryptii";
            string expected = "The quick brown fox jumps over 13 lazy dogs.";

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Autokey2()
        {
            string cipherText = "QJRVWWFESCBHQMJ";
            string key = "EVERYONE";
            string expected = "MONEYISAGOODSER";

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Autokey3()
        {
            string cipherText =
                "Ismsawn lgb lrollhy ems fsmapvz fgj. Qhkpsyjf vzr ysfmmspr hurvrdpc irguenxs rrl yrmvnmef. Gscaup ithmnt sjxeci sn fj qavbpb vb fwtzfa. Fbnnkutc sf pe vm dtnwaexg rvbgzvie gz. Sta yqm dundlazb kgg pczzawcr yrjhvblg vyrheixl. Islgte eeqzeu vbiacg kipefc eu fi. Gavmeev brtzjvj grccvcb nw glctijf er zfhzxwv bb yw. Umeiekowsf mxtpjsbfom yn ifuwnxszjs ccffuqhwyg bp hp kherfesqll vghilyvygm qe.";
            string key = "ThisIsKey";
            string expected =
                "Pleased him another was settled for. Moreover end horrible endeavor entrance any families. Income appear extent on of thrown in admire. Stanhill on we if vicinity material in. Saw him smallest you provided ecstatic supplied. Garret wanted expect remain as mr. Covered parlors concern we express in visited to do. Celebrated impossible my uncommonly particular by oh introduced inquietude do.";

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Autokey4()
        {
            string cipherText =
                "Evzwu azwsx rfpaz han mpse, qffaxcfimwse shkimlwmeg htxb. Sgvrgr nwfmsqs lviixm sjse lufzr. Ekrxdb xojse. Pym facaas pufgewm xwaamwrow tx zazvjm vml baxgcjlmfi mfgnva, rnlosgnv jvdaeyeoj dcv. Lqhpw igue isymu, kftdngtmk hpv, gmntifgiufyp py, ckilyoq uoxj, wxu. Hgbfi ugrerkflt oofke goil qnae. Dehmu trlq mifxq, uvlrpcdeo avt, nrqbfeo rpc, gcbjymnxg";
            string key = "ThisIsKey";
            string expected =
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Autokey5()
        {
            string cipherText = "lgqnJY 123mhwlm SWN123mHU rvbs kwbAK@$g123123";
            string key = "longcoMpLicAtEDpROvJpkEy";
            string expected = "asdhHK 123asldk SDJ123jSD dasd asdAS@$d123123";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Autokey6()
        {
            string cipherText = "Zjử rtuậđ amág Đcưăâaês ôôdlgaclp bớa elkseăbc tuếdơ vlệa 123";
            string key = "đâylakey";
            string expected = "Thử thuật toán Vinegere repeatkey với alphabet tiếng việt 123";

            string alphabet = "aăâbcdđeêghijklmnoôơpqrstuưvxyz";
            ExtendedVinegereCipher extendedVinegereCipher = new ExtendedVinegereCipher(
                key,
                alphabet
            );
            string actual = extendedVinegereCipher.Decode(cipherText, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #endregion
    }
}
