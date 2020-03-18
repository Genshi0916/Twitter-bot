 using CoreTweet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Twitter_bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var rand = new Random();//出力する文字のランダム

            try
            {
                var session = OAuth.Authorize("zsXtwOOlzPr9yr0a0lJF7cQfN", "3Xt6KSoEOOgE7s3wjmyuSmEfwUon0nDOjICZkZs10bSr5bbMsJ");//"api_key", "api_secret"が入る

                Process.Start(session.AuthorizeUri.AbsoluteUri);//認証ブラウザを開く&ピンコードコピー

                Console.Write("PINCODEは？");
                var pincode = Console.ReadLine();//ピンコード入力

                var token = OAuth.GetTokens(session, pincode);//トークン取得
                Console.WriteLine(token);


                while (true)
                {
                    string[] coment = { " @spea55_main "," @0828_Syuu "," @kodamanbou0424 "," @hanakosaber "," @mueru0 "," @quarts_x77 "," @Lachryma_CRASH "," @Dr_purin410 "," @Imai_kousen "," @shade4827 ",
                                          " @saberhanako "," @takahashi_1919 "," @Makigechan "," @ume_mikan03 "," @obgedsbzoztsn "," @Daiki_purin_M23 "," @Xx_RR13LV_xX "," @spea0626 ‏"," @kyouju_Touma ‏",
                                          " @r2y3q "," @genshi0916 "};//ツイート内容


                    string chose = coment[rand.Next(coment.Length)];//内容を選ぶ
                    DateTime dt = DateTime.Now;
                    
                    Console.WriteLine("Tweet" + dt.ToString() + chose +"進捗どうですか");

                    try
                    {
                        token.Statuses.Update(status => dt.ToString() + chose + "進捗どうですか");
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Error:" + ex.Message);
                    }

                    Thread.Sleep(1000 * 60 * 60);

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadKey();
        }
    }}
