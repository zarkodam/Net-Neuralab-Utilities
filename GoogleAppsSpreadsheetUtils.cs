using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Client;
using Google.GData.Spreadsheets;
using System.Collections;

namespace Net_Neuralab_Utilities
{
    class GoogleAppsSpreadsheetUtils
    {
        //Fetch all Spreadsheets

        public static ArrayList getSpreadsheetList(string userName, string passWord)
        {
            ArrayList spreadsheetList = new ArrayList();

            SpreadsheetsService service = new SpreadsheetsService("GetSpreadsheetsService");

            //You could set it up from DB or config file also. This is not a reccomended way. Just an easy way to show fetching
            service.setUserCredentials(userName, passWord); 

            SpreadsheetQuery query = new SpreadsheetQuery();

            SpreadsheetFeed feed = service.Query(query);

            foreach (SpreadsheetEntry entry in feed.Entries)
            {
                spreadsheetList.Add(entry.Title.Text);
            }

            return spreadsheetList;

            //developemnt
        }



        //Fetch all worksheets for given Spreadsheet

        public static ArrayList getWorksheetList(string userName, string passWord, string spreadSheetName)
        {
            ArrayList worksheetList = new ArrayList();

            SpreadsheetsService service = new SpreadsheetsService(spreadSheetName + "Service");

            //You could set it up from DB or config file also. This is not a reccomended way. Just an easy way to show fetching
            service.setUserCredentials(userName, passWord); 

            SpreadsheetQuery query = new SpreadsheetQuery();

            SpreadsheetFeed feed = service.Query(query);

            foreach (SpreadsheetEntry entry in feed.Entries)
            {
                if (entry.Title.Text == spreadSheetName)
                {
                    AtomLink link = entry.Links.FindService(GDataSpreadsheetsNameTable.WorksheetRel, null);

                    WorksheetQuery wquery = new WorksheetQuery(link.HRef.ToString());
                    WorksheetFeed wfeed = service.Query(wquery);

                    foreach (WorksheetEntry worksheet in wfeed.Entries)
                    {
                        worksheetList.Add(worksheet.Title.Text);  
                    }
                }
            }

            return worksheetList;

        }
    }
}
