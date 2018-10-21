using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ParseJsonDraft
{
    public class AutoTradeLinesJson
    {
        public Dictionary<string, AutoTradeLinesDetails> AutoTradeLines { get; set; }

    }

    public class AutoTradeLinesDetails
    {
        public MatchResults MatchResults { get; set; }
    }

    public partial class MatchResults
    {
        public string Match { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string json = @"
        {
           'AutoTradeLines':

                    {
                       'AutoTradeLine1':
                            {
                               'Joint':'NUH',
                               'Poka':'u',
                               'MonthlyPayment':'$270.00',
                               'MatchResults':
                                {
                                    'Match': 'No'
                                }
                            },
                       'AutoTradeLine2':
                            {
                               'Joint':'YES',
                               'Poka':'u',
                               'MonthlyPayment':'$270.00',
                               'MatchResults':
                                {
                                    'Match': 'No'
                                }
                            },
                        'AutoTradeLine3':
                            {
                               'Joint':'YES',
                               'Poka':'u',
                               'MonthlyPayment':'$270.00',
                               'MatchResults':
                                {
                                    'Match': 'Yes'
                                }
                            }
                    }

        }";


            AutoTradeLinesJson tradelines = JsonConvert.DeserializeObject<AutoTradeLinesJson>(json);


            //Check if Json responce contains "Match": "Yes"
            foreach(var x in tradelines.AutoTradeLines.Values)
            {
                if (x.MatchResults.Match.ToLower() == "yes")
                {
                    Console.WriteLine("Test Failed: Result contains Match equal Yes");
                    Console.ReadLine();
                }
            }
        }
    }
}
