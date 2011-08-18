﻿using System;
using System.Data;
using System.Diagnostics;
using System.Text;
using Hellgate;
using MediaWiki.Parser;
using MediaWiki.Parser.Class;
using MediaWiki.Util;

namespace MediaWiki.Articles
{
    class Affixes : WikiScript
    {
        public Affixes(FileManager manager) : base(manager)
        {
        }

        public override string ExportTableInsertScript()
        {
            SQLTableScript table = new SQLTableScript("id", "code",
                "id INT NOT NULL",
                "code VARCHAR(6) NOT NULL",
                "magic_name TEXT",
                "display_string TEXT"
            );

            var affixes = Manager.GetDataTable("AFFIXES");

            string id, code, magicName, displayString;
            string property1;

            Evaluator evaluator = new Evaluator();
            ItemDisplay.Manager = Manager;

            foreach (DataRow row in affixes.Rows)
            {
                Unit unit = new Item();
                Game3 game3 = new Game3();
                property1 = row["property1"].ToString();
                evaluator.Unit = unit;
                evaluator.Game3 = game3;
                evaluator.Evaluate(property1);
                String[] displayStrings = ItemDisplay.GetDisplayStrings(unit);

                id = row["Index"].ToString();
                code = GetSqlEncapsulatedString(((int)row["code"]).ToString("X"));
                magicName = GetSqlEncapsulatedString(row["magicNameString_string"].ToString());
                displayString = GetSqlEncapsulatedString(displayStrings.Length == 0 ? String.Empty : displayStrings[0]);

                Debug.WriteLine(displayString);

                table.AddRow(id, code, magicName, displayString);
            }

            return table.GetFullScript();
        }


        public override string ExportArticle()
        {
            throw new NotImplementedException();
        }
    }
}
