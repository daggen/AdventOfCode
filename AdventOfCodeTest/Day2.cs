﻿using System.Collections.Generic;
using System.Linq;
using AdventOfCodeLib;
using Xunit;

namespace AdventOfCodeTest
{
    public class Day2
    {
        [Fact]
        public void TestParse()
        {
            var parsedLine = new PasswordPolicy(Input[0]);

            Assert.Equal(3, parsedLine.Minimum);
            Assert.Equal(11, parsedLine.Maximum);
            Assert.Equal('z', parsedLine.Character);
            Assert.Equal("zzzzzdzzzzlzz", parsedLine.Password);
            Assert.True(parsedLine.IsValid());
        }

        [Fact]
        public void TestParseTwo()
        {
            var parsedLine = new PasswordPolicy("1-3 a: abcde");

            Assert.Equal(1, parsedLine.Minimum);
            Assert.Equal(3, parsedLine.Maximum);
            Assert.Equal('a', parsedLine.Character);
            Assert.Equal("abcde", parsedLine.Password);
            Assert.True(parsedLine.IsValid());
        }

        [Fact]
        public void TestParseAll()
        {
            var totalValid = Input.Select(i => new PasswordPolicy(i)).Count(p => p.IsValid());
            Assert.Equal(550, totalValid);
        }

        [Fact]
        public void TestParse2All()
        {
            var totalValid = Input.Select(i => new PasswordPolicy(i)).Count(p => p.IsValid2());
            Assert.Equal(634, totalValid);
        }

        public List<string> Input = new List<string>{"3-11 z: zzzzzdzzzzlzz", "3-7 x: xjxbgpxxgtx", "3-4 v: vvmv", "3-5 t: tgkfq", "9-10 j: jjjjjjjjqjjjj", "5-7 r: rnhrhrr", "2-6 n: gnntnnsnnqjsbrn", "3-4 g: vrggfvxsgmggkgsm", "1-4 c: brccqr", "1-5 h: hhhzzvcdhhhhhhhh", "4-11 c: ncnqbzlkckc", "1-13 q: hqqqqqqqqqqqlq", "8-9 h: hhhhhhxxkh", "3-9 b: bbbbsfbbc", "3-8 k: zfqzkzgk", "3-9 k: wjkwhnkkfvxk", "3-11 v: vgkvvcjvvvv", "5-6 l: llllhr", "9-11 z: lzzzgzzmzzdzzz", "13-16 w: wwlwwwwlwwxwwfwf", "8-11 r: rrrrrrrrrrcrdrr", "1-9 v: mlvvvxnwrwvv", "4-6 z: mzzzzz", "3-4 s: svsj", "8-11 w: wwwwwwwjwwww", "10-13 r: drrrrzhmxfjdrtfgr", "19-20 h: hhhhhhhhhhhhhhhhhhfh", "1-4 z: nzzcz", "10-11 d: ddldddddxdfdd", "10-14 d: dddddcddndkddd", "7-15 h: hhhhhhhhhhhhhhhhh", "1-9 h: rhhhhhhhhh", "3-4 m: mmztmm", "4-6 w: wmwxcwwlwwj", "7-15 g: ggggggggggnggglgg", "9-14 n: ntnnnnqnnnnnng", "2-3 f: fffl", "1-7 b: bjsqsbbzblt", "3-6 c: cckccccc", "4-9 z: hhgtvzszb", "1-7 l: tlllllll", "2-3 v: mknzrq", "12-18 w: wwwwwwwwwnwwwwwwwsww", "5-8 k: kkkgkjkdkrwgk", "10-12 z: gczzgvzzpzwzzzzzf", "11-12 x: xxxxxxxxxnqxxnxx", "4-7 c: chccccgccccscpcc", "7-9 k: kqbkxhkkkkkscfr", "2-4 r: rrrrr", "3-5 p: lwhwp", "11-13 r: pfjmrrdqnbrwrn", "4-8 l: nkpmjlrbtsxdzkqjqj", "1-10 k: kkbdtkkqrkkkkkknklk", "16-17 b: cxtqsbfbtkxqbprzbbgr", "7-9 x: xlgxdxxtqhxkbnxw", "5-6 k: kbkqkqkk", "6-9 s: sbssspssk", "13-17 p: pzrpphmphgpkpbppj", "2-8 r: ttbrrmrfr", "16-17 c: cccccscckccccccvccc", "4-5 v: hvvmv", "4-12 s: swssssssssshjsszrss", "9-10 q: qgqqqjqjkqhqq", "2-4 s: rwtknhj", "3-8 s: rbstpgqdslkvkkzprdzp", "8-9 d: ddsddvdpd", "1-2 r: rkrrrrrtrrdnrr", "7-8 v: vfpfrmltllx", "2-3 k: knkrk", "4-5 f: pwrbffffc", "7-9 n: nnntnnnpnbjjn", "6-13 r: rrrrrrrrrrrrrr", "5-8 g: bfgzlbmgjn", "3-4 q: tqhq", "13-16 m: mmmmkmmmmmmmmmmmmmm", "1-5 w: wwwwhhwgwfgfkvwqbx", "4-7 n: nbjnnnqnbpc", "12-14 g: ggggggggghgbgk", "14-15 b: bdbbbxbdbzjtbcs", "8-9 z: zdfzxzkpz", "19-20 r: xbpdfrkmtgzrrqrrjrrr", "9-12 f: ffffffqfpgvzgfnf", "11-12 m: mmmmmmtmmmmm", "6-7 q: lbqqqqtb", "6-10 g: gggggtgggmgggg", "9-16 p: prppzppdppppkpjfpc", "1-3 x: xkrbrxdvrncxd", "17-18 b: bvpbnbrgvjcbbkjrbj", "13-18 d: dddmddddjdtdddddddd", "3-4 z: zzdzc", "8-9 m: mmmmmmmpm", "4-10 v: rvzqvrvvgvqvv", "1-9 q: jnhbqjlvq", "5-13 d: sddkhdjddkddpkvdsw", "5-9 d: dppdpddtmvl", "5-7 s: knzhssbxsjcssnsqb", "10-15 p: ppgvpppvplpppxpcp", "5-6 c: cczccv", "5-6 q: dqlvjfqqqqmqxq", "8-10 j: jjjjjwjxgknjfjj", "7-16 x: xxxxxxxxxxxxxxxcx", "9-13 h: hhhhzvwhhbhhhhljhh", "6-7 v: wvzxlvt", "16-18 f: fsffbffffpffffflfff", "1-5 r: rhrvrprwwb", "5-8 h: hhhhhhhjh", "3-6 p: ppgppsp", "15-17 r: rrrrrrrcrrrrlrrrb", "3-6 m: jhzmtmbnwh", "6-9 r: rhfjdrrhrg", "15-17 l: gqngllrsxrlpxblfl", "2-12 w: wwwwwwwwwwwww", "2-3 c: cpncdqzp", "3-4 f: ffllffqjf", "1-9 c: ccccccccbcc", "19-20 x: xxxxxxxwxxxxxxxxxxvx", "3-4 p: pplvs", "2-3 s: ftss", "11-12 s: ssdsssgsssths", "4-11 m: mmgmpmsqrmmmbwmm", "2-4 x: xhrk", "6-8 g: gggvgggv", "8-14 h: whhhlhhdhhhlhhh", "5-16 g: fnxpglggbrsgscqmzlfq", "5-11 h: hnhhhhhhhhthmh", "5-7 x: xvxxxxxqxw", "1-3 m: mnbt", "1-6 g: bgggbwghg", "1-6 f: sptjzfxcfw", "9-12 g: ggzgggggvgtjgg", "2-4 q: qlrvx", "4-5 j: jjjgj", "1-3 g: htmg", "6-8 j: jjjjjmjjjjjj", "12-14 h: xhhhhhhhhhhlhhfhh", "9-11 h: hkvhhgvhhhrshml", "12-13 j: jjjljjtjpjjjgj", "6-7 r: drqdrrvr", "6-17 q: qqqlqqqqqqqqqqqqbqqq", "6-7 j: vjjrvjjjwzj", "11-12 v: vtvvvjvvvvgvv", "6-8 x: xxxbcbxl", "3-9 f: fffffffff", "9-10 c: cccsccllrktqccfjzz", "2-5 s: ssssqn", "8-15 x: brlmqdmpfdqgmgptgxd", "1-4 t: ttlcttw", "5-6 c: cqccnc", "10-11 m: mqmmmmmmhvvlrmm", "3-4 j: jjhjwbjj", "10-11 c: ccccccccckd", "6-8 h: xhhchhfchh", "9-10 n: rnnnnnnncnnnn", "1-4 l: lvslw", "3-4 s: spfs", "11-13 n: fqtdnnnnnlnnx", "6-7 g: xdgxggp", "7-8 r: xhrnqlrr", "1-12 r: rrrrnwwrbrbrhrjxr", "14-15 b: chmbmkxngftlfbf", "1-3 m: fmmgmdgs", "5-7 w: fwwwswwwwwgw", "10-14 l: qlllgzljczmpls", "1-2 k: kkkq", "5-6 t: tttttt", "9-16 r: gpdtlxhntjfjjtlsxd", "4-5 g: kgjrhjmszxg", "4-5 z: zmszpklzsvz", "1-2 j: mfjjb", "3-6 s: sfxlzslsrszcsstsrb", "3-4 n: knlvnnkq", "1-2 s: jsst", "3-4 n: nsnm", "1-2 m: wzgczk", "10-11 b: btnnwgbgtht", "2-7 d: qcrdlgdgc", "10-13 w: wxwwdrwwwtdwwwswh", "2-3 c: cckcd", "3-6 p: ppqppppp", "1-6 n: nmsnjdn", "2-3 h: hhrhj", "11-12 w: wwwwwwwwwbvwwwwwh", "1-14 c: zkctkncccccfcccpccc", "6-7 m: zqvdkmnztcvmdrgbw", "1-13 q: qgmqhfgphjzrt", "6-7 l: llllljdv", "2-5 k: jspjkkkk", "7-15 p: ppppppvppppppppppp", "12-16 k: klkkkkkvkkzxkkkg", "8-17 x: xrxxnxxxsxvvxwbwzl", "11-14 s: ssssssssssssst", "8-15 z: cfznhznzwnzzrmm", "5-7 q: rqpnqwqvw", "2-9 c: zrpcmsclcbxtkbjvjc", "5-12 c: ccccpccccccjcccc", "3-8 w: hwswwrwwww", "4-9 p: wphzppzxpkxpbpzsplp", "4-5 q: rqqcqw", "11-14 k: kkckkkkwkkkkkdkk", "2-5 v: sqvvpvxvqgvvvzr", "5-10 f: ffffzffffjff", "4-6 b: bhbbjk", "4-8 z: zxzzzdzrzz", "4-8 h: hhhhfscrnhthppkkvh", "2-3 w: wgvwwjwwww", "3-5 d: dsdjddnndzbxtd", "5-13 m: mmmmfmmqmmmmmmm", "1-2 l: wglcs", "8-9 r: rrrrrrrsr", "8-16 l: lllllllllllllllll", "8-10 s: fmqsscwtshsss", "2-13 q: qqqzqqnxvqqsqjzl", "5-7 f: vrwrfffcmjwsfdzffm", "2-8 k: hhsbmrkkfhkkxkkz", "12-13 f: ffffffcffffff", "4-5 x: pzrxwxbxxdgfnxg", "1-5 c: cccww", "8-11 g: dgggjrggggggg", "9-14 t: httdgxxtthtsxtpsml", "7-11 p: pprppppppppp", "13-16 m: mmtkphqvkrzpwzsm", "12-15 g: gkzgggggggggggltb", "5-7 k: kkkkvkjkkk", "15-17 p: pppptpppppcjppppsp", "1-5 z: znzzz", "2-14 j: lnjjjghjjrjjjj", "3-9 r: rrvrrcrrr", "2-4 m: wggmmh", "4-5 b: bbbbrb", "2-16 v: vgvvvvvvvvvvvvvvv", "2-15 s: rsswfmvsrdkjqjssl", "3-6 b: nbbbnbbbb", "2-4 x: pxxwj", "12-13 c: cccccccccccccc", "6-8 g: gggggpgvggg", "3-6 j: srljvjqpkjvtdrndkgjr", "7-8 g: gmggtcggz", "3-7 p: tmvpppkm", "4-10 w: qrwgmwdwlww", "6-8 k: kknckkkjkkk", "11-14 g: ggggggggzggggcgggggg", "11-14 j: jjjwjjjjtmjjjgjj", "7-12 n: njmntnnsbncknqnn", "5-8 t: tbrttttctrt", "4-6 f: gffrffzffffffm", "4-11 c: pksccvlcsrcjgmzn", "2-3 p: vbcfdppzw", "2-5 c: lqfcc", "1-2 h: lhskgvhc", "10-11 b: bbbbbwbbbmc", "3-15 n: nkbtnlznnxffzjlpfm", "2-5 s: ntsqc", "9-11 l: llllllllblfl", "9-10 d: ddcdfdbcqn", "8-10 g: htgcjhggzmnl", "5-10 v: vvqvvvvvvbvv", "2-6 l: lllfjdc", "3-4 c: gxtmsqdsps", "7-8 f: fffffbbm", "1-6 z: zlndzbf", "9-11 g: ggzgxgggkgggzd", "15-16 n: fflrvmnrvjnrznqgq", "1-3 b: lkbb", "2-3 k: kgkk", "9-12 r: skrrrrrjrmrhr", "10-15 c: ncccmccpvcqfcqgcfcj", "5-13 r: rrrrrrrrrrrrrrrr", "13-14 b: bbbbbbbbbbbbfb", "13-18 l: llvllllllpllllllbl", "4-5 m: mmmmqm", "5-9 g: ggrgcgggggggg", "1-4 q: qqqq", "1-13 l: llllllllllllll", "14-18 g: ggggdgpgggjfgmngggg", "13-16 p: pppphppppppppppv", "1-7 f: ftffffgffff", "8-9 s: tbslsssjsqsssss", "8-9 s: szmzsssss", "7-8 l: lllllllll", "4-6 t: twtjrt", "3-11 z: zjzntzxzlzczdtz", "4-8 c: ccchcclc", "3-11 l: wvldjftflsgzcwllbbm", "1-7 x: xwjhmgxkqqtdx", "8-12 c: cccccccnccckcc", "2-8 f: nghfxvqtfrpwjf", "6-7 b: nbbbrbslsb", "3-4 w: zwnwdzqw", "7-8 p: tpppppnpppppp", "8-9 q: qwqqqjbft", "3-4 z: zztzn", "13-14 f: dfffffmxffffff", "3-14 t: gnpksvbtpzxrsw", "12-16 z: zzzzzzzzzzzfzzzz", "2-4 b: mzbxbk", "5-6 r: rrrrpr", "5-10 z: cfflzmzxdc", "4-5 l: lvtvblll", "6-19 t: tttttdtttttttttttttt", "7-8 g: gjgbtggjggg", "3-5 s: sssssr", "8-9 s: kssvfsssrsrssns", "2-4 p: gpbm", "1-2 g: gbjsl", "3-4 k: tdkn", "8-9 z: zzbglvpbrfml", "5-13 m: mmmmlmkmsmxzmpmmcmm", "16-18 b: lbbwbbbbbbbbbbbbsb", "2-4 s: fgsstnssztbzkzcmp", "3-9 l: hvllztddtj", "4-8 w: wwzcwwwf", "11-12 z: zzzzzzzzzzck", "9-10 q: qmqqqqqqqw", "1-8 x: qpxxxxxrxxxcxvxt", "12-16 l: lllllllllllsllllllll", "4-5 r: rrrbt", "4-6 v: mjvwvvv", "5-7 r: rhrrrrrrr", "1-2 v: vgfvv", "4-15 b: bbblblbvbbbbslbbbcq", "14-15 c: cclcccccccccccc", "8-20 h: gzkhwrhrjdphrrhnjhcm", "5-10 m: mmmmtmkmmmmpmmhm", "2-14 f: kjcwnfhcqnwhbgm", "11-13 m: mzmvmmsmlmmppm", "3-9 g: kglkgdctgxxs", "2-7 s: ssdglzsb", "7-10 j: jtjjjjjjkj", "12-13 q: hxhjqsqsqzqqmjnqks", "18-19 f: ffffffffffffffffffxf", "3-11 v: xhvtvnjcccnsvgzv", "8-9 j: jjjjxjjjrw", "4-8 c: bvxgnmvczbsjvtc", "11-18 g: gggggggggzzgggggggp", "8-13 p: pppppwpdppppppp", "14-15 t: tttttgttttttttj", "14-17 h: hhhdnhhhhhhhhbhhg", "3-5 m: mmmmm", "1-8 n: znnnnnnhn", "2-5 l: qwvchzxlrlrlpldl", "17-18 j: jjjjjjjjjjjjjjjjjmj", "7-18 s: sksssssssstsssshsg", "4-5 k: kbqks", "6-8 q: qqqqklcjm", "8-17 x: tjdsxwtxwxcjtzxfxgkt", "5-8 w: qwxwvwcwvzlvrwwww", "16-18 f: fffffffffffffftfffff", "3-12 z: zzzzzzzzzzzfzzzz", "10-13 m: mmmmqmmmvmmmx", "4-7 z: zkjzvpf", "11-13 p: pzqpppppppgpt", "11-12 c: cccccwfccccccz", "3-4 s: ssxsss", "8-9 j: bsjjjjjpxjjjj", "2-7 x: cxkbqkf", "7-18 x: vmrsdvxxpbjrxbnxqxxg", "8-11 d: nwzdcqvddfd", "7-11 h: hhhhhhlhbhhh", "9-10 f: fhlmjqfzfq", "13-15 p: jcfprqlvrnfnfnp", "2-3 b: gblb", "5-7 s: jssssqz", "1-18 c: ccccccccccccccccczc", "10-15 x: xxxxxxxxxwxxxxxg", "6-7 w: jswwwwdcw", "4-10 q: bqtxmcgxnjnkvq", "1-2 c: ccccc", "10-12 h: hhhlhhhhjkhsh", "3-4 w: hwgwxd", "17-19 j: jjjjjjjjjjjjjjjjdjpj", "1-4 d: dddt", "7-8 z: zzzzzzlhz", "13-16 z: zzzzzdzzzzzzzzzpzzz", "4-10 d: dgdzdddddddd", "4-7 l: llclxltlpqh", "1-4 x: hxxxx", "5-7 n: vnnnnnndxn", "10-11 n: nnnnnnnnngg", "5-12 k: bkcdkpjrpkkv", "6-8 j: lsjhjjqjcx", "7-10 t: ttttfttttt", "17-19 n: nnwnnnnnnnnnnnjndznf", "1-4 v: vvvv", "14-18 x: xxxxxxxxxxxxxnxxxx", "3-5 x: kxjjx", "3-8 k: kkrkkkkskkkkkkk", "8-11 h: hhhhhhhhhhlhhnjh", "4-5 x: nxxxnz", "7-10 z: zzzzzzzbzq", "7-13 b: dvbsbbbbbbbkcbb", "3-5 k: drkrkpnhkpjhkk", "8-9 w: wrwwwwwwf", "3-4 x: kxxtwx", "5-17 n: nnbnnnlnnnnnnqnnn", "11-14 k: kkkkqkkbkklkkkkkkkkk", "4-7 q: qqjjqqqqqqq", "3-4 k: gkkkxlx", "11-17 s: ssssqssssjrsmgssstgs", "6-17 n: dntjvnhjgrbtcnnmkdc", "1-5 l: hrqqlqpdlmbjlllmfjqz", "1-5 k: kkkvk", "9-15 z: zmzzzjzxmzzzbzv", "1-2 s: rsssxzss", "1-4 f: fdfc", "1-7 t: ntttttttttt", "10-12 t: mtttzttwtttkstjtztt", "9-15 q: qlqqqbqqqqqqqqq", "4-5 f: jwfff", "5-6 p: ppwppvppp", "12-14 p: ppppppppppplppp", "2-8 x: wxbngjrxzx", "1-2 h: hlhlg", "9-10 b: bbbbbdbbbqb", "6-15 w: wwwwwwwcwwwwwwww", "2-7 d: sgcfddnqmjthdphl", "7-9 m: zqrwxkmjr", "5-7 f: qklfrzfgffff", "14-15 n: lnnnnnnnnnnnnnnn", "2-11 q: gqqlcqjlqrsbqkqqq", "7-8 x: xxxxxnlx", "2-9 v: xvvqbvfkwd", "10-12 z: rmvxznxnszkzdb", "2-3 q: qkqq", "2-6 n: nnqqgv", "4-6 d: dddddc", "8-9 z: zzzzwzjzz", "1-14 q: wxqnqqqqqqtqqq", "1-5 g: grgtggnh", "4-6 x: mbtxxxxxxtm", "3-7 w: wwtwwww", "4-6 h: phchhbxf", "4-6 n: npznhtxf", "14-20 v: vkpjvvbrvvvfvzvvvcxv", "17-18 m: rmccmmmmvmkmnmqtmz", "4-9 n: nnsnxnfbjnjnnnkn", "8-10 c: ccqclccvcccc", "1-12 b: blbhbbbbbbbbbbgbbbb", "4-8 v: vvvbvvvgv", "4-6 m: mdnmmmgrsqjjbctjvhm", "6-9 r: rlrrgrrrhr", "4-6 q: qqqjnq", "8-9 g: spqxllrngwkjgpzpg", "6-9 m: zbsggmvzsmpcm", "3-9 s: xssmzstbsrfz", "4-11 c: cxcrrccccrcncc", "3-4 p: ppqb", "5-8 f: vcfflfflmf", "9-13 b: bbbpwbjbkbhbbktz", "4-9 p: ppppppmpps", "7-17 s: ssssksrvssnsbsssrxsm", "10-12 m: mmmmmmmmmmmsmgmm", "6-13 x: xwxxxxxxxxxxm", "9-10 t: rrthttjtttwlvpttgttt", "6-10 z: vzklxxzvwgzt", "2-4 v: vvvk", "5-8 h: twhghhhw", "7-8 n: nnwnnknrn", "2-4 m: mmmmm", "3-7 r: srxrrmrwrrhrg", "5-6 x: xxxxxh", "5-6 x: xxxxxtx", "5-13 d: ddddddddddddndddd", "15-16 c: drfrpmbhcncvmxnk", "14-15 r: rrrrrrrrrrrrrrk", "4-6 z: qmlsgz", "9-10 x: xxxpnxrxxl", "3-6 h: hhhhwfhh", "3-8 b: jvpscbzbvb", "9-12 j: jjjjjjjjfjjj", "1-2 n: hwnn", "3-9 l: lpgmzxcwlpsp", "2-7 k: zkbnlwlpk", "2-12 t: tttttttttttttt", "5-14 h: rhjchxhlfjhxfhhb", "1-4 p: pbstdbpctfdzxzh", "9-14 k: swkkkkckqkkrqlkkrtk", "5-6 v: vcvkxvfvrmvvv", "14-17 n: nnnnnnnnnnnnnnnns", "9-13 d: dbdjdhdhrddgmk", "5-6 c: cvzcclcccdf", "16-18 x: xxxxxxxxxxxxxxxxxxx", "15-16 v: vvvvvvvvvvvvvvfv", "3-6 g: jggwkcdpmmttl", "18-19 g: gggslcgggtggggggxgxd", "7-10 r: rrrvrrjrrrrrr", "7-8 f: xzmwmgfkh", "2-4 g: gcgvg", "5-7 k: qkknzkfncgkckkj", "8-10 q: qxgvffbqgq", "5-7 d: slfqbddnrvj", "8-11 k: xtfkkwnccck", "3-4 s: jsrs", "3-6 m: mmdmkmwmmmnd", "6-7 q: gxbthqc", "6-7 v: vvvvvqv", "7-14 n: nxnqnnqnqnnnnnn", "8-12 d: chkdcslxddddd", "8-11 g: cgwlgszgfnk", "12-13 b: bbbbbbbbbbbjc", "7-9 w: wwwwtwwqdw", "14-15 q: qqqqqqqqqqqqqlq", "8-11 q: rhmqdzslbgqwq", "4-5 k: khkxrqxwb", "2-6 l: lskblllkqxdllmhl", "2-9 s: xwxncpjgch", "8-14 x: vxxxxxxhcxxxdxxm", "3-11 g: gggwgggggggggg", "9-11 b: fbbfdmbbbbjbstbb", "5-13 z: zzzzxnzzzzzzzgz", "1-10 b: bnsbgsnrbb", "3-6 w: zxtfmwndwnwkj", "2-4 s: smss", "4-5 q: qjqqz", "12-15 b: kbbbbbbbxbbhbbj", "3-4 d: dhkd", "5-6 k: pkbkkp", "2-4 p: wppkz", "2-6 d: dnddgd", "7-10 j: jdwrhhjszjbkmfphj", "1-3 b: vkcbb", "7-8 f: ffffffdf", "11-13 t: ttttttttttttl", "14-18 x: xvxxfxxxxrxxxgxxxrx", "8-10 k: gtkbkksnkskkrkkk", "2-4 h: hnhh", "10-13 m: vmmwpmlmnckmcmm", "1-2 z: zzzsz", "4-5 p: pppbf", "2-4 q: pwdbsxlrqmhhtccl", "9-11 f: fffhffffvffvfq", "8-9 x: xxrxxxxsx", "8-14 z: zzzzzzzzzzmzzzz", "9-11 j: jjjjqjjpjjwj", "3-4 s: sskss", "8-12 s: tlcssmclnvgstg", "11-12 v: vvdnvmvsvvkx", "4-5 c: ccccbcc", "1-2 d: ddthwdk", "10-13 n: nnnnfnnnnpncnm", "7-8 z: zzzzvzbz", "2-3 n: nnsqnrnnnnnltn", "4-5 q: qqqmq", "6-9 s: ssnsssssksc", "9-11 r: rrrfrrrrhrrr", "3-4 d: tzdd", "3-6 c: cccccmcc", "7-8 q: qqqqtmsqqqqq", "17-18 z: zwkzbhqnhznzlkqxnz", "4-7 m: hfvdmmnszdmb", "14-17 z: zzzzzzzzzzzzzzzzjzz", "12-14 k: kkkkqkfkkkkjkz", "1-3 z: zzdzh", "2-7 v: vvvvnvr", "14-16 j: jjjjjjmjnjxjjtjjjwj", "15-18 h: hhhhwhhqhhtfhhhhhzhh", "1-2 z: dzznmxzt", "5-6 c: cccpkc", "6-10 z: trwqgzmwtvbgnvjkxz", "3-4 w: twwjwg", "6-10 w: nwwcxwjschxpjkrqwvw", "9-10 z: kzzfzzzzzhlzzg", "6-7 r: rrzhqnnrrrhk", "9-11 k: kkklkzkgkrkj", "11-16 d: ddddddsrdddpbdldrb", "6-9 v: njfrfxbqvv", "3-4 j: jjjd", "3-4 q: qgqq", "4-15 h: hhhtthhhhhhhhhhhh", "3-11 b: bbbcnzglwcbqxgwvbc", "2-3 b: nbhbrkkzbs", "4-5 p: ppppk", "2-5 q: jqkzqrzqbtkcqgb", "6-7 s: sssssqm", "1-5 r: rrrrr", "3-4 w: wwwgt", "2-8 x: xxxxxxqx", "9-10 c: ccfccccwcc", "2-10 r: crmkxbcrrkr", "7-16 c: cmmfkhclcwqjcqsmccn", "7-14 p: ppgppppppppppqppppp", "1-3 s: sshs", "1-3 d: lfdd", "5-14 n: fkxsnvxclfnklbqrknvd", "15-17 j: jwjjjjjjjzjjjjjjpj", "4-7 l: lllljnlt", "5-8 c: pczkvcsqpfzcw", "3-14 q: xkqqsvcqdqqqjscfd", "7-11 m: rmhmmmmmmmjmm", "10-13 x: xxxxxxxxxhxxxxx", "1-4 m: mmmmm", "1-4 r: dmrrl", "10-11 s: sssssslssgg", "9-10 g: rtksgmrpbl", "4-10 t: wtfttttttbmntsth", "8-18 k: vwstrvjbjttzbrtghwk", "9-11 s: ssdslssssss", "10-13 s: pssssssfcnjcs", "2-17 l: wpltglllsslllwlslrpc", "13-15 g: gglggglgggvgwgzgggg", "4-6 v: qqvvvvvlbzdv", "4-5 j: jjqdvt", "2-9 n: nnnnfvxnpvfjnnbg", "2-9 c: pgctwtlccvl", "4-6 n: nnnqncnnn", "2-5 l: lzllllnll", "6-10 k: zjkkvkkzwkk", "3-4 h: hhhkh", "3-15 k: kkkgkkkxkkknkkv", "4-7 k: skkknxdf", "4-8 h: hhhhzhkdj", "9-11 j: jjjjjjjjjjsk", "3-6 s: qswngs", "3-7 v: vvcvvvvvv", "11-12 s: ggcxrkcsntpsf", "3-4 v: hvvv", "15-16 t: tttfttftttfttttkttt", "8-13 b: bbbbbbqgbrbcbqbb", "9-12 s: cstnslsssjsv", "3-13 j: kwkjmmqtpcjcjhdllwjj", "2-6 r: rrrrrn", "10-11 s: bsssssstsssss", "1-6 f: cgggvn", "3-10 l: hblknspmlx", "2-3 h: hthhhs", "3-5 n: nnbwn", "1-3 z: nzgzzz", "16-19 p: pppppppppqppppppppqp", "5-11 d: ddddntddgdd", "6-7 s: ssssswk", "1-7 r: lrrkrqrwbkk", "2-9 z: cwzthgjzzgzzhzz", "3-4 c: cxxt", "5-13 c: jczpcmcccccccjpc", "7-8 l: llllllgf", "3-11 q: rqkxqckgqqqqb", "2-14 r: mhlbmsrsgrwrtrbrpt", "2-10 v: tvnxllwvhdkcjsvxlztx", "2-3 q: nwqqwfqlq", "16-18 k: bdkkktkkkkkkkkkqjq", "8-17 k: pkjckwmzqkkvqqshks", "6-7 f: fffffbff", "3-7 p: pppphpp", "6-8 w: wrwcwwjswnwwwp", "3-4 h: hhfh", "2-5 h: hhhrsc", "3-19 b: txxmgxhnbqhtjhjfvdbb", "14-20 w: wwwwwwpwqnwwkwwwwwwn", "5-6 z: zzzzvz", "2-5 x: rxxllbfhnvxx", "15-17 f: fwtfjjfffwfffffph", "1-6 m: msmmmwmsmmmm", "6-11 f: mdtdmfhpscfmrm", "1-16 l: zmlxxnlzzbhfscll", "14-15 x: xxxxxxsxxxxxxxt", "7-10 q: qqqbpqqqhdq", "5-8 v: vvbrtvwvvvlvvsv", "6-7 x: xwfzsjxxxxzpxvsx", "7-10 l: lllllldmll", "10-11 c: cctccccccdw", "3-6 g: ggppjgg", "16-18 c: cfcmcczcvwccccgccccc", "7-9 v: vxdvzvvvchbvvvq", "11-18 t: btnttrttqbtgtxttstrc", "8-10 p: hppppbptppsp", "9-10 g: gtsgglgggtgg", "13-20 f: ffpsfffffffffffffffg", "12-19 m: rmpmmdvzmtmmbfmtxwm", "1-7 g: xgggggxgg", "1-8 w: wsnkwcww", "2-3 z: zmzgxp", "9-11 w: wwwnwwwwwkww", "5-6 w: wwwwrw", "4-5 s: prxsnscsm", "5-6 n: nnnndn", "6-14 g: gfqgggwggjlswdg", "1-3 t: tvtqmtth", "9-10 v: vvvvvvvvvtvvv", "3-4 d: dbvfdw", "10-11 x: nxhxxnxxxvx", "19-20 c: rcchbchcsjghmnjbgpcc", "7-8 n: mxtnnkxcnhnnjknptn", "3-8 k: knjxpwkkzkmzkwfknvzg", "9-10 z: zzzzlznzztzzz", "1-2 k: pxkk", "2-3 k: spkgwkpmns", "12-13 k: kkhkkkkvkkkkzk", "10-13 g: zgwsbgkgjgdgtsm", "4-6 k: kkkwkk", "3-12 w: gbxksbkdvjpwrjplhwvf", "1-6 t: gtttsckj", "14-15 w: wwwwwwwwwwwwwzl", "2-5 b: zbblgb", "11-12 m: mtmmmmmmmmsvb", "10-11 t: tttntttttmtttt", "6-7 v: vvvvvvqv", "8-16 b: bbbbgbbrxbbbbrlgb", "3-5 f: fvfpfghnvkdtpfjrf", "10-13 t: rtttjtsfttttntwt", "10-12 c: ccvcccrczcccqccnj", "6-13 f: fffffkfffffffff", "9-17 k: kkkkkkkklkkkkkkkr", "6-9 k: kkkkkkkkvkkkkkkkm", "7-8 g: gnggmggmgg", "7-8 l: plllgllsll", "6-12 s: sssksjxssssssfw", "7-8 d: fdddqddjddfdpmdlf", "6-11 g: gqggrggvgbgg", "2-3 s: sstsqssssv", "15-16 b: sbfbbbbbbbbnbbrmbbb", "13-14 z: tbptvnfzxwlkgz", "3-5 r: rddtrrdrt", "10-15 p: pspppfppwppppwpp", "2-4 j: bsjjjgkvtw", "3-5 m: pmmmh", "6-7 k: nkdkhwsq", "3-13 r: rfrrfrrrrrrzr", "17-19 r: rrrrrrrrrrrrrdhrrrfr", "8-10 n: nnnnnbnxhnn", "5-6 k: kkkwdwkd", "14-15 s: sdsgspstttvfsks", "1-7 t: tttttttt", "6-7 r: cgrrmrrrrgrbcnhfmvn", "5-18 v: vkxvvsvwhvvvrvvvmrr", "3-4 m: xsmkm", "10-12 q: qqqqqqqqqqqcqqq", "1-6 h: jwhhchh", "6-10 g: ggggmdgtgg", "5-6 v: jsxvwvvsvcrzlnvqwmvq", "2-6 k: kkkkkck", "3-6 w: nckwlw", "4-17 k: wqjnlsmcskndlwpxb", "5-7 f: qrrlbfrrx", "4-9 z: czcrzzzgl", "2-3 t: wttt", "1-8 b: vxbwwxrbbqsjb", "11-12 g: dxgggvbwhnrcg", "3-6 j: jjjjjjjj", "1-10 v: vvvgvvrvvjvvdvv", "2-13 k: jkgfcnqkhdkdjk", "5-7 q: kqqqhrqq", "1-4 p: npqpqpmh", "6-7 x: hmxrnxh", "4-15 n: npncnnnznnkqdnqnn", "2-3 d: dhzdd", "6-10 n: nnnnntnnnnnnn", "4-9 l: lllclllhll", "14-16 n: nnnnnnnnnnnnnvnnn", "6-13 d: sckddddfxdddvdddd", "1-5 f: hfffff", "7-14 f: fffnnfpfffjgqqdf", "9-13 s: msssrsssnsssssss", "5-8 j: bjvdgjkj", "3-5 q: msqqnnb", "11-14 t: ttqtttttttttttttthtt", "13-14 x: xrxxxvxxxxxxxxxxxbbx", "19-20 h: hhhhhhhhhhhhhhhhhhht", "2-4 q: wrlqgqlh", "9-14 z: zznzzzzcmvthzd", "2-6 m: qtlznmbbsznljmhd", "3-5 m: mmmmcl", "2-6 s: ssnbgssnsskhssnrz", "4-5 r: rrrlr", "1-4 b: gbbb", "12-13 v: xvvvvvvvvvvkmv", "7-15 b: bbbbblgbbbbbbbbbbbbb", "3-4 n: ngpv", "3-12 b: bbbbbbbbbbbhrbbbbbbb", "19-20 s: sssssssssssssssssssf", "6-12 c: jcccbckcqxcss", "2-10 r: frsbkmqqpsqdpzrvpr", "3-12 p: ppmkphqgdfphhcpd", "2-4 n: ncnn", "7-14 j: rjjjjjjjjmjjjhjjj", "6-13 p: pppfvppppppppp", "7-8 h: xhbshhhtmxvh", "6-9 f: fffffrfffffffff", "1-6 d: dddddkddd", "3-14 p: pprppppppppppppppp", "5-6 s: sssssvs", "4-13 z: zzzgzzzzjzzzzx", "14-16 f: fffffffvfffffnfff", "4-7 h: xhskgbhbbbq", "5-7 f: fvffffj", "8-9 g: hxfgghdgg", "15-17 w: pxwzjdwcwwmmwnwxz", "2-6 q: pmqqqqqq", "11-17 d: cndddtdnvlnkkrfzdcz", "7-8 w: swwwwwgww", "19-20 c: ckhccpjcjcxcsccvdngh", "5-10 d: ddddddddddd", "4-5 r: rrrrrr", "2-4 c: gcccql", "5-6 t: qbmqfxcsr", "2-6 f: qpfffzff", "3-5 p: lpbwph", "3-6 t: ttrtttt", "2-5 s: wslkz", "3-4 x: cgxt", "6-20 z: hdxggqznjfwjnlvmwsmz", "1-4 l: tkzlgkl", "5-18 s: ssssrssssssssssssss", "8-13 p: wpkpcpppgwplpppp", "6-7 g: ggzxpvpdfggjrgkqdjb", "3-9 b: pqfnczzfb", "11-12 l: llllllllllxl", "17-18 m: gzjvfgvcdxmxxftlzmb", "9-12 v: wvbvvfvrvvxzvsqvfwrv", "13-14 j: jrjjjjjjjjjjjs", "2-20 r: vrvcqskfwkqrdhvtlshr", "1-3 v: wvvvr", "2-3 s: tqlhxbs", "2-19 j: jjjjjjjjjjjjjjjjjjbj", "2-8 h: zphrlkvhczdgrhrm", "9-14 d: ddddbdddddddxfdd", "3-4 c: cctc", "5-6 x: xxxxxvjx", "10-11 s: mvsxzpmssqx", "1-18 m: wmmmmmmmmmmmmmmmmmm", "2-8 f: vffkrwff", "11-14 k: lgknbvvkkfkcqq", "2-4 n: wcnnv", "4-6 w: wwbwnwwb", "2-5 d: jlddr", "2-7 h: hhqhfhvghzgtbfjhhshn", "2-4 j: fjjjbj", "1-10 w: wwwlwbwwsswdww", "9-10 m: mmmmmmtmmmcmc", "13-18 l: lbtllllllzllllllbdl", "5-6 k: bkckkkkkkkckkkkzb", "14-17 v: vvvvvvvvvvvvvvvvvvvv", "9-13 d: dmdpddddqtddddddvd", "10-12 k: kkkgkrkrkkktxkk", "7-8 w: hvwtwwwwwww", "6-13 d: fdpgbqbpmdmkdxkbl", "2-3 m: ctmmlm", "2-5 j: lcjjj", "8-13 w: wwwwwwwwwwwnwws", "12-13 l: lwlmlrlllcpkz", "2-4 g: xgtgg", "5-6 c: cccccrc", "3-10 f: mffnffvjxtfdjd", "1-9 k: nkkdkkkkkkk", "7-13 t: wpmtclstqwtpctgcql", "3-4 r: rfrr", "6-10 b: vkbbbwzbwbbjnsrwb", "4-7 s: qxlmqssqcbhstknvjzss", "3-4 m: mmfmnmmxvm", "1-2 b: cbcjhzllb", "17-19 z: zzzzzzzzzzzkzzgzzzsz", "2-4 d: ddkml", "6-10 m: nmmmmcwmmmlsm", "4-9 b: lhlbxslpxfbzzn", "5-13 n: njvdnxghhkxlsrm", "3-4 p: pppq", "1-5 s: sgvrgss", "1-13 h: hhhhhhhhhhhhmfhh", "9-11 w: cwwswwwnwwbwwh", "6-7 j: jhdjjjzj", "18-19 g: ggggggggggnggggggzgg", "13-14 k: kwkkkxnpkkwkmf", "5-6 f: ffffff", "18-20 c: cccccccccccccccccfcc", "2-5 d: ddhbdbl", "10-14 g: ggwgfggjggggfhlg", "11-13 q: qqsxqfqqqqqcqwqzq", "16-19 q: fqsqtqqqqrcjqqxxwqf", "6-7 w: wwwwwwx", "6-7 h: hhhhhhp", "1-8 w: twkwwbgw", "7-15 g: ggggggkggggggggdg", "3-5 j: jjjjtjj", "1-5 p: phdppmwnfxpjpbgpppbd", "6-10 b: bbbclbbbbhbbbbb", "9-10 n: nnnnnnnnnp", "5-6 n: tktfwnqcqrv", "3-9 l: lhlxflczslf", "3-4 f: fffnvthfj", "10-11 j: gjjjjjjjjjbtj", "3-8 x: dxxcrsxxbbqrfx", "2-3 h: hfhhh", "2-16 c: wcfpjtbpgbbbnnpzchn", "7-11 x: xxrxcxxvxxfjxsvpxm", "9-10 f: fffsfffsfpfff", "2-4 f: hvcf", "9-11 b: bbbbbbbbjbp", "8-14 n: qqlxkxnnhvbdzn", "7-10 v: vvvvvvcvvgxvvvvqvp", "2-4 c: ncvw", "3-4 r: rprg", "6-12 p: tpmdppppgpppgp", "6-7 t: tztrtwt", "10-11 f: qfwfcwfngds", "4-13 q: zsqqqqqtdkqgnrtqqqr", "5-6 p: phpppjpprpb", "11-12 c: cjcccccccpccp", "8-10 g: xggpbmgkfg", "9-10 l: gllllllllzl", "2-5 z: jzzjqqvp", "3-4 c: sccc", "6-13 x: xzhxgzxfxxsvxh", "7-8 n: nnnnnnxn", "18-19 t: tttttfttttrttttttttt", "10-11 l: llllllfllrl", "3-7 r: tllmrjr", "3-4 q: vqntw", "1-3 w: wjwxr", "3-12 z: zwqzjfmxgtxmqvzgqnsw", "6-7 m: wmmsmhmmc", "6-10 l: lllllrllljll", "6-8 n: nnnnnnnp", "5-8 h: shqhhfhghhqhdw", "19-20 l: lnrrrbztcfsmcjkgdzlj", "3-8 q: pxqgbqsg", "1-3 q: fqrqqqqqqqqbq", "2-7 k: skcsgnk", "4-9 v: vvvvvxvvsvvvvvzvpzq", "3-16 c: ccccccccccccccccc", "10-12 c: chdpcccccccwcdvhtmc", "6-8 s: sxmssfwdss", "1-2 b: hrbsckfth", "2-4 s: sngs", "6-8 b: bbbgdvbb", "13-14 b: bphfdzgmhhwmbhb", "3-4 h: hhhjh", "2-3 p: cppp", "13-14 r: rrrrrrrrrrrrxr", "6-8 r: drbzrhdr", "4-16 j: cmtlnsprjjfhjgmj", "1-10 m: dfsmnmmdmm", "5-11 w: gtxwxmzwwtwrmwwwgwcd", "4-5 c: cccfcc", "3-9 p: pbpppdfpfpp", "1-3 m: nmmx", "16-20 f: ffffffffffffffflffff", "2-13 v: pvmmfzmjvvqvv", "8-9 z: wrzbzzzdz", "10-11 n: nntnnvnnncn", "14-16 s: sssssssjjssssxss", "1-13 p: kppppppppppppp", "14-15 w: wwwwwwwwwwwwwmk", "3-6 t: ttkdtp", "6-7 d: dddddpdd", "5-15 r: lrpsrrrrrzrrcxng", "10-11 f: ffffffffftff", "6-10 l: lllllwllflwlll", "2-8 w: rjdvtwgw", "10-15 c: cchcccccccccccjc", "6-17 q: gjlcqjvhsbjmcgxvv", "5-11 s: ssssllsssssmh", "14-16 s: sssssssssssssssfx", "6-7 l: lnjqdlllltlvkwnvlxs", "10-11 r: lttktskrkcx", "16-17 w: hfgdbpwkqlwfvqtwf", "2-3 k: tnkp", "13-20 w: wxrcpvvxfkxnzfvgvfkn", "14-15 f: tffffffffffffrf", "7-8 q: gqqxhtfqqqqpqm", "5-9 r: dkklrrrnh", "2-15 w: wlwwwlgmhwwgwwkwz", "4-5 h: hhhthh", "9-11 x: mxxxxxxxxqqx", "3-6 f: lzfxfmjfbgrl", "8-9 s: ssstssszss", "11-13 t: lrkbvdhvjzklltk", "6-7 x: xxdgxxwgx", "2-4 n: pnnn", "8-10 d: dnhlvbddxdjgvn", "4-7 q: qqqfqqqq", "2-4 t: ljztcptpmz", "2-16 f: fqfffffffffffffff", "12-13 t: tttttttttttxct", "9-12 s: sssstssssssb", "3-11 g: nsggzgxljjlfxfl", "1-7 l: llnqshlsjl", "8-10 d: jzddhkjdwpddddddcwj", "2-5 v: rvznj", "6-8 l: lllllzljl", "1-2 v: ddvmtr", "13-18 s: bspzsssrtssdvmwqss", "5-7 s: ssstgss", "4-8 j: kqfknvjj", "4-5 x: xmxxx", "9-10 z: zzkzzzzzzpzzzzzz", "16-18 t: dttsttttttttttnttwt", "13-17 d: dbvdddddddddpfzdd", "4-5 m: mmmmnms", "2-3 f: dlzzdhh", "3-5 t: nstxrvjkjq", "2-6 d: ddfxwvd", "1-5 l: lkppsbblc", "8-11 c: ccskccccbhclc", "2-3 x: bdhx", "2-4 v: hxfhfs", "8-10 f: fgffsmfrzfqlfffmnpr", "1-4 m: qjpm", "3-4 f: fbcff", "2-5 t: ttglwxxghtznp", "2-12 l: lrllllllllllll", "2-8 m: rgmnzxxmwmbdldhbpnsp", "2-8 j: jjjjjjjjjqjjj"};
    }
}
