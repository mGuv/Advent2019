using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Problems.Day14
{
    public class Problem : IProblem
    {
        public int Day => 14;
        public string Title => "Fuel Finder";
        public string Part1Title { get; }
        public string Part2Title { get; }
        public Task RunPart1Async(CancellationToken cancellationToken)
        {

            string input =
                "3 NPNGZ, 3 TBFQ, 1 RZBF => 2 LQNR;1 GWZRW => 9 CHNX;1 DBVD, 10 VCHK, 12 WNHV, 1 FMKT, 1 DKFT, 1 BTLR, 12 VHKXD => 4 ZMWC;2 RZBF, 13 JSBVZ => 3 JLVRS;15 BZNB, 1 JSBVZ => 5 ZTCM;28 GMSF, 18 LTGJ => 9 BTLR;1 RZDM, 3 BNJD, 1 FLXL => 1 FDBX;2 BZNB, 1 JLVRS => 2 GMSF;1 FDBX, 2 ZSQR, 1 XMBS, 2 FMKT, 1 BNJD, 12 TRXVN => 7 CRNMW;1 PCHWB, 6 LXJPK, 2 ZSQR => 5 DBVD;5 LMTM, 9 RZBF => 7 TBFQ;2 KVWJG => 2 RZBF;1 LBFXF, 17 NRBGS => 6 JSBVZ;1 VQTFW => 5 LMTM;20 DBVD => 2 SRFQ;3 XSVZ, 7 JSBVZ, 5 NPNGZ => 2 VWMQZ;1 ZQDN, 1 RZBF, 1 NDNKB => 9 FMKT;7 BZVGH, 9 NDNKB => 6 LTGJ;3 VWMQZ, 1 XSVZ, 4 GKDGX => 1 TRXVN;3 VXFJM, 14 FMKT => 6 NFTJ;21 WXWHD => 1 VCHK;1 TJZVQ => 6 NDNKB;6 NFTJ => 3 RZDM;1 VHKXD, 1 TBPWN, 1 FDBX, 2 XMBS, 2 WJTRC, 20 BTLR => 8 VSBV;19 XSVZ, 7 LJQG, 10 ZTCM => 1 GKDGX;3 NPNGZ, 2 RZBF, 8 GWZRW => 1 QVDFQ;1 TBFQ => 7 VHKXD;3 LTGJ, 1 ZXWB, 2 MNPBV => 2 BNJD;9 LQNR, 2 QVDFQ, 10 GMSF => 4 XSVZ;13 VHKXD, 17 CHNX, 1 NDNKB => 8 VXFJM;122 ORE => 4 LBFXF;18 NPNGZ => 5 LXJPK;1 TJZVQ, 1 FXGH => 5 GWZRW;9 BZNB, 4 JLVRS => 3 KDCG;1 SNLNK => 8 WNHV;4 VHKXD => 4 DGFN;1 RZDM => 6 SNLNK;3 CHNX, 8 LTGJ => 4 TBPWN;2 DGFN, 1 NFTJ => 2 RNSXD;1 FXGH, 1 BDCLW => 2 LJQG;3 DGCMV, 2 BZVGH, 7 RZBF => 8 MNPBV;14 WXWHD => 2 XMBS;1 BZVGH => 8 FLXL;8 VXFJM, 1 NFTJ => 2 WXWHD;2 LXJPK => 9 ZSQR;5 NRBGS, 1 LBFXF => 9 FXGH;4 NRBGS, 27 CHNX => 9 PCHWB;3 LBFXF => 4 TJZVQ;185 ORE => 2 VQTFW;1 RTVFM, 1 TBPWN => 6 DGCMV;10 NRBGS => 3 ZQDN;5 JSBVZ, 8 FXGH, 1 TJZVQ => 7 NPNGZ;1 PCHWB, 6 LXJPK, 5 LTGJ => 2 ZXWB;1 NPNGZ, 24 FMKT => 6 WJTRC;4 KDCG, 33 BZNB => 3 KGNH;2 KGNH, 4 ZTCM, 15 CHNX => 6 BDCLW;10 LXJPK, 18 TJZVQ, 1 FXGH => 7 BZVGH;27 DBVD, 2 CRNMW, 8 ZTCM, 8 RNSXD, 14 VSBV, 6 ZMWC, 37 TBPWN, 53 SRFQ => 1 FUEL;19 FXGH, 4 TJZVQ => 3 BZNB;17 QVDFQ, 26 KDCG, 7 CHNX => 3 RTVFM;111 ORE => 6 KVWJG;3 ZTCM => 6 DKFT;124 ORE => 6 NRBGS";
            //string input =
              //  "2 VPVL, 7 FWMGM, 2 CXFTF, 11 MNCFX => 1 STKFG;17 NVRVD, 3 JNWZP => 8 VPVL;53 STKFG, 6 MNCFX, 46 VJHF, 81 HVMC, 68 CXFTF, 25 GNMV => 1 FUEL;22 VJHF, 37 MNCFX => 5 FWMGM;139 ORE => 4 NVRVD;144 ORE => 7 JNWZP;5 MNCFX, 7 RFSQX, 2 FWMGM, 2 VPVL, 19 CXFTF => 3 HVMC;5 VJHF, 7 MNCFX, 9 VPVL, 37 CXFTF => 6 GNMV;145 ORE => 6 MNCFX;1 NVRVD => 8 CXFTF;1 VJHF, 6 MNCFX => 4 RFSQX;176 ORE => 6 VJHF";
         //   string input =
           //     "157 ORE => 5 NZVS;165 ORE => 6 DCFZ;44 XJWVT, 5 KHKGT, 1 QDVJ, 29 NZVS, 9 GPVTF, 48 HKGWZ => 1 FUEL;12 HKGWZ, 1 GPVTF, 8 PSHF => 9 QDVJ;179 ORE => 7 PSHF;177 ORE => 5 HKGWZ;7 DCFZ, 7 PSHF => 2 XJWVT;165 ORE => 2 GPVTF;3 DCFZ, 7 NZVS, 5 HKGWZ, 10 PSHF => 8 KHKGT";
            //string input =
                //"171 ORE => 8 CNZTR;7 ZLQW, 3 BMBT, 9 XCVML, 26 XMNCP, 1 WPTQ, 2 MZWV, 1 RJRHP => 4 PLWSL;114 ORE => 4 BHXH;14 VRPVC => 6 BMBT;6 BHXH, 18 KTJDG, 12 WPTQ, 7 PLWSL, 31 FHTLT, 37 ZDVW => 1 FUEL;6 WPTQ, 2 BMBT, 8 ZLQW, 18 KTJDG, 1 XMNCP, 6 MZWV, 1 RJRHP => 6 FHTLT;15 XDBXC, 2 LTCX, 1 VRPVC => 6 ZLQW;13 WPTQ, 10 LTCX, 3 RJRHP, 14 XMNCP, 2 MZWV, 1 ZLQW => 1 ZDVW;5 BMBT => 4 WPTQ;189 ORE => 9 KTJDG;1 MZWV, 17 XDBXC, 3 XCVML => 2 XMNCP;12 VRPVC, 27 CNZTR => 2 XDBXC;15 KTJDG, 12 BHXH => 5 XCVML;3 BHXH, 2 VRPVC => 7 MZWV;121 ORE => 7 VRPVC;7 XCVML => 6 RJRHP;5 BHXH, 4 VRPVC => 5 LTCX";
            //string input = "9 ORE => 2 A;8 ORE => 3 B;7 ORE => 5 C;3 A, 4 B => 1 AB;5 B, 7 C => 1 BC;4 C, 1 A => 1 CA;2 AB, 3 BC, 4 CA => 1 FUEL";
            string[] recipes = input.Split(";");
            
            Dictionary<string, Recipe> recipesByName = new Dictionary<string, Recipe>();

            foreach (string rawrecipe in recipes)
            {
                string[] parts = rawrecipe.Split("=>");
                string[] output = parts[1].Trim().Split(" ");
                
                Recipe recipe = new Recipe(output[1], int.Parse(output[0]));
                string[] inputs = parts[0].Split(",");
                foreach (string s in inputs)
                {
                    string[] inputParts = s.Trim().Split(" ");
                    recipe.Ingredients.Add(inputParts[1], int.Parse(inputParts[0]));
                }
                recipesByName.Add(recipe.Output, recipe);
            }

            Dictionary<string, int> partsNeeded = new Dictionary<string, int>();
            partsNeeded.Add("FUEL", 1);
            Queue<string> thingsToFind = new Queue<string>();
            thingsToFind.Enqueue("FUEL");

            while (thingsToFind.Count > 0)
            {
                string nextThing = thingsToFind.Dequeue();
                if (nextThing == "ORE")
                {
                    continue;
                }

                int howManyNeeded = partsNeeded[nextThing];
                Recipe recipe = recipesByName[nextThing];

                // get a round number of divisions
                int craftsNeeded = (int) Math.Ceiling(howManyNeeded/ (decimal)recipe.Amount);
                
                foreach (KeyValuePair<string,int> keyValuePair in recipe.Ingredients)
                {

                    if (!partsNeeded.ContainsKey(keyValuePair.Key))
                    {
                        partsNeeded[keyValuePair.Key] = 0;
                    }

                    partsNeeded[keyValuePair.Key] = partsNeeded[keyValuePair.Key] + (craftsNeeded * keyValuePair.Value);

                    if (partsNeeded[keyValuePair.Key] > 0)
                    {
                        thingsToFind.Enqueue(keyValuePair.Key);
                    }
                }

                partsNeeded[nextThing] = partsNeeded[nextThing] - (craftsNeeded * recipe.Amount);
            }
            
            Console.WriteLine(partsNeeded["ORE"]);
            
            return Task.CompletedTask;
        }

        public Task RunPart2Async(CancellationToken cancellationToken)
        {

                        string input =
                "3 NPNGZ, 3 TBFQ, 1 RZBF => 2 LQNR;1 GWZRW => 9 CHNX;1 DBVD, 10 VCHK, 12 WNHV, 1 FMKT, 1 DKFT, 1 BTLR, 12 VHKXD => 4 ZMWC;2 RZBF, 13 JSBVZ => 3 JLVRS;15 BZNB, 1 JSBVZ => 5 ZTCM;28 GMSF, 18 LTGJ => 9 BTLR;1 RZDM, 3 BNJD, 1 FLXL => 1 FDBX;2 BZNB, 1 JLVRS => 2 GMSF;1 FDBX, 2 ZSQR, 1 XMBS, 2 FMKT, 1 BNJD, 12 TRXVN => 7 CRNMW;1 PCHWB, 6 LXJPK, 2 ZSQR => 5 DBVD;5 LMTM, 9 RZBF => 7 TBFQ;2 KVWJG => 2 RZBF;1 LBFXF, 17 NRBGS => 6 JSBVZ;1 VQTFW => 5 LMTM;20 DBVD => 2 SRFQ;3 XSVZ, 7 JSBVZ, 5 NPNGZ => 2 VWMQZ;1 ZQDN, 1 RZBF, 1 NDNKB => 9 FMKT;7 BZVGH, 9 NDNKB => 6 LTGJ;3 VWMQZ, 1 XSVZ, 4 GKDGX => 1 TRXVN;3 VXFJM, 14 FMKT => 6 NFTJ;21 WXWHD => 1 VCHK;1 TJZVQ => 6 NDNKB;6 NFTJ => 3 RZDM;1 VHKXD, 1 TBPWN, 1 FDBX, 2 XMBS, 2 WJTRC, 20 BTLR => 8 VSBV;19 XSVZ, 7 LJQG, 10 ZTCM => 1 GKDGX;3 NPNGZ, 2 RZBF, 8 GWZRW => 1 QVDFQ;1 TBFQ => 7 VHKXD;3 LTGJ, 1 ZXWB, 2 MNPBV => 2 BNJD;9 LQNR, 2 QVDFQ, 10 GMSF => 4 XSVZ;13 VHKXD, 17 CHNX, 1 NDNKB => 8 VXFJM;122 ORE => 4 LBFXF;18 NPNGZ => 5 LXJPK;1 TJZVQ, 1 FXGH => 5 GWZRW;9 BZNB, 4 JLVRS => 3 KDCG;1 SNLNK => 8 WNHV;4 VHKXD => 4 DGFN;1 RZDM => 6 SNLNK;3 CHNX, 8 LTGJ => 4 TBPWN;2 DGFN, 1 NFTJ => 2 RNSXD;1 FXGH, 1 BDCLW => 2 LJQG;3 DGCMV, 2 BZVGH, 7 RZBF => 8 MNPBV;14 WXWHD => 2 XMBS;1 BZVGH => 8 FLXL;8 VXFJM, 1 NFTJ => 2 WXWHD;2 LXJPK => 9 ZSQR;5 NRBGS, 1 LBFXF => 9 FXGH;4 NRBGS, 27 CHNX => 9 PCHWB;3 LBFXF => 4 TJZVQ;185 ORE => 2 VQTFW;1 RTVFM, 1 TBPWN => 6 DGCMV;10 NRBGS => 3 ZQDN;5 JSBVZ, 8 FXGH, 1 TJZVQ => 7 NPNGZ;1 PCHWB, 6 LXJPK, 5 LTGJ => 2 ZXWB;1 NPNGZ, 24 FMKT => 6 WJTRC;4 KDCG, 33 BZNB => 3 KGNH;2 KGNH, 4 ZTCM, 15 CHNX => 6 BDCLW;10 LXJPK, 18 TJZVQ, 1 FXGH => 7 BZVGH;27 DBVD, 2 CRNMW, 8 ZTCM, 8 RNSXD, 14 VSBV, 6 ZMWC, 37 TBPWN, 53 SRFQ => 1 FUEL;19 FXGH, 4 TJZVQ => 3 BZNB;17 QVDFQ, 26 KDCG, 7 CHNX => 3 RTVFM;111 ORE => 6 KVWJG;3 ZTCM => 6 DKFT;124 ORE => 6 NRBGS";
            //string input =
              //  "2 VPVL, 7 FWMGM, 2 CXFTF, 11 MNCFX => 1 STKFG;17 NVRVD, 3 JNWZP => 8 VPVL;53 STKFG, 6 MNCFX, 46 VJHF, 81 HVMC, 68 CXFTF, 25 GNMV => 1 FUEL;22 VJHF, 37 MNCFX => 5 FWMGM;139 ORE => 4 NVRVD;144 ORE => 7 JNWZP;5 MNCFX, 7 RFSQX, 2 FWMGM, 2 VPVL, 19 CXFTF => 3 HVMC;5 VJHF, 7 MNCFX, 9 VPVL, 37 CXFTF => 6 GNMV;145 ORE => 6 MNCFX;1 NVRVD => 8 CXFTF;1 VJHF, 6 MNCFX => 4 RFSQX;176 ORE => 6 VJHF";
         //   string input =
           //     "157 ORE => 5 NZVS;165 ORE => 6 DCFZ;44 XJWVT, 5 KHKGT, 1 QDVJ, 29 NZVS, 9 GPVTF, 48 HKGWZ => 1 FUEL;12 HKGWZ, 1 GPVTF, 8 PSHF => 9 QDVJ;179 ORE => 7 PSHF;177 ORE => 5 HKGWZ;7 DCFZ, 7 PSHF => 2 XJWVT;165 ORE => 2 GPVTF;3 DCFZ, 7 NZVS, 5 HKGWZ, 10 PSHF => 8 KHKGT";
            //string input =
                //"171 ORE => 8 CNZTR;7 ZLQW, 3 BMBT, 9 XCVML, 26 XMNCP, 1 WPTQ, 2 MZWV, 1 RJRHP => 4 PLWSL;114 ORE => 4 BHXH;14 VRPVC => 6 BMBT;6 BHXH, 18 KTJDG, 12 WPTQ, 7 PLWSL, 31 FHTLT, 37 ZDVW => 1 FUEL;6 WPTQ, 2 BMBT, 8 ZLQW, 18 KTJDG, 1 XMNCP, 6 MZWV, 1 RJRHP => 6 FHTLT;15 XDBXC, 2 LTCX, 1 VRPVC => 6 ZLQW;13 WPTQ, 10 LTCX, 3 RJRHP, 14 XMNCP, 2 MZWV, 1 ZLQW => 1 ZDVW;5 BMBT => 4 WPTQ;189 ORE => 9 KTJDG;1 MZWV, 17 XDBXC, 3 XCVML => 2 XMNCP;12 VRPVC, 27 CNZTR => 2 XDBXC;15 KTJDG, 12 BHXH => 5 XCVML;3 BHXH, 2 VRPVC => 7 MZWV;121 ORE => 7 VRPVC;7 XCVML => 6 RJRHP;5 BHXH, 4 VRPVC => 5 LTCX";
            //string input = "9 ORE => 2 A;8 ORE => 3 B;7 ORE => 5 C;3 A, 4 B => 1 AB;5 B, 7 C => 1 BC;4 C, 1 A => 1 CA;2 AB, 3 BC, 4 CA => 1 FUEL";
            string[] recipes = input.Split(";");
            
            Dictionary<string, Recipe> recipesByName = new Dictionary<string, Recipe>();

            foreach (string rawrecipe in recipes)
            {
                string[] parts = rawrecipe.Split("=>");
                string[] output = parts[1].Trim().Split(" ");
                
                Recipe recipe = new Recipe(output[1], int.Parse(output[0]));
                string[] inputs = parts[0].Split(",");
                foreach (string s in inputs)
                {
                    string[] inputParts = s.Trim().Split(" ");
                    recipe.Ingredients.Add(inputParts[1], int.Parse(inputParts[0]));
                }
                recipesByName.Add(recipe.Output, recipe);
            }

            Dictionary<string, long> partsNeeded = new Dictionary<string, long>();
            partsNeeded["ORE"] = 0;
            
            Queue<string> thingsToFind = new Queue<string>();

            long oreMax = 1000000000000L;
            long maxOrePerFuel = 1920219;
            long fuel = 0;
        
            while (partsNeeded["ORE"] < oreMax)
            {
                int fuelOnThisRun = (int) Math.Max(1, Math.Floor((oreMax - partsNeeded["ORE"]) / (double) maxOrePerFuel));
                partsNeeded["FUEL"] = fuelOnThisRun;
                thingsToFind.Enqueue("FUEL");
                while (thingsToFind.Count > 0)
                {
                    string nextThing = thingsToFind.Dequeue();
                    if (nextThing == "ORE")
                    {
                        continue;
                    }

                    long howManyNeeded = partsNeeded[nextThing];
                    Recipe recipe = recipesByName[nextThing];

                    // get a round number of divisions
                    long craftsNeeded = (long) Math.Ceiling(howManyNeeded/ (decimal)recipe.Amount);
                
                    foreach (KeyValuePair<string,int> keyValuePair in recipe.Ingredients)
                    {

                        if (!partsNeeded.ContainsKey(keyValuePair.Key))
                        {
                            partsNeeded[keyValuePair.Key] = 0;
                        }

                        partsNeeded[keyValuePair.Key] = partsNeeded[keyValuePair.Key] + (craftsNeeded * keyValuePair.Value);

                        if (partsNeeded[keyValuePair.Key] > 0)
                        {
                            thingsToFind.Enqueue(keyValuePair.Key);
                        }
                    }

                    partsNeeded[nextThing] = partsNeeded[nextThing] - (craftsNeeded * recipe.Amount);
                }

                if (partsNeeded["ORE"] <= oreMax)
                {
                    fuel += fuelOnThisRun;
                }
            }


            Console.WriteLine(fuel);
            
            return Task.CompletedTask;
        }
    }
}