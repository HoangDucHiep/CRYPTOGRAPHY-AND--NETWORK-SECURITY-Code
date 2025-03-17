using Atbmtt.ClassicalEncription;

namespace AtbmttTest
{
    [TestClass]
    public sealed class TestVigenereCipher
    {
        #region TEST ENCODE
        [TestMethod]
        public void Test_VigenereCipher_Encode_Repeat1()
        {
            string plainText = "The quick brown fox jumps over 13 lazy dogs.";
            string key = "cryptii";
            string expected = "Vyc fnqkm spdpv nqo hjfxa qmcg 13 eiha umvl.";
            string actual = VigenereCipher.Encode(plainText, key, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Repeat2()
        {
            string plainText = "MONEYISAGOODSER";
            string key = "EVERYONE";
            string expected = "QJRVWWFEKJSUQSE";
            string actual = VigenereCipher.Encode(plainText, key, VigenereMode.REPEAT_KEY);
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
            string actual = VigenereCipher.Encode(plainText, key, VigenereMode.REPEAT_KEY);
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
            string actual = VigenereCipher.Encode(plainText, key, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Autokey1()
        {
            string plainText = "The quick brown fox jumps over 13 lazy dogs.";
            string key = "cryptii";
            string expected = "Vyc fnqkd iveqv hyy aiicx csnl 13 xprm ysxd.";
            string actual = VigenereCipher.Encode(plainText, key, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Encode_Autokey2()
        {
            string plainText = "MONEYISAGOODSER";
            string key = "EVERYONE";
            string expected = "QJRVWWFESCBHQMJ";
            string actual = VigenereCipher.Encode(plainText, key, VigenereMode.AUTOKEY);
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
            string actual = VigenereCipher.Encode(plainText, key, VigenereMode.AUTOKEY);
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
            string actual = VigenereCipher.Encode(plainText, key, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region TEST DECODE

        #region REPEAT
        [TestMethod]
        public void Test_VigenereCipher_Decode_Repeat1()
        {
            string cipherText = "Vyc fnqkm spdpv nqo hjfxa qmcg 13 eiha umvl.";
            string key = "cryptii";
            string expected = "The quick brown fox jumps over 13 lazy dogs.";
            string actual = VigenereCipher.Decode(cipherText, key, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Repeat2()
        {
            string cipherText = "QJRVWWFEKJSUQSE";
            string key = "EVERYONE";
            string expected = "MONEYISAGOODSER";
            string actual = VigenereCipher.Decode(cipherText, key, VigenereMode.REPEAT_KEY);
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
            string actual = VigenereCipher.Decode(cipherText, key, VigenereMode.REPEAT_KEY);
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
            string actual = VigenereCipher.Decode(cipherText, key, VigenereMode.REPEAT_KEY);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AUTOKEY
        [TestMethod]
        public void Test_VigenereCipher_Decode_Autokey1()
        {
            string cipherText = "Vyc fnqkd iveqv hyy aiicx csnl 13 xprm ysxd.";
            string key = "cryptii";
            string expected = "The quick brown fox jumps over 13 lazy dogs.";
            string actual = VigenereCipher.Decode(cipherText, key, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_VigenereCipher_Decode_Autokey2()
        {
            string cipherText = "QJRVWWFESCBHQMJ";
            string key = "EVERYONE";
            string expected = "MONEYISAGOODSER";
            string actual = VigenereCipher.Decode(cipherText, key, VigenereMode.AUTOKEY);
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
            string actual = VigenereCipher.Decode(cipherText, key, VigenereMode.AUTOKEY);
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
            string actual = VigenereCipher.Decode(cipherText, key, VigenereMode.AUTOKEY);
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #endregion
    }
}
